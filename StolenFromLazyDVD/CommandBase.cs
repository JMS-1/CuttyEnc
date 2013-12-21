using System;
using System.IO;

namespace JMS.InterOp.CommandLine
{
    /// <summary>
    /// Abstract base class for a command line tool callable from
    /// .NET program code.
    /// </summary>
    public abstract class CommandBase : IDisposable
    {
        /// <summary>
        /// This delegate is used to report data on standard output and
        /// standard error.
        /// </summary>
        public delegate void RedirectHandler( byte[] someData, int length );

        /// <summary>
        /// Notified when data is sent to standard error.
        /// </summary>
        public event RedirectHandler OnError;

        /// <summary>
        /// Notified when data is sent to standard output.
        /// </summary>
        public event RedirectHandler OnOutput;

        /// <summary>
        /// Helper class to connect the output of one command line
        /// tool (or the initial standard input) to the input of
        /// the next tool in a pipe chain (or the terminal standard
        /// output).
        /// </summary>
        protected class Pipe
        {
            /// <summary>
            /// Receiver of data.
            /// </summary>
            private Stream m_Target;

            /// <summary>
            /// Create a new instance.
            /// </summary>
            /// <param name="target">Receiver of data.</param>
            public Pipe( Stream target )
            {
                // Remember
                m_Target = target;
            }

            /// <summary>
            /// Forward the data to the receiver.
            /// </summary>
            /// <param name="data">The data buffer.</param>
            /// <param name="length">The size of the buffer. When zero
            /// is used the instance closes the receiving <see cref="Stream"/>.
            /// </param>
            public void Forward( byte[] data, int length )
            {
                // Check mode
                if (length < 1)
                {
                    // Detach
                    m_Target.Close();
                }
                else
                {
                    // Forward
                    m_Target.Write( data, 0, length );
                }
            }
        }

        /// <summary>
        /// Initialize the base class.
        /// </summary>
        protected CommandBase()
        {
        }

        /// <summary>
        /// Wait for the tool to complete.
        /// </summary>
        /// <returns>Set when no error occured.</returns>
        public abstract bool WaitForExit();

        /// <summary>
        /// Start the tool.
        /// </summary>
        /// <returns>Standard input of the command line tool.</returns>
        public abstract Stream Start();

        /// <summary>
        /// Connect the tools standard input and output to files
        /// and execute it.
        /// </summary>
        /// <param name="inputPath">Take standard input from here.</param>
        /// <param name="outputPath">Send standard output to there.</param>
        /// <returns>Set when no error occured.</returns>
        public bool Run( string inputPath, string outputPath )
        {
            // Create stream
            Stream pOutput = new FileStream( outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 100000 );

            // With cleanup
            try
            {
                // Forward
                return Run( inputPath, pOutput );
            }
            finally
            {
                // Close
                pOutput.Close();
            }
        }

        /// <summary>
        /// Take standard input from a file and send standard
        /// output to a stream.
        /// </summary>
        /// <param name="inputPath">Take standard input from here.</param>
        /// <param name="outputStream">Send standard output to there.</param>
        /// <returns>Set when no error occured.</returns>
        public bool Run( string inputPath, Stream outputStream )
        {
            // Create stream
            FileStream pInput = new FileStream( inputPath, FileMode.Open, FileAccess.Read, FileShare.Read, 100000 );

            // With cleanup
            try
            {
                // Forward
                return Run( pInput, outputStream );
            }
            finally
            {
                // Cleanup
                pInput.Close();
            }
        }

        /// <summary>
        /// Read standard input from a <see cref="Stream"/> and
        /// send standard output to a file.
        /// </summary>
        /// <param name="inputStream">Take standard input from here.</param>
        /// <param name="outputPath">Send standard output to there.</param>
        /// <returns>Set when no error occured.</returns>
        public bool Run( Stream inputStream, string outputPath )
        {
            // Create stream
            Stream pOutput = new FileStream( outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 100000 );

            // With cleanup
            try
            {
                // Forward
                return Run( inputStream, pOutput );
            }
            finally
            {
                // Close
                pOutput.Close();
            }
        }

        /// <summary>
        /// Connect standard input and output to streams and
        /// execute the command line tool.
        /// </summary>
        /// <param name="inputStream">Take standard input from here.</param>
        /// <param name="outputStream">Send standard output to there.</param>
        /// <returns>Set when no error occured.</returns>
        public bool Run( Stream inputStream, Stream outputStream )
        {
            // Create helper
            Pipe pRedirect = new Pipe( outputStream );

            // Register copy handler
            OnOutput += pRedirect.Forward;

            // Forward
            return Run( inputStream );
        }

        /// <summary>
        /// Run a tool with standard input taken from a file.
        /// </summary>
        /// <param name="inputPath">Take standard input from here.</param>
        /// <returns>Set when no error occured.</returns>
        public bool Run( string inputPath )
        {
            // Create stream
            FileStream pInput = new FileStream( inputPath, FileMode.Open, FileAccess.Read, FileShare.Read, 100000 );

            // With cleanup
            try
            {
                // Forward
                return Run( pInput );
            }
            finally
            {
                // Cleanup
                pInput.Close();
            }
        }

        /// <summary>
        /// Run a tool with standard input taken from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="inputStream">Take standard input from here.</param>
        /// <returns>Set when no error occured.</returns>
        public bool Run( Stream inputStream )
        {
            // Create tool
            Stream pInput = Start();

            // With cleanup
            try
            {
                // Create buffer
                byte[] aBuf = new byte[100000];

                // Feed stream
                for (int lBytes; (lBytes = inputStream.Read( aBuf, 0, aBuf.Length )) > 0; )
                {
                    // Send to tool
                    pInput.Write( aBuf, 0, lBytes );
                }
            }
            catch
            {
                // Ignore any error - maybe partner has died
            }
            finally
            {
                // Finish
                pInput.Close();
            }

            // Report result
            return WaitForExit();
        }

        /// <summary>
        /// Connect all data coming from the indicated stream
        /// to the <see cref="OnError"/> dispatcher.
        /// </summary>
        /// <param name="errorStream">Standard error of the tool.</param>
        protected void ErrorReader( Stream errorStream )
        {
            // Forward
            RedirectStream( OnError, errorStream );
        }

        /// <summary>
        /// Connect all data coming from the indicated stream
        /// to the <see cref="OnOutput"/> dispatcher.
        /// </summary>
        /// <param name="outputStream">Standard output of the tool.</param>
        protected void OutputReader( Stream outputStream )
        {
            // Forward
            RedirectStream( OnOutput, outputStream );
        }

        /// <summary>
        /// Send the indicated data to the <see cref="OnError"/>
        /// event.
        /// </summary>
        /// <param name="data">Some buffer.</param>
        /// <param name="length">Number of bytes to send to the event.</param>
        protected void ErrorForwarder( byte[] data, int length )
        {
            // Forward
            if (null != OnError)
                OnError( data, length );
        }

        /// <summary>
        /// Send the indicated data to the <see cref="OnOutput"/>
        /// event.
        /// </summary>
        /// <param name="data">Some buffer.</param>
        /// <param name="length">Number of bytes to send to the event.</param>
        protected void OutputForwarder( byte[] data, int length )
        {
            // Forward
            if (null != OnOutput)
                OnOutput( data, length );
        }

        /// <summary>
        /// Read a stream and forwards all data to the indicated
        /// delegate.
        /// </summary>
        /// <param name="target">The receiving callback.</param>
        /// <param name="source">The input data <see cref="Stream"/>.</param>
        private static void RedirectStream( RedirectHandler target, Stream source )
        {
            // Buffer
            byte[] aBuf = new byte[100000];

            // Stop on any error
            try
            {
                // As long as necessary
                for (int nBytes = 0; (nBytes = source.Read( aBuf, 0, aBuf.Length )) > 0; )
                    if (null != target)
                        target( aBuf, nBytes );
            }
            catch
            {
                // Just ignore - partner may have died
            }

            // Send end code
            if (null != target)
                target( aBuf, 0 );
        }

        #region IDisposable Members

        /// <summary>
        /// Release all resources allocated.
        /// </summary>
        public virtual void Dispose()
        {
        }

        #endregion
    }
}
