using System;
using System.IO;
using System.Windows.Forms;

namespace CuttyEnc
{
    /// <summary>
    /// This is the configuration dialog for the CuttyEnc provider.
    /// </summary>
    public class Configuration : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txDir;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.CheckBox ckDebug;
        private System.Windows.Forms.LinkLabel cuttyEncHome;
        private System.Windows.Forms.ToolTip tips;

        /// <summary>
        /// All settings are stored in a typed <see cref="DataSet"/>.
        /// </summary>
        public readonly Settings Settings = new Settings();

        /// <summary>
        /// Create a new configuration dialog.
        /// </summary>
        public Configuration()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof( Configuration ) );
            this.txDir = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckDebug = new System.Windows.Forms.CheckBox();
            this.cuttyEncHome = new System.Windows.Forms.LinkLabel();
            this.tips = new System.Windows.Forms.ToolTip( this.components );
            this.SuspendLayout();
            // 
            // txDir
            // 
            this.txDir.AccessibleDescription = resources.GetString( "txDir.AccessibleDescription" );
            this.txDir.AccessibleName = resources.GetString( "txDir.AccessibleName" );
            this.txDir.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "txDir.Anchor" )));
            this.txDir.AutoSize = ((bool) (resources.GetObject( "txDir.AutoSize" )));
            this.txDir.BackgroundImage = ((System.Drawing.Image) (resources.GetObject( "txDir.BackgroundImage" )));
            this.txDir.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "txDir.Dock" )));
            this.txDir.Enabled = ((bool) (resources.GetObject( "txDir.Enabled" )));
            this.txDir.Font = ((System.Drawing.Font) (resources.GetObject( "txDir.Font" )));
            this.txDir.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "txDir.ImeMode" )));
            this.txDir.Location = ((System.Drawing.Point) (resources.GetObject( "txDir.Location" )));
            this.txDir.MaxLength = ((int) (resources.GetObject( "txDir.MaxLength" )));
            this.txDir.Multiline = ((bool) (resources.GetObject( "txDir.Multiline" )));
            this.txDir.Name = "txDir";
            this.txDir.PasswordChar = ((char) (resources.GetObject( "txDir.PasswordChar" )));
            this.txDir.ReadOnly = true;
            this.txDir.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "txDir.RightToLeft" )));
            this.txDir.ScrollBars = ((System.Windows.Forms.ScrollBars) (resources.GetObject( "txDir.ScrollBars" )));
            this.txDir.Size = ((System.Drawing.Size) (resources.GetObject( "txDir.Size" )));
            this.txDir.TabIndex = ((int) (resources.GetObject( "txDir.TabIndex" )));
            this.txDir.Text = resources.GetString( "txDir.Text" );
            this.txDir.TextAlign = ((System.Windows.Forms.HorizontalAlignment) (resources.GetObject( "txDir.TextAlign" )));
            this.tips.SetToolTip( this.txDir, resources.GetString( "txDir.ToolTip" ) );
            this.txDir.Visible = ((bool) (resources.GetObject( "txDir.Visible" )));
            this.txDir.WordWrap = ((bool) (resources.GetObject( "txDir.WordWrap" )));
            this.txDir.DoubleClick += new System.EventHandler( this.txDir_DoubleClick );
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = resources.GetString( "btnSave.AccessibleDescription" );
            this.btnSave.AccessibleName = resources.GetString( "btnSave.AccessibleName" );
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "btnSave.Anchor" )));
            this.btnSave.BackgroundImage = ((System.Drawing.Image) (resources.GetObject( "btnSave.BackgroundImage" )));
            this.btnSave.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "btnSave.Dock" )));
            this.btnSave.Enabled = ((bool) (resources.GetObject( "btnSave.Enabled" )));
            this.btnSave.FlatStyle = ((System.Windows.Forms.FlatStyle) (resources.GetObject( "btnSave.FlatStyle" )));
            this.btnSave.Font = ((System.Drawing.Font) (resources.GetObject( "btnSave.Font" )));
            this.btnSave.Image = ((System.Drawing.Image) (resources.GetObject( "btnSave.Image" )));
            this.btnSave.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "btnSave.ImageAlign" )));
            this.btnSave.ImageIndex = ((int) (resources.GetObject( "btnSave.ImageIndex" )));
            this.btnSave.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "btnSave.ImeMode" )));
            this.btnSave.Location = ((System.Drawing.Point) (resources.GetObject( "btnSave.Location" )));
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "btnSave.RightToLeft" )));
            this.btnSave.Size = ((System.Drawing.Size) (resources.GetObject( "btnSave.Size" )));
            this.btnSave.TabIndex = ((int) (resources.GetObject( "btnSave.TabIndex" )));
            this.btnSave.Text = resources.GetString( "btnSave.Text" );
            this.btnSave.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "btnSave.TextAlign" )));
            this.tips.SetToolTip( this.btnSave, resources.GetString( "btnSave.ToolTip" ) );
            this.btnSave.Visible = ((bool) (resources.GetObject( "btnSave.Visible" )));
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = resources.GetString( "btnCancel.AccessibleDescription" );
            this.btnCancel.AccessibleName = resources.GetString( "btnCancel.AccessibleName" );
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "btnCancel.Anchor" )));
            this.btnCancel.BackgroundImage = ((System.Drawing.Image) (resources.GetObject( "btnCancel.BackgroundImage" )));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "btnCancel.Dock" )));
            this.btnCancel.Enabled = ((bool) (resources.GetObject( "btnCancel.Enabled" )));
            this.btnCancel.FlatStyle = ((System.Windows.Forms.FlatStyle) (resources.GetObject( "btnCancel.FlatStyle" )));
            this.btnCancel.Font = ((System.Drawing.Font) (resources.GetObject( "btnCancel.Font" )));
            this.btnCancel.Image = ((System.Drawing.Image) (resources.GetObject( "btnCancel.Image" )));
            this.btnCancel.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "btnCancel.ImageAlign" )));
            this.btnCancel.ImageIndex = ((int) (resources.GetObject( "btnCancel.ImageIndex" )));
            this.btnCancel.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "btnCancel.ImeMode" )));
            this.btnCancel.Location = ((System.Drawing.Point) (resources.GetObject( "btnCancel.Location" )));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "btnCancel.RightToLeft" )));
            this.btnCancel.Size = ((System.Drawing.Size) (resources.GetObject( "btnCancel.Size" )));
            this.btnCancel.TabIndex = ((int) (resources.GetObject( "btnCancel.TabIndex" )));
            this.btnCancel.Text = resources.GetString( "btnCancel.Text" );
            this.btnCancel.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "btnCancel.TextAlign" )));
            this.tips.SetToolTip( this.btnCancel, resources.GetString( "btnCancel.ToolTip" ) );
            this.btnCancel.Visible = ((bool) (resources.GetObject( "btnCancel.Visible" )));
            // 
            // ckDebug
            // 
            this.ckDebug.AccessibleDescription = resources.GetString( "ckDebug.AccessibleDescription" );
            this.ckDebug.AccessibleName = resources.GetString( "ckDebug.AccessibleName" );
            this.ckDebug.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "ckDebug.Anchor" )));
            this.ckDebug.Appearance = ((System.Windows.Forms.Appearance) (resources.GetObject( "ckDebug.Appearance" )));
            this.ckDebug.BackgroundImage = ((System.Drawing.Image) (resources.GetObject( "ckDebug.BackgroundImage" )));
            this.ckDebug.CheckAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "ckDebug.CheckAlign" )));
            this.ckDebug.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "ckDebug.Dock" )));
            this.ckDebug.Enabled = ((bool) (resources.GetObject( "ckDebug.Enabled" )));
            this.ckDebug.FlatStyle = ((System.Windows.Forms.FlatStyle) (resources.GetObject( "ckDebug.FlatStyle" )));
            this.ckDebug.Font = ((System.Drawing.Font) (resources.GetObject( "ckDebug.Font" )));
            this.ckDebug.Image = ((System.Drawing.Image) (resources.GetObject( "ckDebug.Image" )));
            this.ckDebug.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "ckDebug.ImageAlign" )));
            this.ckDebug.ImageIndex = ((int) (resources.GetObject( "ckDebug.ImageIndex" )));
            this.ckDebug.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "ckDebug.ImeMode" )));
            this.ckDebug.Location = ((System.Drawing.Point) (resources.GetObject( "ckDebug.Location" )));
            this.ckDebug.Name = "ckDebug";
            this.ckDebug.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "ckDebug.RightToLeft" )));
            this.ckDebug.Size = ((System.Drawing.Size) (resources.GetObject( "ckDebug.Size" )));
            this.ckDebug.TabIndex = ((int) (resources.GetObject( "ckDebug.TabIndex" )));
            this.ckDebug.Text = resources.GetString( "ckDebug.Text" );
            this.ckDebug.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "ckDebug.TextAlign" )));
            this.tips.SetToolTip( this.ckDebug, resources.GetString( "ckDebug.ToolTip" ) );
            this.ckDebug.Visible = ((bool) (resources.GetObject( "ckDebug.Visible" )));
            this.ckDebug.CheckedChanged += new System.EventHandler( this.ckDebug_CheckedChanged );
            // 
            // cuttyEncHome
            // 
            this.cuttyEncHome.AccessibleDescription = resources.GetString( "cuttyEncHome.AccessibleDescription" );
            this.cuttyEncHome.AccessibleName = resources.GetString( "cuttyEncHome.AccessibleName" );
            this.cuttyEncHome.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "cuttyEncHome.Anchor" )));
            this.cuttyEncHome.AutoSize = ((bool) (resources.GetObject( "cuttyEncHome.AutoSize" )));
            this.cuttyEncHome.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "cuttyEncHome.Dock" )));
            this.cuttyEncHome.Enabled = ((bool) (resources.GetObject( "cuttyEncHome.Enabled" )));
            this.cuttyEncHome.Font = ((System.Drawing.Font) (resources.GetObject( "cuttyEncHome.Font" )));
            this.cuttyEncHome.Image = ((System.Drawing.Image) (resources.GetObject( "cuttyEncHome.Image" )));
            this.cuttyEncHome.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "cuttyEncHome.ImageAlign" )));
            this.cuttyEncHome.ImageIndex = ((int) (resources.GetObject( "cuttyEncHome.ImageIndex" )));
            this.cuttyEncHome.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "cuttyEncHome.ImeMode" )));
            this.cuttyEncHome.LinkArea = ((System.Windows.Forms.LinkArea) (resources.GetObject( "cuttyEncHome.LinkArea" )));
            this.cuttyEncHome.Location = ((System.Drawing.Point) (resources.GetObject( "cuttyEncHome.Location" )));
            this.cuttyEncHome.Name = "cuttyEncHome";
            this.cuttyEncHome.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "cuttyEncHome.RightToLeft" )));
            this.cuttyEncHome.Size = ((System.Drawing.Size) (resources.GetObject( "cuttyEncHome.Size" )));
            this.cuttyEncHome.TabIndex = ((int) (resources.GetObject( "cuttyEncHome.TabIndex" )));
            this.cuttyEncHome.TabStop = true;
            this.cuttyEncHome.Text = resources.GetString( "cuttyEncHome.Text" );
            this.cuttyEncHome.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "cuttyEncHome.TextAlign" )));
            this.tips.SetToolTip( this.cuttyEncHome, resources.GetString( "cuttyEncHome.ToolTip" ) );
            this.cuttyEncHome.Visible = ((bool) (resources.GetObject( "cuttyEncHome.Visible" )));
            this.cuttyEncHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.cuttyEncHome_LinkClicked );
            // 
            // Configuration
            // 
            this.AccessibleDescription = resources.GetString( "$this.AccessibleDescription" );
            this.AccessibleName = resources.GetString( "$this.AccessibleName" );
            this.AutoScaleBaseSize = ((System.Drawing.Size) (resources.GetObject( "$this.AutoScaleBaseSize" )));
            this.AutoScroll = ((bool) (resources.GetObject( "$this.AutoScroll" )));
            this.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject( "$this.AutoScrollMargin" )));
            this.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject( "$this.AutoScrollMinSize" )));
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject( "$this.BackgroundImage" )));
            this.CancelButton = this.btnCancel;
            this.ClientSize = ((System.Drawing.Size) (resources.GetObject( "$this.ClientSize" )));
            this.ControlBox = false;
            this.Controls.Add( this.cuttyEncHome );
            this.Controls.Add( this.ckDebug );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnSave );
            this.Controls.Add( this.txDir );
            this.Enabled = ((bool) (resources.GetObject( "$this.Enabled" )));
            this.Font = ((System.Drawing.Font) (resources.GetObject( "$this.Font" )));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject( "$this.Icon" )));
            this.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "$this.ImeMode" )));
            this.Location = ((System.Drawing.Point) (resources.GetObject( "$this.Location" )));
            this.MaximizeBox = false;
            this.MaximumSize = ((System.Drawing.Size) (resources.GetObject( "$this.MaximumSize" )));
            this.MinimizeBox = false;
            this.MinimumSize = ((System.Drawing.Size) (resources.GetObject( "$this.MinimumSize" )));
            this.Name = "Configuration";
            this.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "$this.RightToLeft" )));
            this.StartPosition = ((System.Windows.Forms.FormStartPosition) (resources.GetObject( "$this.StartPosition" )));
            this.Text = resources.GetString( "$this.Text" );
            this.tips.SetToolTip( this, resources.GetString( "$this.ToolTip" ) );
            this.Load += new System.EventHandler( this.Configuration_Load );
            this.ResumeLayout( false );

        }
        #endregion

        /// <summary>
        /// Load the settings from the configuration file. Initially
        /// the directory is not set and the related text box filled
        /// with some instructions of use.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void Configuration_Load( object sender, System.EventArgs e )
        {
            // Add version
            Text = Text + " (CuttyEnc " + GetType().Assembly.GetName().Version + ")";

            // Load directory
            string sDir = Settings.Directory;

            // Check
            if (null != sDir) txDir.Text = sDir;

            // Load other
            ckDebug.Checked = Settings.DebugOutput;

            // Enable GUI
            btnSave.Enabled = false;
        }

        /// <summary>
        /// The directory chooser is activated when the directory text box
        /// field is double clicked.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void txDir_DoubleClick( object sender, System.EventArgs e )
        {
            // Create helper dialog
            FolderBrowserDialog pDlg = new FolderBrowserDialog();

            // Configure
            pDlg.Description = StringResources.Strings.DirectoryChooser.Text;
            pDlg.SelectedPath = txDir.Text.StartsWith( "(" ) ? null : txDir.Text;
            pDlg.ShowNewFolderButton = false;

            // Select
            if (DialogResult.OK != pDlg.ShowDialog( this )) return;

            // Test it
            FileInfo pEXE = new FileInfo( Path.Combine( pDlg.SelectedPath, "mpeg2enc.exe" ) );

            // Must both exists
            if (!pEXE.Exists)
            {
                // Report the error
                MessageBox.Show( this, StringResources.Strings.BadDirectoryMessage.Text, StringResources.Strings.BadDirectoryTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }

            // Update
            txDir.Text = pDlg.SelectedPath;

            // Store to configuration
            Settings.Directory = txDir.Text;

            // Update GUI
            btnSave.Enabled = true;
        }

        /// <summary>
        /// Stores the current configuration back to the configuration
        /// file and closes the dialog. The button will be enabled as soon 
        /// as there is some change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click( object sender, System.EventArgs e )
        {
            // Try to save
            try
            {
                // Process
                Settings.Save();

                // Did it
                DialogResult = DialogResult.OK;

                // Done
                Close();
            }
            catch (Exception ex)
            {
                // Report
                MessageBox.Show( this, ex.Message, StringResources.Strings.SaveError.Text );
            }
        }

        /// <summary>
        /// Copy the actual setting back to the configuration and
        /// enable the save button.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ckDebug_CheckedChanged( object sender, System.EventArgs e )
        {
            // Remember new value
            Settings.DebugOutput = ckDebug.Checked;

            // Enable GUI
            btnSave.Enabled = true;
        }

        private void cuttyEncHome_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            // Start silently
            try
            {
                // Run the link
                System.Diagnostics.Process.Start( cuttyEncHome.Text );
            }
            catch
            {
            }
        }
    }
}
