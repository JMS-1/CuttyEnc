using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace JMS.InterOp.DVDAuthor
{
    /// <summary>
    /// This class reads an AVI file and allows parsing single
    /// frames.
    /// </summary>
    public class AVIFile : IDisposable
    {
        /// <summary>
        /// The header of a BMP file.
        /// </summary>
        [StructLayout( LayoutKind.Sequential, Pack = 1 )]
        private struct BitmapFileHeader
        {
            /// <summary>
            /// File type.
            /// </summary>
            public short bfType;

            /// <summary>
            /// Overall size in bytes.
            /// </summary>
            public int bfSize;

            /// <summary>
            /// Must be zero.
            /// </summary>
            public short bfReserved1;

            /// <summary>
            /// Must be zero.
            /// </summary>
            public short bfReserved2;

            /// <summary>
            /// Offset to the first byte of data.
            /// </summary>
            public int bfOffBits;

            /// <summary>
            /// Report the unmanaged size of the bitmap file header in bytes.
            /// </summary>
            public static int SizeOf
            {
                get
                {
                    // Report
                    return Marshal.SizeOf( typeof( BitmapFileHeader ) );
                }
            }
        }

        /// <summary>
        /// Open a single stream in an AVI file.
        /// </summary>
        /// <param name="hFile">The AVI file.</param>
        /// <param name="hStream">The stream handle.</param>
        /// <param name="fccType">Type of stream to open.</param>
        /// <param name="lParam">Zero based index of the stream to open.</param>
        /// <returns>Error code.</returns>
        [DllImport( "avifil32.dll", EntryPoint = "AVIFileGetStream" )]
        private static extern Int32 AVIFileGetStream( IntPtr hFile, out IntPtr hStream, UInt32 fccType, Int32 lParam );

        /// <summary>
        /// Open an AVI file.
        /// </summary>
        /// <param name="hFile">The file handle.</param>
        /// <param name="sFile">Full path to the file.</param>
        /// <param name="mode">Open mode.</param>
        /// <param name="useDefault">Must be fixed to <see cref="IntPtr.Zero"/>.</param>
        /// <returns>Error code.</returns>
        [DllImport( "avifil32.dll", EntryPoint = "AVIFileOpen" )]
        private static extern Int32 AVIFileOpen( out IntPtr hFile, string sFile, UInt32 mode, IntPtr useDefault );

        /// <summary>
        /// Create a frame buffer on a stream which can be used to retrieve 
        /// pixel data.
        /// </summary>
        /// <param name="hStream">The stream handle.</param>
        /// <param name="hBitmap">Optional bitmap information record.</param>
        /// <returns>Error code.</returns>
        [DllImport( "avifil32.dll", EntryPoint = "AVIStreamGetFrameOpen" )]
        private static extern IntPtr AVIStreamGetFrameOpen( IntPtr hStream, IntPtr hBitmap );

        /// <summary>
        /// Get a DIB reference of a single frame inside the selected stream.
        /// </summary>
        /// <param name="hFrame">The frame construction buffer.</param>
        /// <param name="lPos">A zero based index of the frame.</param>
        /// <returns>DIB reference.</returns>
        [DllImport( "avifil32.dll", EntryPoint = "AVIStreamGetFrame" )]
        private static extern IntPtr AVIStreamGetFrame( IntPtr hFrame, Int32 lPos );

        /// <summary>
        /// Release a frame buffer instance.
        /// </summary>
        /// <param name="hFrame">Handle to the frame buffer.</param>
        /// <returns>Reference count left.</returns>
        [DllImport( "avifil32.dll", EntryPoint = "AVIStreamGetFrameClose" )]
        private static extern Int32 AVIStreamGetFrameClose( IntPtr hFrame );

        /// <summary>
        /// Release a stream instance.
        /// </summary>
        /// <param name="hStream">The stream handle.</param>
        /// <returns>Reference count left.</returns>
        [DllImport( "avifil32.dll", EntryPoint = "AVIStreamRelease" )]
        private static extern Int32 AVIStreamRelease( IntPtr hStream );

        /// <summary>
        /// Release an AVI file.
        /// </summary>
        /// <param name="hFile">The AVI file handle.</param>
        /// <returns>Reference count left.</returns>
        [DllImport( "avifil32.dll", EntryPoint = "AVIFileRelease" )]
        private static extern UInt32 AVIFileRelease( IntPtr hFile );

        /// <summary>
        /// Read the raw data of a single sample in the stream.
        /// </summary>
        /// <param name="hStream">One stream inside the AVI file.</param>
        /// <param name="lStart">First sample to retrieve.</param>
        /// <param name="lSamples">Number of samples to retrieve.</param>
        /// <param name="lpBuffer">Some (unmarshalled) buffer for the sample data.</param>
        /// <param name="cbBuffer">The size of the buffer in bytes.</param>
        /// <param name="plBytes">The bytes used in the buffer.</param>
        /// <param name="plSamples">The number of samples retrieved.</param>
        /// <returns>Not zero in case of any error.</returns>
        [DllImport( "avifil32.dll", EntryPoint = "AVIStreamRead" )]
        private static extern UInt32 AVIStreamRead( IntPtr hStream, Int32 lStart, Int32 lSamples, IntPtr lpBuffer, Int32 cbBuffer, out Int32 plBytes, out Int32 plSamples );

        /// <summary>
        /// Primary video stream of the AVI file.
        /// </summary>
        private IntPtr m_Stream = IntPtr.Zero;

        /// <summary>
        /// Frame construction buffer on the primary video stream.
        /// </summary>
        private IntPtr m_Frame = IntPtr.Zero;

        /// <summary>
        /// AVI file handle.
        /// </summary>
        private IntPtr m_File = IntPtr.Zero;

        /// <summary>
        /// Open the indicated AVI file.
        /// </summary>
        /// <param name="filePath">Path to the AVI file.</param>
        public AVIFile( string filePath )
        {
            // See if this is a Vista corrupted file
            VistaCorrection( filePath );

            // Open the file
            if (0 != AVIFileOpen( out m_File, filePath, 0, IntPtr.Zero ))
                throw new ArgumentException( "can not open AVI file " + filePath, "filePath" );

            // Open the primary stream interface
            if (0 != AVIFileGetStream( m_File, out m_Stream, 0x73646976, 0 ))
                throw new ArgumentException( "can not open video stream in AVI file " + filePath, "filePath" );

            // Create frame helper
            m_Frame = AVIStreamGetFrameOpen( m_Stream, IntPtr.Zero );
        }

        /// <summary>
        /// Read the raw data for the indicated sample.
        /// </summary>
        /// <param name="frameNumber">The zero-based sample index.</param>
        /// <returns>The raw data of the sample or <i>null</i> if the
        /// data is not available.</returns>
        public byte[] GetSample( int frameNumber )
        {
            // Helper
            int lBytesNeeded, lSamples;

            // Request the size of a single frame
            if (0 != AVIStreamRead( m_Stream, frameNumber, 1, IntPtr.Zero, 0, out lBytesNeeded, out lSamples )) 
                return null;

            // Allocate memory
            IntPtr rMem = Marshal.AllocHGlobal( lBytesNeeded );

            // With cleanup
            try
            {
                // Helper
                int lBytes;

                // Request the frame
                if (0 != AVIStreamRead( m_Stream, frameNumber, 1, rMem, lBytesNeeded, out lBytes, out lSamples )) 
                    throw new Exception( "read error" );

                // Create the result
                byte[] aRet = new byte[lBytes];

                // Copy to marshalled area
                Marshal.Copy( rMem, aRet, 0, aRet.Length );

                // Report
                return aRet;
            }
            finally
            {
                // Release unmarshalled memory
                Marshal.FreeHGlobal( rMem );
            }
        }

        /// <summary>
        /// Read the DIB of the indicated frame and report it as a
        /// raw <see cref="Image"/>.
        /// </summary>
        /// <param name="frameNumber">The zero based frame index.</param>
        /// <param name="imageStream">Must be closed by the caller when the
        /// returned <see cref="Image"/> is no longer needed.</param>
        /// <returns>The frame pixels or <i>null</i> if the indicated
        /// frame does not exist.</returns>
        public Image GetFrame( int frameNumber, out Stream imageStream )
        {
            // Clear output
            imageStream = null;

            // Try to read DIB
            IntPtr rDIB = AVIStreamGetFrame( m_Frame, frameNumber );

            // None
            if (IntPtr.Zero == rDIB) 
                return null;

            // Read the sizes
            int fSize = BitmapFileHeader.SizeOf;
            short hSize = Marshal.ReadInt16( rDIB, 0 );
            int iSize = Marshal.ReadInt32( rDIB, 20 );

            // Create proper file header header
            BitmapFileHeader pHead = new BitmapFileHeader();
            pHead.bfType = 0x4D42;
            pHead.bfReserved1 = 0;
            pHead.bfReserved2 = 0;
            pHead.bfOffBits = fSize + hSize;
            pHead.bfSize = pHead.bfOffBits + iSize;

            // Allocate buffer
            byte[] aBuf = new byte[pHead.bfSize];

            // For a moment use unmanaged memory
            GCHandle hHead = GCHandle.Alloc( pHead, GCHandleType.Pinned );

            // With cleanup
            try
            {
                // Copy header in
                Marshal.Copy( hHead.AddrOfPinnedObject(), aBuf, 0, fSize );
            }
            finally
            {
                // Relax
                hHead.Free();
            }

            // Copy DIB in
            Marshal.Copy( rDIB, aBuf, fSize, hSize + iSize );

            // Create output stream
            MemoryStream pOut = new MemoryStream( aBuf, false );

            // With cleanup
            try
            {
                // Load an image
                Image pRet = Image.FromStream( pOut );

                // Report result
                imageStream = pOut;

                // Do not clear
                pOut = null;

                // Report
                return pRet;
            }
            finally
            {
                // Stream no longer used
                if (null != pOut) pOut.Close();
            }
        }

        private static void VistaCorrection( string path )
        {
            // Open the file
            using (FileStream stream = new FileStream( path, FileMode.Open, FileAccess.ReadWrite, FileShare.None ))
            {
                // Head buffer
                byte[] head = new byte[0x800];

                // Read it
                if (head.Length != stream.Read( head, 0, head.Length )) 
                    return;

                // Back to the start
                stream.Seek( 0, SeekOrigin.Begin );

                // Compare JUNK pattern
                if ('J' != head[0xd4]) 
                    return;
                if ('U' != head[0xd5]) 
                    return;
                if ('N' != head[0xd6]) 
                    return;
                if ('K' != head[0xd7]) 
                    return;

                // Read the length
                uint j0 = head[0xd8];
                uint j1 = head[0xd9];
                uint j2 = head[0xda];
                uint j3 = head[0xdb];
                uint jlen = j0 + 256 * (j1 + 256 * (j2 + 256 * j3));

                // Not vista
                if (0 != jlen) 
                    return;

                // Compare LIST pattern
                if ('L' != head[0xdc]) 
                    return;
                if ('I' != head[0xdd]) 
                    return;
                if ('S' != head[0xde]) 
                    return;
                if ('T' != head[0xdf]) 
                    return;

                // Read the length
                uint l0 = head[0xe0];
                uint l1 = head[0xe1];
                uint l2 = head[0xe2];
                uint l3 = head[0xe3];
                uint len = l0 + 256 * (l1 + 256 * (l2 + 256 * l3));

                // Compare movi pattern
                if ('m' != head[0xe4]) 
                    return;
                if ('o' != head[0xe5]) 
                    return;
                if ('v' != head[0xe6]) 
                    return;
                if ('i' != head[0xe7]) 
                    return;

                // Check zeros
                for (int i = head.Length; i-- > 0xe8; )
                    if (0 != head[i])
                        return;

                // Fixed correction JUNK length
                head[0xd8] = 0x18;
                head[0xd9] = 0x07;
                head[0xda] = 0x00;
                head[0xdb] = 0x00;

                // Wipe out
                for (int i = head.Length; i-- > 0xdc; ) head[i] = 0x00;

                // Fixed text LIST
                head[0x7f4] = (byte) ('L');
                head[0x7f5] = (byte) ('I');
                head[0x7f6] = (byte) ('S');
                head[0x7f7] = (byte) ('T');

                // Corrected length
                len -= 0x718;
                head[0x7f8] = (byte) ((len >> 0) & 0xff);
                head[0x7f9] = (byte) ((len >> 8) & 0xff);
                head[0x7fa] = (byte) ((len >> 16) & 0xff);
                head[0x7fb] = (byte) ((len >> 24) & 0xff);

                // Fixed text movi
                head[0x7fc] = (byte) ('m');
                head[0x7fd] = (byte) ('o');
                head[0x7fe] = (byte) ('v');
                head[0x7ff] = (byte) ('i');

                // Write back
                stream.Write( head, 0, head.Length );
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Release all unmanaged references hold here.
        /// </summary>
        public void Dispose()
        {
            // Release the frame helper
            if (IntPtr.Zero != m_Frame)
            {
                // Rroper close
                AVIStreamGetFrameClose( m_Frame );

                // Detach
                m_Frame = IntPtr.Zero;
            }

            // Release the video stream handle
            if (IntPtr.Zero != m_Stream)
            {
                // Rroper close
                AVIStreamRelease( m_Stream );

                // Detach
                m_Stream = IntPtr.Zero;
            }

            // Release AVI file handle
            if (IntPtr.Zero != m_File)
            {
                // Rroper close
                AVIFileRelease( m_File );

                // Detach
                m_File = IntPtr.Zero;
            }
        }

        #endregion
    }
}
