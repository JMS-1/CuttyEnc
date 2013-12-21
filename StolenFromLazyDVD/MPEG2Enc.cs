using System.Diagnostics;
using JMS.InterOp.CommandLine;

namespace JMS.InterOp.DVDAuthor
{
    /// <summary>
    /// The wrapper for the MPEG2Enc MPEG2 encoder which can generate
    /// MPEG2 video streams from a YUV source.
    /// </summary>
    public class MPEG2Enc : CommandLineTool
    {
        /// <summary>
        /// Video formats.
        /// </summary>
        public enum Formats
        {
            MPEG1,			// 0
            StandardVCD,	// 1
            VCD,			// 2
            MPEG2,			// 3
            StandardSVCD,	// 4
            SVCD,			// 5
            VCDStills,		// 6
            SVCDStills,		// 7
            DVD				// 8
        }

        /// <summary>
        /// Video picture aspect ratios.
        /// </summary>
        public enum AspectRatios
        {
            Unknown,		// 0
            VGA,			// 1
            TV,				// 2
            Wide,			// 3
            Cinema,			// 4
            VCD				// 8
        }

        /// <summary>
        /// Video norm support.
        /// </summary>
        public enum VideoNorms
        {
            Unspecified,
            NTSC,			// n
            PAL,			// p
            SECAM			// s
        }

        /// <summary>
        /// Current picture aspect ratio.
        /// </summary>
        public AspectRatios AspectRatio = AspectRatios.Unknown;

        /// <summary>
        /// The video norm to use.
        /// </summary>
        public VideoNorms VideoNorm = VideoNorms.Unspecified;

        /// <summary>
        /// The file format.
        /// </summary>
        public Formats Format = Formats.DVD;

        /// <summary>
        /// Minimum frames allowed in each GOP.
        /// </summary>
        public int MinimumFramesPerGOP = 0;

        /// <summary>
        /// Maximum frames allowed in each GOP.
        /// </summary>
        public int MaximumFramesPerGOP = 0;

        /// <summary>
        /// Output file for the MPEG2 encoded video.
        /// </summary>
        public string OutputFile = null;

        /// <summary>
        /// Frame rate indicator as defined in <see cref="FrameRateInfo"/>.
        /// </summary>
        public int FrameRateCode = 0;

        /// <summary>
        /// Quality factor.
        /// </summary>
        public int Quantisation = 0;

        /// <summary>
        /// Set to activate high resolution mode.
        /// </summary>
        public bool HiResMode = false;

        /// <summary>
        /// Video buffer size in kB.
        /// </summary>
        public int BufferSize = 0;

        /// <summary>
        /// Bitrate in kBit per second.
        /// </summary>
        public int BitRate = 0;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public MPEG2Enc()
        {
        }

        /// <summary>
        /// Report the name of the executable.
        /// </summary>
        protected override string CommandKey
        {
            get
            {
                // My unique name
                return "mpeg2enc";
            }
        }

        /// <summary>
        /// Construct the command line arguments from our fields.
        /// </summary>
        /// <param name="startInfo"></param>
        protected override void OnPrepareRun( ProcessStartInfo startInfo )
        {
            // Create command line
            switch (AspectRatio)
            {
                case AspectRatios.Cinema: AddArgument( 'a', 4 ); break;
                case AspectRatios.TV: AddArgument( 'a', 2 ); break;
                case AspectRatios.VGA: AddArgument( 'a', 1 ); break;
                case AspectRatios.Wide: AddArgument( 'a', 3 ); break;
                case AspectRatios.VCD: break;
            }
            switch (VideoNorm)
            {
                case VideoNorms.NTSC: AddArgument( 'n', 'n' ); break;
                case VideoNorms.PAL: AddArgument( 'n', 'p' ); break;
                case VideoNorms.SECAM: AddArgument( 'n', 's' ); break;
            }
            AddArgument( 'f', (int) Format );
            if (HiResMode) 
                AddArgument( 'K', "hi-res --no-constraints" );
            if (null != OutputFile) 
                AddPath( 'o', OutputFile );
            if (0 != Quantisation) 
                AddArgument( 'q', Quantisation );
            if (0 != BitRate) 
                AddArgument( 'b', BitRate );
            if (0 != MinimumFramesPerGOP) 
                AddArgument( 'g', MinimumFramesPerGOP );
            if (0 != MaximumFramesPerGOP) 
                AddArgument( 'G', MaximumFramesPerGOP );
            if (0 != BufferSize) 
                AddArgument( 'V', BufferSize );
            if (0 != FrameRateCode) 
                AddArgument( 'F', FrameRateCode );
        }
    }
}
