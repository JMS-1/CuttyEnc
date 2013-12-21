namespace CuttyEnc
{
    /// <summary>
    /// Show the current log of the encoding process - actually
    /// the standard error from the call of the command line tools.
    /// </summary>
    public class EncodingError : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txLog;
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Create the dialog and load the contents of the standard
        /// error in the multiline text box.
        /// </summary>
        /// <param name="message">The collected error messages.</param>
        public EncodingError( string message )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // Prepare to use in a multi-line text box.
            //
            txLog.Text = message.Replace( "\r\n", "\n" ).Replace( "\r", "" ).Replace( "\n", "\r\n" );
        }

        /// <summary>
        /// Provider proper cleanup.
        /// </summary>
        /// <param name="disposing">Set on final shutdown.</param>
        protected override void Dispose( bool disposing )
        {
            // Check mode
            if (disposing)
            {
                // Forward call to children
                if (components != null) components.Dispose();
            }

            // Forward call to base class
            base.Dispose( disposing );
        }

        /// <summary>
        /// Create the extended error log message box and show
        /// it.
        /// </summary>
        /// <param name="message">The collected error messages.</param>
        public static void Show( string message )
        {
            // Process
            new EncodingError( message ).ShowDialog();
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof( EncodingError ) );
            this.txLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txLog
            // 
            this.txLog.AccessibleDescription = resources.GetString( "txLog.AccessibleDescription" );
            this.txLog.AccessibleName = resources.GetString( "txLog.AccessibleName" );
            this.txLog.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "txLog.Anchor" )));
            this.txLog.AutoSize = ((bool) (resources.GetObject( "txLog.AutoSize" )));
            this.txLog.BackgroundImage = ((System.Drawing.Image) (resources.GetObject( "txLog.BackgroundImage" )));
            this.txLog.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "txLog.Dock" )));
            this.txLog.Enabled = ((bool) (resources.GetObject( "txLog.Enabled" )));
            this.txLog.Font = ((System.Drawing.Font) (resources.GetObject( "txLog.Font" )));
            this.txLog.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "txLog.ImeMode" )));
            this.txLog.Location = ((System.Drawing.Point) (resources.GetObject( "txLog.Location" )));
            this.txLog.MaxLength = ((int) (resources.GetObject( "txLog.MaxLength" )));
            this.txLog.Multiline = ((bool) (resources.GetObject( "txLog.Multiline" )));
            this.txLog.Name = "txLog";
            this.txLog.PasswordChar = ((char) (resources.GetObject( "txLog.PasswordChar" )));
            this.txLog.ReadOnly = true;
            this.txLog.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "txLog.RightToLeft" )));
            this.txLog.ScrollBars = ((System.Windows.Forms.ScrollBars) (resources.GetObject( "txLog.ScrollBars" )));
            this.txLog.Size = ((System.Drawing.Size) (resources.GetObject( "txLog.Size" )));
            this.txLog.TabIndex = ((int) (resources.GetObject( "txLog.TabIndex" )));
            this.txLog.Text = resources.GetString( "txLog.Text" );
            this.txLog.TextAlign = ((System.Windows.Forms.HorizontalAlignment) (resources.GetObject( "txLog.TextAlign" )));
            this.txLog.Visible = ((bool) (resources.GetObject( "txLog.Visible" )));
            this.txLog.WordWrap = ((bool) (resources.GetObject( "txLog.WordWrap" )));
            // 
            // EncodingError
            // 
            this.AccessibleDescription = resources.GetString( "$this.AccessibleDescription" );
            this.AccessibleName = resources.GetString( "$this.AccessibleName" );
            this.AutoScaleBaseSize = ((System.Drawing.Size) (resources.GetObject( "$this.AutoScaleBaseSize" )));
            this.AutoScroll = ((bool) (resources.GetObject( "$this.AutoScroll" )));
            this.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject( "$this.AutoScrollMargin" )));
            this.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject( "$this.AutoScrollMinSize" )));
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject( "$this.BackgroundImage" )));
            this.ClientSize = ((System.Drawing.Size) (resources.GetObject( "$this.ClientSize" )));
            this.Controls.Add( this.txLog );
            this.Enabled = ((bool) (resources.GetObject( "$this.Enabled" )));
            this.Font = ((System.Drawing.Font) (resources.GetObject( "$this.Font" )));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject( "$this.Icon" )));
            this.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "$this.ImeMode" )));
            this.Location = ((System.Drawing.Point) (resources.GetObject( "$this.Location" )));
            this.MaximumSize = ((System.Drawing.Size) (resources.GetObject( "$this.MaximumSize" )));
            this.MinimumSize = ((System.Drawing.Size) (resources.GetObject( "$this.MinimumSize" )));
            this.Name = "EncodingError";
            this.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "$this.RightToLeft" )));
            this.StartPosition = ((System.Windows.Forms.FormStartPosition) (resources.GetObject( "$this.StartPosition" )));
            this.Text = resources.GetString( "$this.Text" );
            this.ResumeLayout( false );

        }
        #endregion
    }
}
