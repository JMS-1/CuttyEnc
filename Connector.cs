using System;
using System.IO;
using System.Data;
using System.Text;
using JMS.InterOp.DVDAuthor;
using JMS.InterOp.CommandLine;

namespace CuttyEnc
{
    /// <summary>
    /// A MPEG2Enc provider for <i>Cuttermaran</i>.
    /// </summary>
    public class Connector
    {
        /// <summary>
        /// Helper class to collect standard error messages.
        /// </summary>
        private class Logger : IDisposable
        {
            /// <summary>
            /// Collecting buffer.
            /// </summary>
            private StringWriter m_Output = new StringWriter();

            /// <summary>
            /// Create a new instance.
            /// </summary>
            public Logger()
            {
            }

            /// <summary>
            /// Add a string to the buffer.
            /// </summary>
            /// <param name="someMessage">Some message.</param>
            public void AddString( string someMessage )
            {
                // Merge
                m_Output.WriteLine( someMessage );
            }

            /// <summary>
            /// Get the collected string.
            /// </summary>
            /// <returns>All received data.</returns>
            public override string ToString()
            {
                // Forward
                return m_Output.ToString();
            }

            /// <summary>
            /// Convert the byte data to a <see cref="string"/>
            /// and append it to the buffer.
            /// </summary>
            /// <param name="someData"></param>
            /// <param name="length"></param>
            public void ReportError( byte[] someData, int length )
            {
                // Convert
                m_Output.Write( Encoding.ASCII.GetString( someData, 0, length ) );
            }

            #region IDisposable Members

            /// <summary>
            /// Release all resources allocated.
            /// </summary>
            public void Dispose()
            {
                // Cleanup
                if (null != m_Output)
                {
                    // Close it
                    m_Output.Close();

                    // Detach
                    m_Output = null;
                }
            }

            #endregion
        }

        /// <summary>
        /// Create a new encoding provider instance.
        /// </summary>
        public Connector()
        {
        }

        /// <summary>
        /// Show the configuration dialog.
        /// </summary>
        public void Config()
        {
            // Create it
            using (Configuration dialog = new Configuration())
            {
                // Run it
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Encode a short YV12 AVI sequence to MPEG2.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Encode( DataSet data )
        {
            // Attach to requirement
            DataRow settings = data.Tables[0].Rows[0];

            // Load global check
            bool unattended = (bool) settings["Unattended"];

            // With logging
            using (Logger pLog = new Logger())
                try
                {
                    // Load all settings
                    bool bProgressive = (bool) settings["IsProgressive"];
                    bool bTopFirst = (bool) settings["IsTopFieldFirst"];
                    string sOutput = (string) settings["ResultMPGFile"];
                    short dFrameRate = (short) settings["FrameRate"];
                    short eFormat = (short) settings["VideoFormat"];
                    short lAspect = (short) settings["AspectRatio"];
                    int lVBVBuffer = (int) settings["VBVBuffer"];
                    string sInput = (string) settings["AVIFile"];
                    short lHeight = (short) settings["Height"];
                    long lBitRate = (long) settings["BitRate"];
                    bool bMEPG2 = (bool) settings["IsMpeg2"];
                    short lWidth = (short) settings["Width"];

                    // Load settings
                    Settings configuration = new Settings();

                    // Read the directory
                    string exePath = configuration.Directory;

                    // Try to default it
                    if (string.IsNullOrEmpty( exePath ))
                    {
                        // Try this
                        exePath = TestDirectory( "." );

                        // Try relative
                        if (null == exePath)
                            exePath = TestDirectory( @"..\..\External Tools" );
                    }

                    // Overwrite
                    CommandLineTool.PresetDirectory = exePath;

                    // Create the executer
                    using (YV122M2V pEncoder = new YV122M2V())
                    {
                        // Special HDTV correction
                        if (1080 == lHeight)
                            lHeight = 1088;

                        // Configure
                        pEncoder.VideoNorm = GetVideoNorm( eFormat );
                        pEncoder.AspectRatio = GetAspect( lAspect );
                        pEncoder.HiResMode = (lHeight >= 720);
                        pEncoder.FrameRateCode = dFrameRate;
                        pEncoder.OutputFile = sOutput;
                        pEncoder.InputFile = sInput;
                        pEncoder.Height = lHeight;
                        pEncoder.Width = lWidth;

                        // Use special path for high res mode
                        if (pEncoder.HiResMode)
                        {
                            // Test for diretory
                            DirectoryInfo hiRes = new DirectoryInfo( Path.Combine( CommandLineTool.PresetDirectory, "HDTV" ) );

                            // Use if it exists
                            if (hiRes.Exists)
                                CommandLineTool.PresetDirectory = hiRes.FullName;
                        }

                        // Check mode
                        if (bMEPG2)
                        {
                            // DVD/SVCD
                            pEncoder.Interlacing = bProgressive ? YV122M2V.InterlacingMode.None : (bTopFirst ? YV122M2V.InterlacingMode.TopFirst : YV122M2V.InterlacingMode.BottomFirst);
                            pEncoder.Format = MPEG2Enc.Formats.DVD;
                            pEncoder.BitRate = (int) (lBitRate / 1000);
                            pEncoder.BufferSize = (lVBVBuffer / 1024);
                        }
                        else
                        {
                            // VCD
                            pEncoder.Interlacing = YV122M2V.InterlacingMode.None;
                            pEncoder.Format = MPEG2Enc.Formats.VCD;
                        }

                        // Attach logger
                        pEncoder.OnError += pLog.ReportError;

                        // Start it
                        Stream pIn = pEncoder.Start();

                        // In erroror
                        if (null == pIn)
                            throw new Exception( StringResources.Strings.StartEncoding.Text );

                        // With cleanup
                        try
                        {
                            // Process it
                            if (!pEncoder.WaitForExit())
                                throw new Exception( StringResources.Strings.EncodingFailed.Text );
                        }
                        finally
                        {
                            // Done with input
                            pIn.Close();
                        }
                    }

                    // Report
                    if (configuration.DebugOutput)
                        if (!unattended)
                            EncodingError.Show( pLog.ToString() );

                    // Woo, we did it!
                    return 0;
                }
                catch (Exception e)
                {
                    // Extend
                    pLog.AddString( e.ToString() );

                    // Create logger
                    if (!unattended)
                        EncodingError.Show( pLog.ToString() );

                    // Report error
                    return -1;
                }
        }

        /// <summary>
        /// Translate the <i>Cuttermaran</i> code of the video norm.
        /// </summary>
        /// <param name="normCode">Currently only 1 (PAL) and
        /// 2 (NTSC) are supported.</param>
        /// <returns>The MPEG2Enc related index.</returns>
        private static MPEG2Enc.VideoNorms GetVideoNorm( short normCode )
        {
            // Supported
            switch (normCode)
            {
                case 0: /* Component */ break;
                case 1: return MPEG2Enc.VideoNorms.PAL;
                case 2: return MPEG2Enc.VideoNorms.NTSC;
                case 3: return MPEG2Enc.VideoNorms.SECAM;
                case 4: /* MAC */ break;
                case 5: return MPEG2Enc.VideoNorms.Unspecified;
            }

            // Not supported
            throw new ArgumentException( StringResources.Strings.BadVideoNorm.Text + normCode.ToString(), "normCode" );
        }

        /// <summary>
        /// Translate a <i>Cuttermaran</i> picture aspect ratio code
        /// to the MPEG2Enc representation.
        /// </summary>
        /// <param name="aspectCode">The MPEG2 aspect ratio code - only
        /// the values 1 to 4 are supported.</param>
        /// <returns>The MPEG2Enc representation.</returns>
        private static MPEG2Enc.AspectRatios GetAspect( short aspectCode )
        {
            // Supported
            switch (aspectCode)
            {
                case 1: return MPEG2Enc.AspectRatios.VGA;
                case 2: return MPEG2Enc.AspectRatios.TV;
                case 3: return MPEG2Enc.AspectRatios.Wide;
                case 4: return MPEG2Enc.AspectRatios.Cinema;
                case 8: return MPEG2Enc.AspectRatios.VCD;
                case 12: return MPEG2Enc.AspectRatios.VCD;
            }

            // Not supported
            throw new ArgumentException( StringResources.Strings.BadAspect.Text + aspectCode.ToString(), "aspectCode" );
        }

        /// <summary>
        /// See if the given relative directory path hosts the executables
        /// necessary to run the MPEG2 encoding.
        /// </summary>
        /// <param name="relativePath">Some relative path.</param>
        /// <returns><i>null</i> or an absolute path relative to the
        /// directory of the current assembly.</returns>
        private static string TestDirectory( string relativePath )
        {
            // Find us
            string sDLL = typeof( Connector ).Assembly.CodeBase;

            // Change it
            sDLL = sDLL.Substring( 8 ).Replace( '/', '\\' );

            // Make it a directory
            sDLL = sDLL.Substring( 0, sDLL.LastIndexOf( '\\' ) );

            // Attach to directory
            DirectoryInfo pDir = new DirectoryInfo( Path.Combine( sDLL, relativePath ) );

            // Skip
            if (!pDir.Exists) return null;

            // Create files for testing
            FileInfo pTest = new FileInfo( Path.Combine( pDir.FullName, "mpeg2enc.exe" ) );

            // Check all
            return pTest.Exists ? pDir.FullName : null;
        }
    }
}
