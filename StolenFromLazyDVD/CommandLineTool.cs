using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace JMS.InterOp.CommandLine
{
    /// <summary>
    /// A command line tool abstraction which represents a single executable.
    /// </summary>
    public abstract class CommandLineTool : CommandBase
    {
        /// <summary>
        /// A default directory to locate the tool.
        /// </summary>
        /// <remarks>
        /// The code is somewhat clumpsy because it's only an extract
        /// from the LazyDVD project.
        /// </remarks>
        public static string PresetDirectory = null;

        /// <summary>
        /// A <see cref="Thread"/> serving the standard output
        /// of the tool.
        /// </summary>
        private Thread m_OutputThread = null;

        /// <summary>
        /// A <see cref="Thread"/> serving the standard error
        /// of the tool.
        /// </summary>
        private Thread m_ErrorThread = null;

        /// <summary>
        /// The <see cref="Process"/> instances associated with
        /// the command line tool.
        /// </summary>
        private Process m_Running = null;

        /// <summary>
        /// Initialize the base class.
        /// </summary>
        protected CommandLineTool()
        {
        }

        /// <summary>
        /// Must be implemented to set command line arguments.
        /// </summary>
        /// <param name="startInfo"></param>
        protected abstract void OnPrepareRun( ProcessStartInfo startInfo );

        /// <summary>
        /// A unique key for the command line tool - actually this
        /// is the name of the executable without the file name suffix.
        /// </summary>
        protected abstract string CommandKey { get; }

        /// <summary>
        /// Add a single argument to the command line.
        /// </summary>
        /// <param name="flag">The name of the option.</param>
        /// <param name="arg">The data of the option.</param>
        public void AddArgument( char flag, object arg )
        {
            // Create helper
            StringBuilder pAdd = new StringBuilder();

            // See if flag is provided
            if ('\0' != flag)
            {
                // Merge
                pAdd.Append( " -" );
                pAdd.Append( flag );
            }

            // Merge argument
            pAdd.Append( ' ' );
            pAdd.Append( arg );

            // Append
            m_Running.StartInfo.Arguments += pAdd.ToString();
        }

        /// <summary>
        /// Add a path to the command line.
        /// </summary>
        /// <param name="flag">The name of the option.</param>
        /// <param name="path">The path will be escaped properly.</param>
        public void AddPath( char flag, string path )
        {
            // Forward
            AddArgument( flag, "\"" + path.Replace( "\"", "\"\"" ) + "\"" );
        }

        /// <summary>
        /// Start the command line tool and report its standard input.
        /// </summary>
        /// <returns>Standard input.</returns>
        public override Stream Start()
        {
            // Already running
            if (null != m_Running)
                throw new InvalidOperationException( CuttyEnc.StringResources.Strings.ProcessRunning.Text );

            // Create a new process
            m_Running = new Process();

            // Configure statics
            m_Running.StartInfo.FileName = ToolPath;
            m_Running.StartInfo.CreateNoWindow = true;
            m_Running.StartInfo.UseShellExecute = false;
            m_Running.StartInfo.RedirectStandardInput = true;
            m_Running.StartInfo.RedirectStandardError = true;
            m_Running.StartInfo.RedirectStandardOutput = true;

            // Configure dynamics
            OnPrepareRun( m_Running.StartInfo );

            // Finally start it
            if (!m_Running.Start())
                throw new InvalidOperationException( CuttyEnc.StringResources.Strings.StartError.Text );

            // Create threads
            m_ErrorThread = new Thread( ErrorReader ) { Name = "CuttyEnc Error Thread", IsBackground = true };
            m_OutputThread = new Thread( OutputReader ) { Name = "CuttyEnc Output Thread", IsBackground = true };

            // Start threads
            m_ErrorThread.Start();
            m_OutputThread.Start();

            // Report input stream
            return m_Running.StandardInput.BaseStream;
        }

        /// <summary>
        /// Redirect to the standard error watchdog <see cref="ErrorReader"/>.
        /// </summary>
        private void ErrorReader()
        {
            // Forward
            ErrorReader( m_Running.StandardError.BaseStream );
        }

        /// <summary>
        /// Redirect to the standard output watchdog <see cref="OutputReader"/>.
        /// </summary>
        private void OutputReader()
        {
            // Forward
            OutputReader( m_Running.StandardOutput.BaseStream );
        }

        /// <summary>
        /// Get the full path to the executable.
        /// </summary>
        private string ToolPath
        {
            get
            {
                // Extend
                if (!PresetDirectory.EndsWith( @"\" )) 
                    PresetDirectory += @"\";

                // Report
                return PresetDirectory + CommandKey + ".exe";
            }
        }

        /// <summary>
        /// Wait for the command line tool to finish.
        /// </summary>
        /// <returns>Set when no error occured.</returns>
        public override bool WaitForExit()
        {
            // Be safe
            try
            {
                // Forward
                m_Running.WaitForExit();
            }
            catch
            {
                // Ignore any error
            }

            // Get error code
            return (0 == m_Running.ExitCode);
        }

        #region IDisposable Members

        /// <summary>
        /// Release all resources allocated.
        /// </summary>
        public override void Dispose()
        {
            // Hard terminate threads
            if (null != m_ErrorThread) 
                m_ErrorThread.Abort();
            if (null != m_OutputThread) 
                m_OutputThread.Abort();

            // Forward
            if (null != m_Running)
                m_Running.Dispose();

            // Call base class
            base.Dispose();
        }

        #endregion
    }
}
