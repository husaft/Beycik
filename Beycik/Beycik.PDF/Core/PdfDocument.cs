using Beycik.PDF.Config;

namespace Beycik.PDF.Core
{
    internal sealed class PdfDocument
    {
        public const string PdfVersion = "1.4";

        public IConfig Config { get; }
        public PdfInfo Info { get; }
        public PdfOptions Options { get; }

        public PdfDocument(IConfig config, PdfOptions options)
        {
            Config = config;
            Info = new PdfInfo(config);
            Options = options;
        }
    }
}