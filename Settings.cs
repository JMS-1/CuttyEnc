using System;
using System.Data;

namespace CuttyEnc
{
    /// <summary>
    /// Typed <see cref="DataSet"/> holding the configuration.
    /// </summary>
    public class Settings : DataSet
    {
        /// <summary>
        /// The directory to the MPEG2Enc tool.
        /// </summary>
        private const string COL_Directory = "Directory";

        /// <summary>
        /// Set to let MPEG2Enc decide the GOP size.
        /// </summary>
        private const string COL_UseFullGOP = "UnconstraintGOP";

        /// <summary>
        /// Set to always show the log of the encoding process -
        /// and not only in the case of errors.
        /// </summary>
        private const string COL_DebugOutput = "AlwaysShowLog";

        /// <summary>
        /// The number of time the MPEG2Enc call should be repeated.
        /// </summary>
        /// <remarks>
        /// Currently not implemented. CYGWIN tends to report shared
        /// version errors from time to time.
        /// </remarks>
        private const string COL_RetryCount = "AutoRetries";

        /// <summary>
        /// Set to light up the input to MPEG2Enc a bit.
        /// </summary>
        private const string COL_Brightness = "CorrectBrightness";

        /// <summary>
        /// Create a new configuration set and load it from
        /// the file if possible.
        /// </summary>
        public Settings()
            : base( "CuttyEncSettings" )
        {
            // One table
            DataTable pTable = Tables.Add( "Configuration" );

            // Columns
            pTable.Columns.Add( COL_Directory, typeof( string ) );
            pTable.Columns.Add( COL_UseFullGOP, typeof( bool ) );
            pTable.Columns.Add( COL_DebugOutput, typeof( bool ) );
            pTable.Columns.Add( COL_RetryCount, typeof( int ) );
            pTable.Columns.Add( COL_Brightness, typeof( bool ) );

            // Try to load
            try
            {
                // Load it
                ReadXml( SettingsPath, XmlReadMode.IgnoreSchema );
            }
            catch
            {
                // Clear
                pTable.Rows.Clear();

                // Add the one and only row
                pTable.Rows.Add( new object[pTable.Columns.Count] );
            }

            // Freeze state
            AcceptChanges();
        }

        /// <summary>
        /// The configuration file lives in the same directory
        /// as this assembly. The file name is <i>CuttyEnc.settings</i>.
        /// </summary>
        internal static string SettingsPath
        {
            get
            {
                // Path to us
                string sCodeBase = typeof( Settings ).Assembly.CodeBase;

                // Correct
                sCodeBase = sCodeBase.Substring( 8 ).Replace( '/', '\\' );

                // Split off
                return sCodeBase.Substring( 0, sCodeBase.LastIndexOf( '\\' ) ) + @"\CuttyEnc.settings";
            }
        }

        /// <summary>
        /// The directory to the MPEG2Enc tool.
        /// </summary>
        public string Directory
        {
            get
            {
                // Read
                object value = TheRow[COL_Directory];

                // Report
                return (DBNull.Value == value) ? null : (string) value;
            }
            set
            {
                // Update
                TheRow[COL_Directory] = value;
            }
        }

        /// <summary>
        /// The number of time the MPEG2Enc call should be repeated.
        /// </summary>
        /// <remarks>
        /// Not yet implemented.
        /// </remarks>
        public int NumberOfRetries
        {
            get
            {
                // Read
                object value = TheRow[COL_RetryCount];

                // Report
                return (DBNull.Value == value) ? 0 : (int) value;
            }
            set
            {
                // Update
                TheRow[COL_RetryCount] = value;
            }
        }

        /// <summary>
        /// Set to always show the log of the encoding process -
        /// and not only in the case of errors.
        /// </summary>
        public bool DebugOutput
        {
            get
            {
                // Read
                object value = TheRow[COL_DebugOutput];

                // Report
                return (DBNull.Value == value) ? false : (bool) value;
            }
            set
            {
                // Update
                TheRow[COL_DebugOutput] = value;
            }
        }

        /// <summary>
        /// Set to let MPEG2Enc decide the GOP size.
        /// </summary>
        public bool UnrestrictedGOP
        {
            get
            {
                // Read
                object value = TheRow[COL_UseFullGOP];

                // Report
                return (DBNull.Value == value) ? true : (bool) value;
            }
            set
            {
                // Update
                TheRow[COL_UseFullGOP] = value;
            }
        }

        /// <summary>
        /// Set to light up the input to MPEG2Enc a bit.
        /// </summary>
        public bool CorrectBrightness
        {
            get
            {
                // Read
                object value = TheRow[COL_Brightness];

                // Report
                return (DBNull.Value == value) ? true : (bool) value;
            }
            set
            {
                // Update
                TheRow[COL_Brightness] = value;
            }
        }

        /// <summary>
        /// The <see cref="DataRow"/> holding the configuration in its
        /// columns.
        /// </summary>
        private DataRow TheRow
        {
            get
            {
                // Calculate
                return Tables[0].Rows[0];
            }
        }

        /// <summary>
        /// Store the configuration to the default file.
        /// </summary>
        public void Save()
        {
            // Finish all
            AcceptChanges();

            // Create file
            WriteXml( SettingsPath, XmlWriteMode.IgnoreSchema );
        }
    }
}
