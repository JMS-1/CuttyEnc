namespace CuttyEnc
{
    /// <summary>
    /// Dummy control holding string resources used for exceptions
    /// and message boxes.
    /// </summary>
    public class StringResources : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// The one and only instance
        /// </summary>
        public static readonly StringResources Strings = new StringResources();

        public System.Windows.Forms.Label DirectoryChooser;
        public System.Windows.Forms.Label BadDirectoryMessage;
        public System.Windows.Forms.Label BadDirectoryTitle;
        public System.Windows.Forms.Label SaveError;
        public System.Windows.Forms.Label BadEncoding;
        public System.Windows.Forms.Label StartEncoding;
        public System.Windows.Forms.Label EncodingFailed;
        public System.Windows.Forms.Label BadVideoNorm;
        public System.Windows.Forms.Label BadAspect;
        public System.Windows.Forms.Label BadAVIFile;
        public System.Windows.Forms.Label ProcessRunning;
        public System.Windows.Forms.Label StartError;
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Create a dummy instance.
        /// </summary>
        public StringResources()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call

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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof( StringResources ) );
            this.DirectoryChooser = new System.Windows.Forms.Label();
            this.BadDirectoryMessage = new System.Windows.Forms.Label();
            this.BadDirectoryTitle = new System.Windows.Forms.Label();
            this.SaveError = new System.Windows.Forms.Label();
            this.BadEncoding = new System.Windows.Forms.Label();
            this.StartEncoding = new System.Windows.Forms.Label();
            this.EncodingFailed = new System.Windows.Forms.Label();
            this.BadVideoNorm = new System.Windows.Forms.Label();
            this.BadAspect = new System.Windows.Forms.Label();
            this.BadAVIFile = new System.Windows.Forms.Label();
            this.ProcessRunning = new System.Windows.Forms.Label();
            this.StartError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DirectoryChooser
            // 
            this.DirectoryChooser.AccessibleDescription = resources.GetString( "DirectoryChooser.AccessibleDescription" );
            this.DirectoryChooser.AccessibleName = resources.GetString( "DirectoryChooser.AccessibleName" );
            this.DirectoryChooser.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "DirectoryChooser.Anchor" )));
            this.DirectoryChooser.AutoSize = ((bool) (resources.GetObject( "DirectoryChooser.AutoSize" )));
            this.DirectoryChooser.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "DirectoryChooser.Dock" )));
            this.DirectoryChooser.Enabled = ((bool) (resources.GetObject( "DirectoryChooser.Enabled" )));
            this.DirectoryChooser.Font = ((System.Drawing.Font) (resources.GetObject( "DirectoryChooser.Font" )));
            this.DirectoryChooser.Image = ((System.Drawing.Image) (resources.GetObject( "DirectoryChooser.Image" )));
            this.DirectoryChooser.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "DirectoryChooser.ImageAlign" )));
            this.DirectoryChooser.ImageIndex = ((int) (resources.GetObject( "DirectoryChooser.ImageIndex" )));
            this.DirectoryChooser.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "DirectoryChooser.ImeMode" )));
            this.DirectoryChooser.Location = ((System.Drawing.Point) (resources.GetObject( "DirectoryChooser.Location" )));
            this.DirectoryChooser.Name = "DirectoryChooser";
            this.DirectoryChooser.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "DirectoryChooser.RightToLeft" )));
            this.DirectoryChooser.Size = ((System.Drawing.Size) (resources.GetObject( "DirectoryChooser.Size" )));
            this.DirectoryChooser.TabIndex = ((int) (resources.GetObject( "DirectoryChooser.TabIndex" )));
            this.DirectoryChooser.Text = resources.GetString( "DirectoryChooser.Text" );
            this.DirectoryChooser.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "DirectoryChooser.TextAlign" )));
            this.DirectoryChooser.Visible = ((bool) (resources.GetObject( "DirectoryChooser.Visible" )));
            // 
            // BadDirectoryMessage
            // 
            this.BadDirectoryMessage.AccessibleDescription = resources.GetString( "BadDirectoryMessage.AccessibleDescription" );
            this.BadDirectoryMessage.AccessibleName = resources.GetString( "BadDirectoryMessage.AccessibleName" );
            this.BadDirectoryMessage.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "BadDirectoryMessage.Anchor" )));
            this.BadDirectoryMessage.AutoSize = ((bool) (resources.GetObject( "BadDirectoryMessage.AutoSize" )));
            this.BadDirectoryMessage.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "BadDirectoryMessage.Dock" )));
            this.BadDirectoryMessage.Enabled = ((bool) (resources.GetObject( "BadDirectoryMessage.Enabled" )));
            this.BadDirectoryMessage.Font = ((System.Drawing.Font) (resources.GetObject( "BadDirectoryMessage.Font" )));
            this.BadDirectoryMessage.Image = ((System.Drawing.Image) (resources.GetObject( "BadDirectoryMessage.Image" )));
            this.BadDirectoryMessage.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadDirectoryMessage.ImageAlign" )));
            this.BadDirectoryMessage.ImageIndex = ((int) (resources.GetObject( "BadDirectoryMessage.ImageIndex" )));
            this.BadDirectoryMessage.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "BadDirectoryMessage.ImeMode" )));
            this.BadDirectoryMessage.Location = ((System.Drawing.Point) (resources.GetObject( "BadDirectoryMessage.Location" )));
            this.BadDirectoryMessage.Name = "BadDirectoryMessage";
            this.BadDirectoryMessage.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "BadDirectoryMessage.RightToLeft" )));
            this.BadDirectoryMessage.Size = ((System.Drawing.Size) (resources.GetObject( "BadDirectoryMessage.Size" )));
            this.BadDirectoryMessage.TabIndex = ((int) (resources.GetObject( "BadDirectoryMessage.TabIndex" )));
            this.BadDirectoryMessage.Text = resources.GetString( "BadDirectoryMessage.Text" );
            this.BadDirectoryMessage.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadDirectoryMessage.TextAlign" )));
            this.BadDirectoryMessage.Visible = ((bool) (resources.GetObject( "BadDirectoryMessage.Visible" )));
            // 
            // BadDirectoryTitle
            // 
            this.BadDirectoryTitle.AccessibleDescription = resources.GetString( "BadDirectoryTitle.AccessibleDescription" );
            this.BadDirectoryTitle.AccessibleName = resources.GetString( "BadDirectoryTitle.AccessibleName" );
            this.BadDirectoryTitle.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "BadDirectoryTitle.Anchor" )));
            this.BadDirectoryTitle.AutoSize = ((bool) (resources.GetObject( "BadDirectoryTitle.AutoSize" )));
            this.BadDirectoryTitle.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "BadDirectoryTitle.Dock" )));
            this.BadDirectoryTitle.Enabled = ((bool) (resources.GetObject( "BadDirectoryTitle.Enabled" )));
            this.BadDirectoryTitle.Font = ((System.Drawing.Font) (resources.GetObject( "BadDirectoryTitle.Font" )));
            this.BadDirectoryTitle.Image = ((System.Drawing.Image) (resources.GetObject( "BadDirectoryTitle.Image" )));
            this.BadDirectoryTitle.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadDirectoryTitle.ImageAlign" )));
            this.BadDirectoryTitle.ImageIndex = ((int) (resources.GetObject( "BadDirectoryTitle.ImageIndex" )));
            this.BadDirectoryTitle.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "BadDirectoryTitle.ImeMode" )));
            this.BadDirectoryTitle.Location = ((System.Drawing.Point) (resources.GetObject( "BadDirectoryTitle.Location" )));
            this.BadDirectoryTitle.Name = "BadDirectoryTitle";
            this.BadDirectoryTitle.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "BadDirectoryTitle.RightToLeft" )));
            this.BadDirectoryTitle.Size = ((System.Drawing.Size) (resources.GetObject( "BadDirectoryTitle.Size" )));
            this.BadDirectoryTitle.TabIndex = ((int) (resources.GetObject( "BadDirectoryTitle.TabIndex" )));
            this.BadDirectoryTitle.Text = resources.GetString( "BadDirectoryTitle.Text" );
            this.BadDirectoryTitle.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadDirectoryTitle.TextAlign" )));
            this.BadDirectoryTitle.Visible = ((bool) (resources.GetObject( "BadDirectoryTitle.Visible" )));
            // 
            // SaveError
            // 
            this.SaveError.AccessibleDescription = resources.GetString( "SaveError.AccessibleDescription" );
            this.SaveError.AccessibleName = resources.GetString( "SaveError.AccessibleName" );
            this.SaveError.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "SaveError.Anchor" )));
            this.SaveError.AutoSize = ((bool) (resources.GetObject( "SaveError.AutoSize" )));
            this.SaveError.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "SaveError.Dock" )));
            this.SaveError.Enabled = ((bool) (resources.GetObject( "SaveError.Enabled" )));
            this.SaveError.Font = ((System.Drawing.Font) (resources.GetObject( "SaveError.Font" )));
            this.SaveError.Image = ((System.Drawing.Image) (resources.GetObject( "SaveError.Image" )));
            this.SaveError.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "SaveError.ImageAlign" )));
            this.SaveError.ImageIndex = ((int) (resources.GetObject( "SaveError.ImageIndex" )));
            this.SaveError.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "SaveError.ImeMode" )));
            this.SaveError.Location = ((System.Drawing.Point) (resources.GetObject( "SaveError.Location" )));
            this.SaveError.Name = "SaveError";
            this.SaveError.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "SaveError.RightToLeft" )));
            this.SaveError.Size = ((System.Drawing.Size) (resources.GetObject( "SaveError.Size" )));
            this.SaveError.TabIndex = ((int) (resources.GetObject( "SaveError.TabIndex" )));
            this.SaveError.Text = resources.GetString( "SaveError.Text" );
            this.SaveError.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "SaveError.TextAlign" )));
            this.SaveError.Visible = ((bool) (resources.GetObject( "SaveError.Visible" )));
            // 
            // BadEncoding
            // 
            this.BadEncoding.AccessibleDescription = resources.GetString( "BadEncoding.AccessibleDescription" );
            this.BadEncoding.AccessibleName = resources.GetString( "BadEncoding.AccessibleName" );
            this.BadEncoding.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "BadEncoding.Anchor" )));
            this.BadEncoding.AutoSize = ((bool) (resources.GetObject( "BadEncoding.AutoSize" )));
            this.BadEncoding.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "BadEncoding.Dock" )));
            this.BadEncoding.Enabled = ((bool) (resources.GetObject( "BadEncoding.Enabled" )));
            this.BadEncoding.Font = ((System.Drawing.Font) (resources.GetObject( "BadEncoding.Font" )));
            this.BadEncoding.Image = ((System.Drawing.Image) (resources.GetObject( "BadEncoding.Image" )));
            this.BadEncoding.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadEncoding.ImageAlign" )));
            this.BadEncoding.ImageIndex = ((int) (resources.GetObject( "BadEncoding.ImageIndex" )));
            this.BadEncoding.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "BadEncoding.ImeMode" )));
            this.BadEncoding.Location = ((System.Drawing.Point) (resources.GetObject( "BadEncoding.Location" )));
            this.BadEncoding.Name = "BadEncoding";
            this.BadEncoding.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "BadEncoding.RightToLeft" )));
            this.BadEncoding.Size = ((System.Drawing.Size) (resources.GetObject( "BadEncoding.Size" )));
            this.BadEncoding.TabIndex = ((int) (resources.GetObject( "BadEncoding.TabIndex" )));
            this.BadEncoding.Text = resources.GetString( "BadEncoding.Text" );
            this.BadEncoding.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadEncoding.TextAlign" )));
            this.BadEncoding.Visible = ((bool) (resources.GetObject( "BadEncoding.Visible" )));
            // 
            // StartEncoding
            // 
            this.StartEncoding.AccessibleDescription = resources.GetString( "StartEncoding.AccessibleDescription" );
            this.StartEncoding.AccessibleName = resources.GetString( "StartEncoding.AccessibleName" );
            this.StartEncoding.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "StartEncoding.Anchor" )));
            this.StartEncoding.AutoSize = ((bool) (resources.GetObject( "StartEncoding.AutoSize" )));
            this.StartEncoding.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "StartEncoding.Dock" )));
            this.StartEncoding.Enabled = ((bool) (resources.GetObject( "StartEncoding.Enabled" )));
            this.StartEncoding.Font = ((System.Drawing.Font) (resources.GetObject( "StartEncoding.Font" )));
            this.StartEncoding.Image = ((System.Drawing.Image) (resources.GetObject( "StartEncoding.Image" )));
            this.StartEncoding.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "StartEncoding.ImageAlign" )));
            this.StartEncoding.ImageIndex = ((int) (resources.GetObject( "StartEncoding.ImageIndex" )));
            this.StartEncoding.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "StartEncoding.ImeMode" )));
            this.StartEncoding.Location = ((System.Drawing.Point) (resources.GetObject( "StartEncoding.Location" )));
            this.StartEncoding.Name = "StartEncoding";
            this.StartEncoding.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "StartEncoding.RightToLeft" )));
            this.StartEncoding.Size = ((System.Drawing.Size) (resources.GetObject( "StartEncoding.Size" )));
            this.StartEncoding.TabIndex = ((int) (resources.GetObject( "StartEncoding.TabIndex" )));
            this.StartEncoding.Text = resources.GetString( "StartEncoding.Text" );
            this.StartEncoding.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "StartEncoding.TextAlign" )));
            this.StartEncoding.Visible = ((bool) (resources.GetObject( "StartEncoding.Visible" )));
            // 
            // EncodingFailed
            // 
            this.EncodingFailed.AccessibleDescription = resources.GetString( "EncodingFailed.AccessibleDescription" );
            this.EncodingFailed.AccessibleName = resources.GetString( "EncodingFailed.AccessibleName" );
            this.EncodingFailed.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "EncodingFailed.Anchor" )));
            this.EncodingFailed.AutoSize = ((bool) (resources.GetObject( "EncodingFailed.AutoSize" )));
            this.EncodingFailed.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "EncodingFailed.Dock" )));
            this.EncodingFailed.Enabled = ((bool) (resources.GetObject( "EncodingFailed.Enabled" )));
            this.EncodingFailed.Font = ((System.Drawing.Font) (resources.GetObject( "EncodingFailed.Font" )));
            this.EncodingFailed.Image = ((System.Drawing.Image) (resources.GetObject( "EncodingFailed.Image" )));
            this.EncodingFailed.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "EncodingFailed.ImageAlign" )));
            this.EncodingFailed.ImageIndex = ((int) (resources.GetObject( "EncodingFailed.ImageIndex" )));
            this.EncodingFailed.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "EncodingFailed.ImeMode" )));
            this.EncodingFailed.Location = ((System.Drawing.Point) (resources.GetObject( "EncodingFailed.Location" )));
            this.EncodingFailed.Name = "EncodingFailed";
            this.EncodingFailed.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "EncodingFailed.RightToLeft" )));
            this.EncodingFailed.Size = ((System.Drawing.Size) (resources.GetObject( "EncodingFailed.Size" )));
            this.EncodingFailed.TabIndex = ((int) (resources.GetObject( "EncodingFailed.TabIndex" )));
            this.EncodingFailed.Text = resources.GetString( "EncodingFailed.Text" );
            this.EncodingFailed.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "EncodingFailed.TextAlign" )));
            this.EncodingFailed.Visible = ((bool) (resources.GetObject( "EncodingFailed.Visible" )));
            // 
            // BadVideoNorm
            // 
            this.BadVideoNorm.AccessibleDescription = resources.GetString( "BadVideoNorm.AccessibleDescription" );
            this.BadVideoNorm.AccessibleName = resources.GetString( "BadVideoNorm.AccessibleName" );
            this.BadVideoNorm.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "BadVideoNorm.Anchor" )));
            this.BadVideoNorm.AutoSize = ((bool) (resources.GetObject( "BadVideoNorm.AutoSize" )));
            this.BadVideoNorm.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "BadVideoNorm.Dock" )));
            this.BadVideoNorm.Enabled = ((bool) (resources.GetObject( "BadVideoNorm.Enabled" )));
            this.BadVideoNorm.Font = ((System.Drawing.Font) (resources.GetObject( "BadVideoNorm.Font" )));
            this.BadVideoNorm.Image = ((System.Drawing.Image) (resources.GetObject( "BadVideoNorm.Image" )));
            this.BadVideoNorm.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadVideoNorm.ImageAlign" )));
            this.BadVideoNorm.ImageIndex = ((int) (resources.GetObject( "BadVideoNorm.ImageIndex" )));
            this.BadVideoNorm.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "BadVideoNorm.ImeMode" )));
            this.BadVideoNorm.Location = ((System.Drawing.Point) (resources.GetObject( "BadVideoNorm.Location" )));
            this.BadVideoNorm.Name = "BadVideoNorm";
            this.BadVideoNorm.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "BadVideoNorm.RightToLeft" )));
            this.BadVideoNorm.Size = ((System.Drawing.Size) (resources.GetObject( "BadVideoNorm.Size" )));
            this.BadVideoNorm.TabIndex = ((int) (resources.GetObject( "BadVideoNorm.TabIndex" )));
            this.BadVideoNorm.Text = resources.GetString( "BadVideoNorm.Text" );
            this.BadVideoNorm.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadVideoNorm.TextAlign" )));
            this.BadVideoNorm.Visible = ((bool) (resources.GetObject( "BadVideoNorm.Visible" )));
            // 
            // BadAspect
            // 
            this.BadAspect.AccessibleDescription = resources.GetString( "BadAspect.AccessibleDescription" );
            this.BadAspect.AccessibleName = resources.GetString( "BadAspect.AccessibleName" );
            this.BadAspect.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "BadAspect.Anchor" )));
            this.BadAspect.AutoSize = ((bool) (resources.GetObject( "BadAspect.AutoSize" )));
            this.BadAspect.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "BadAspect.Dock" )));
            this.BadAspect.Enabled = ((bool) (resources.GetObject( "BadAspect.Enabled" )));
            this.BadAspect.Font = ((System.Drawing.Font) (resources.GetObject( "BadAspect.Font" )));
            this.BadAspect.Image = ((System.Drawing.Image) (resources.GetObject( "BadAspect.Image" )));
            this.BadAspect.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadAspect.ImageAlign" )));
            this.BadAspect.ImageIndex = ((int) (resources.GetObject( "BadAspect.ImageIndex" )));
            this.BadAspect.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "BadAspect.ImeMode" )));
            this.BadAspect.Location = ((System.Drawing.Point) (resources.GetObject( "BadAspect.Location" )));
            this.BadAspect.Name = "BadAspect";
            this.BadAspect.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "BadAspect.RightToLeft" )));
            this.BadAspect.Size = ((System.Drawing.Size) (resources.GetObject( "BadAspect.Size" )));
            this.BadAspect.TabIndex = ((int) (resources.GetObject( "BadAspect.TabIndex" )));
            this.BadAspect.Text = resources.GetString( "BadAspect.Text" );
            this.BadAspect.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadAspect.TextAlign" )));
            this.BadAspect.Visible = ((bool) (resources.GetObject( "BadAspect.Visible" )));
            // 
            // BadAVIFile
            // 
            this.BadAVIFile.AccessibleDescription = resources.GetString( "BadAVIFile.AccessibleDescription" );
            this.BadAVIFile.AccessibleName = resources.GetString( "BadAVIFile.AccessibleName" );
            this.BadAVIFile.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "BadAVIFile.Anchor" )));
            this.BadAVIFile.AutoSize = ((bool) (resources.GetObject( "BadAVIFile.AutoSize" )));
            this.BadAVIFile.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "BadAVIFile.Dock" )));
            this.BadAVIFile.Enabled = ((bool) (resources.GetObject( "BadAVIFile.Enabled" )));
            this.BadAVIFile.Font = ((System.Drawing.Font) (resources.GetObject( "BadAVIFile.Font" )));
            this.BadAVIFile.Image = ((System.Drawing.Image) (resources.GetObject( "BadAVIFile.Image" )));
            this.BadAVIFile.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadAVIFile.ImageAlign" )));
            this.BadAVIFile.ImageIndex = ((int) (resources.GetObject( "BadAVIFile.ImageIndex" )));
            this.BadAVIFile.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "BadAVIFile.ImeMode" )));
            this.BadAVIFile.Location = ((System.Drawing.Point) (resources.GetObject( "BadAVIFile.Location" )));
            this.BadAVIFile.Name = "BadAVIFile";
            this.BadAVIFile.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "BadAVIFile.RightToLeft" )));
            this.BadAVIFile.Size = ((System.Drawing.Size) (resources.GetObject( "BadAVIFile.Size" )));
            this.BadAVIFile.TabIndex = ((int) (resources.GetObject( "BadAVIFile.TabIndex" )));
            this.BadAVIFile.Text = resources.GetString( "BadAVIFile.Text" );
            this.BadAVIFile.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "BadAVIFile.TextAlign" )));
            this.BadAVIFile.Visible = ((bool) (resources.GetObject( "BadAVIFile.Visible" )));
            // 
            // ProcessRunning
            // 
            this.ProcessRunning.AccessibleDescription = resources.GetString( "ProcessRunning.AccessibleDescription" );
            this.ProcessRunning.AccessibleName = resources.GetString( "ProcessRunning.AccessibleName" );
            this.ProcessRunning.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "ProcessRunning.Anchor" )));
            this.ProcessRunning.AutoSize = ((bool) (resources.GetObject( "ProcessRunning.AutoSize" )));
            this.ProcessRunning.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "ProcessRunning.Dock" )));
            this.ProcessRunning.Enabled = ((bool) (resources.GetObject( "ProcessRunning.Enabled" )));
            this.ProcessRunning.Font = ((System.Drawing.Font) (resources.GetObject( "ProcessRunning.Font" )));
            this.ProcessRunning.Image = ((System.Drawing.Image) (resources.GetObject( "ProcessRunning.Image" )));
            this.ProcessRunning.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "ProcessRunning.ImageAlign" )));
            this.ProcessRunning.ImageIndex = ((int) (resources.GetObject( "ProcessRunning.ImageIndex" )));
            this.ProcessRunning.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "ProcessRunning.ImeMode" )));
            this.ProcessRunning.Location = ((System.Drawing.Point) (resources.GetObject( "ProcessRunning.Location" )));
            this.ProcessRunning.Name = "ProcessRunning";
            this.ProcessRunning.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "ProcessRunning.RightToLeft" )));
            this.ProcessRunning.Size = ((System.Drawing.Size) (resources.GetObject( "ProcessRunning.Size" )));
            this.ProcessRunning.TabIndex = ((int) (resources.GetObject( "ProcessRunning.TabIndex" )));
            this.ProcessRunning.Text = resources.GetString( "ProcessRunning.Text" );
            this.ProcessRunning.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "ProcessRunning.TextAlign" )));
            this.ProcessRunning.Visible = ((bool) (resources.GetObject( "ProcessRunning.Visible" )));
            // 
            // StartError
            // 
            this.StartError.AccessibleDescription = resources.GetString( "StartError.AccessibleDescription" );
            this.StartError.AccessibleName = resources.GetString( "StartError.AccessibleName" );
            this.StartError.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject( "StartError.Anchor" )));
            this.StartError.AutoSize = ((bool) (resources.GetObject( "StartError.AutoSize" )));
            this.StartError.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject( "StartError.Dock" )));
            this.StartError.Enabled = ((bool) (resources.GetObject( "StartError.Enabled" )));
            this.StartError.Font = ((System.Drawing.Font) (resources.GetObject( "StartError.Font" )));
            this.StartError.Image = ((System.Drawing.Image) (resources.GetObject( "StartError.Image" )));
            this.StartError.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "StartError.ImageAlign" )));
            this.StartError.ImageIndex = ((int) (resources.GetObject( "StartError.ImageIndex" )));
            this.StartError.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "StartError.ImeMode" )));
            this.StartError.Location = ((System.Drawing.Point) (resources.GetObject( "StartError.Location" )));
            this.StartError.Name = "StartError";
            this.StartError.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "StartError.RightToLeft" )));
            this.StartError.Size = ((System.Drawing.Size) (resources.GetObject( "StartError.Size" )));
            this.StartError.TabIndex = ((int) (resources.GetObject( "StartError.TabIndex" )));
            this.StartError.Text = resources.GetString( "StartError.Text" );
            this.StartError.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject( "StartError.TextAlign" )));
            this.StartError.Visible = ((bool) (resources.GetObject( "StartError.Visible" )));
            // 
            // StringResources
            // 
            this.AccessibleDescription = resources.GetString( "$this.AccessibleDescription" );
            this.AccessibleName = resources.GetString( "$this.AccessibleName" );
            this.AutoScroll = ((bool) (resources.GetObject( "$this.AutoScroll" )));
            this.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject( "$this.AutoScrollMargin" )));
            this.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject( "$this.AutoScrollMinSize" )));
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject( "$this.BackgroundImage" )));
            this.Controls.Add( this.SaveError );
            this.Controls.Add( this.BadDirectoryTitle );
            this.Controls.Add( this.BadDirectoryMessage );
            this.Controls.Add( this.DirectoryChooser );
            this.Controls.Add( this.BadEncoding );
            this.Controls.Add( this.StartEncoding );
            this.Controls.Add( this.EncodingFailed );
            this.Controls.Add( this.BadVideoNorm );
            this.Controls.Add( this.BadAspect );
            this.Controls.Add( this.BadAVIFile );
            this.Controls.Add( this.ProcessRunning );
            this.Controls.Add( this.StartError );
            this.Enabled = ((bool) (resources.GetObject( "$this.Enabled" )));
            this.Font = ((System.Drawing.Font) (resources.GetObject( "$this.Font" )));
            this.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject( "$this.ImeMode" )));
            this.Location = ((System.Drawing.Point) (resources.GetObject( "$this.Location" )));
            this.Name = "StringResources";
            this.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject( "$this.RightToLeft" )));
            this.Size = ((System.Drawing.Size) (resources.GetObject( "$this.Size" )));
            this.Load += new System.EventHandler( this.StringResources_Load );
            this.ResumeLayout( false );

        }
        #endregion

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void StringResources_Load( object sender, System.EventArgs e )
        {

        }
    }
}
