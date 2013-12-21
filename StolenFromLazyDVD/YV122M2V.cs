using System;
using System.IO;
using System.Text;
using JMS.InterOp.CommandLine;

namespace JMS.InterOp.DVDAuthor
{
    /// <summary>
    /// The input is a short AVI file which is YV12 encoded. The codec will
    /// be changed to IYUV and the YUV4MPEG headers added before sending
    /// all frames in the file to MPEG2Enc.
    /// </summary>
    /// <remarks>
    /// First: don't use for longer sequences since the AVI file
    /// will be fully expanded to pictures!
    /// </remarks>
    public class YV122M2V : ChainExecuter
    {
        /// <summary>
        /// Type of interlace.
        /// </summary>
        public enum InterlacingMode
        {
            /// <summary>
            /// Progressive frames.
            /// </summary>
            None,		// p

            /// <summary>
            /// Interlaced frames with top frame first.
            /// </summary>
            TopFirst,	// t

            /// <summary>
            /// Interlaced frames with bottom frame first.
            /// </summary>
            BottomFirst	// b
        }

        /// <summary>
        /// The type of interlacing used.
        /// </summary>
        public InterlacingMode Interlacing = InterlacingMode.None;

        /// <summary>
        /// The frame rate information record.
        /// </summary>
        private CuttyEnc.FrameRateInfo m_FrameRate = null;

        /// <summary>
        /// Height of each frame.
        /// </summary>
        public int Height = 0;

        /// <summary>
        /// Width of each frame
        /// </summary>
        public int Width = 0;

        /// <summary>
        /// The encoder.
        /// </summary>
        private MPEG2Enc m_ToVideo = new MPEG2Enc();

        /// <summary>
        /// Some YV12 AVI file - currently the format will <b>not</b>
        /// be checked so be cautious.
        /// </summary>
        public string InputFile = null;

        /// <summary>
        /// The input stream of MPEG2Enc.
        /// </summary>
        private Stream m_Pipe = null;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public YV122M2V()
        {
            // Register
            Add( m_ToVideo );
        }

        /// <summary>
        /// Set the picture aspect ratio of the encoder.
        /// </summary>
        public MPEG2Enc.AspectRatios AspectRatio
        {
            set
            {
                // Forward
                m_ToVideo.AspectRatio = value;
            }
        }

        /// <summary>
        /// Set the output video norm of the encoder.
        /// </summary>
        public MPEG2Enc.VideoNorms VideoNorm
        {
            set
            {
                // Forward
                m_ToVideo.VideoNorm = value;
            }
        }

        /// <summary>
        /// Gets or sets the high-resolution modus in the encoder.
        /// </summary>
        public bool HiResMode
        {
            get
            {
                // Report
                return m_ToVideo.HiResMode;
            }
            set
            {
                // Forward
                m_ToVideo.HiResMode = value;
            }
        }

        /// <summary>
        /// Set the MPEG2 file format of the encoder.
        /// </summary>
        public MPEG2Enc.Formats Format
        {
            set
            {
                // Forward
                m_ToVideo.Format = value;
            }
        }

        /// <summary>
        /// Set the path to the resulting MPEG2 file.
        /// </summary>
        public string OutputFile
        {
            set
            {
                // Forward
                m_ToVideo.OutputFile = value;
            }
        }

        /// <summary>
        /// Set the quality of the encoding process.
        /// </summary>
        public int Quantisation
        {
            set
            {
                // Forward
                m_ToVideo.Quantisation = value;
            }
        }

        /// <summary>
        /// Set the bitrate of the encoder (in kBits per second).
        /// </summary>
        public int BitRate
        {
            set
            {
                // Forward
                m_ToVideo.BitRate = value;
            }
        }

        /// <summary>
        /// Set the video buffer size of the encoder (in kB).
        /// </summary>
        public int BufferSize
        {
            set
            {
                // Forward
                m_ToVideo.BufferSize = value;
            }
        }

        /// <summary>
        /// Set the minimum number of frames a GOP can have.
        /// </summary>
        public int MinimumFramesPerGOP
        {
            set
            {
                // Forward
                m_ToVideo.MinimumFramesPerGOP = value;
            }
        }

        /// <summary>
        /// Set the maximum number of frames a GOP can have.
        /// </summary>
        public int MaximumFramesPerGOP
        {
            set
            {
                // Forward
                m_ToVideo.MaximumFramesPerGOP = value;
            }
        }

        /// <summary>
        /// Set the frame rate code of the encoder.
        /// </summary>
        public int FrameRateCode
        {
            set
            {
                // Self load
                m_FrameRate = CuttyEnc.FrameRateInfo.FindFrameRate( value );

                // Forward
                m_ToVideo.FrameRateCode = value;
            }
        }

        /// <summary>
        /// The the MEPG2Enc and remember its standard input.
        /// </summary>
        /// <returns>A dummy <see cref="Stream"/> to conform
        /// to the protocol.</returns>
        public override Stream Start()
        {
            // Detach reference
            ClosePipe();

            // Remember the standard input to MPEG2Enc
            m_Pipe = base.Start();

            // Report a dummy input
            return new MemoryStream();
        }

        /// <summary>
        /// Process the AVI input file.
        /// </summary>
        /// <returns>Inactive on any error.</returns>
        public override bool WaitForExit()
        {
            // Open the input file
            using (AVIFile pFile = new AVIFile( InputFile ))
            {
                // Start with the header
                SendHeader();

                // Process all frames
                for (int iFrame = 0; ; ++iFrame)
                {
                    // Load the raw frame data
                    byte[] aSample = pFile.GetSample( iFrame );

                    // Done
                    if (null == aSample)
                        break;

                    // Get the size
                    int lFull = aSample.Length;
                    int lPlane = aSample.Length / 6;

                    // Create helper
                    byte[] aTemp = new byte[lPlane];

                    // Swap planes (YV12 to IYUV)
                    Array.Copy( aSample, 4 * lPlane, aTemp, 0, lPlane );
                    Array.Copy( aSample, 5 * lPlane, aSample, 4 * lPlane, lPlane );
                    Array.Copy( aTemp, 0, aSample, 5 * lPlane, lPlane );

                    // Start a new frame
                    Send( "FRAME\n" );

                    // Send the data to the file
                    if (null != m_Pipe)
                        m_Pipe.Write( aSample, 0, aSample.Length );
                }
            }

            // We are done
            ClosePipe();

            // Use base class to wait for completion
            return base.WaitForExit();
        }

        /// <summary>
        /// Close the standard input of the MPEG2Enc.
        /// </summary>
        private void ClosePipe()
        {
            // Already done
            if (null == m_Pipe)
                return;

            // Close
            m_Pipe.Close();

            // Free reference
            m_Pipe = null;
        }

        /// <summary>
        /// Send some string to MPEG2Enc - this is used for YUV4MPEG headers.
        /// </summary>
        /// <param name="stringData">Some string which will be ASCII
        /// converted to a byte array.</param>
        private void Send( string stringData )
        {
            // Noting to do
            if (null == m_Pipe)
                return;

            // Convert
            byte[] aData = Encoding.ASCII.GetBytes( stringData );

            // Send
            m_Pipe.Write( aData, 0, aData.Length );
        }

        /// <summary>
        /// Create a string from a format and optional parameters
        /// and send the result to MPEG2Enc.
        /// </summary>
        /// <param name="format">Format information.</param>
        /// <param name="args">Zero or more parameters for the format.</param>
        private void Send( string format, params object[] args )
        {
            // Forward
            Send( " " + string.Format( format, args ) );
        }

        /// <summary>
        /// Send the YUV4MPEG header to MPEG2Enc.
        /// </summary>
        private void SendHeader()
        {
            // Process
            Send( "YUV4MPEG2" );
            if (Width > 0)
                Send( "W{0}", Width );
            if (Height > 0)
                Send( "H{0}", Height );
            if (null != m_FrameRate)
                Send( "F{0}:{1}", m_FrameRate.Nominator, m_FrameRate.Denominator );
            switch (Interlacing)
            {
                case InterlacingMode.None: Send( "I{0}", 'p' ); break;
                case InterlacingMode.TopFirst: Send( "I{0}", 't' ); break;
                case InterlacingMode.BottomFirst: Send( "I{0}", 'b' ); break;
            }
            Send( " A0:0\n" );
        }

        /// <summary>
        /// Release all references.
        /// </summary>
        public override void Dispose()
        {
            // Close stream
            ClosePipe();

            // Forward to base class
            base.Dispose();
        }
    }
}
