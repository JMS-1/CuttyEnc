using System;
using System.IO;
using System.Collections.Generic;

namespace JMS.InterOp.CommandLine
{
    /// <summary>
    /// Execute a piped list of command line tools.
    /// </summary>
    public class ChainExecuter : CommandBase
    {
        /// <summary>
        /// Ordered collection of the tools.
        /// </summary>
        private List<CommandLineTool> m_Tools = new List<CommandLineTool>();

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public ChainExecuter()
        {
        }

        /// <summary>
        /// Add a command line tool to the end of the pipe
        /// chain.
        /// </summary>
        /// <param name="someTool">New last tool.</param>
        public void Add( CommandLineTool someTool )
        {
            // Verify
            if (null == someTool)
                throw new ArgumentNullException( "someTool" );

            // Remember
            m_Tools.Add( someTool );
        }

        /// <summary>
        /// Start all tools and report the standard input of
        /// the first tool.
        /// </summary>
        /// <returns>Standard input of the first tool which must
        /// be closed by the caller.</returns>
        public override Stream Start()
        {
            // Last stream in use
            Stream pPrev = null;

            // Start last one first
            for (int ix = m_Tools.Count; ix-- > 0; )
            {
                // Attach
                CommandLineTool pTool = m_Tools[ix];

                // Register error
                pTool.OnError += ErrorForwarder;

                // Create forwarder
                if (null != pPrev)
                {
                    // Create a pipe
                    Pipe pPipe = new Pipe( pPrev );

                    // Attach to output
                    pTool.OnOutput += pPipe.Forward;
                }
                else
                {
                    // Use our forwarder
                    pTool.OnOutput += OutputForwarder;
                }

                // Remember
                pPrev = pTool.Start();
            }

            // Report outer stream
            return pPrev;
        }

        /// <summary>
        /// Wait for all command line tools in the pipe chain
        /// to finish.
        /// </summary>
        /// <returns>Set if no error occured.</returns>
        public override bool WaitForExit()
        {
            // Result
            bool bInError = false;

            // In order
            foreach (CommandLineTool pTool in m_Tools)
                if (!pTool.WaitForExit())
                    bInError = true;

            // Report
            return !bInError;
        }

        #region IDisposable Members

        /// <summary>
        /// Release all resources by forwarding the call to
        /// call command line tools in the pipe chain.
        /// </summary>
        public override void Dispose()
        {
            // Forward
            foreach (CommandLineTool pTool in m_Tools)
                pTool.Dispose();

            // Call base class
            base.Dispose();
        }

        #endregion
    }
}
