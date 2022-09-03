using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal sealed class PdfDocument
    {
        public IConfig Config { get; }
        public PdfInfo Info { get; }
        public PdfHeader Header { get; }
        public PdfCatalog Catalog { get; }
        public PdfFonts Fonts { get; }
        public PdfImages Images { get; }
        public PdfOptions Options { get; }

        public PdfDocument(IConfig config, PdfOptions options)
        {
            Config = config;
            Info = new PdfInfo(config);
            Header = new PdfHeader(config);
            Catalog = new PdfCatalog(Config, options);
            Fonts = new PdfFonts(Config);
            Images = new PdfImages(Config);
            Options = options;
        }

        public int ExportToFile(string filename)
        {
            using var stream = File.Create(filename);
            return ExportToStream(stream);
        }

        private int ExportToStream(Stream stream)
        {
            var xRef = new PdfXref(Config);
            var pos = Header.Write(stream);
            Images.ReNumber(Fonts.ReNumber(Catalog.ReNumber(Info.ReNumber(1))));
            pos += Info.Write(stream, xRef, pos, this);
            pos += Catalog.Write(stream, xRef, pos, this);
            pos += Fonts.Write(stream, xRef, pos, this);
            pos += Images.Write(stream, xRef, pos, this);
            pos += xRef.Write(stream, pos);
            return pos;
        }

        public PdfPage CreatePage(int pageIdx, double width, double height)
        {
            return Catalog.Pages.CreatePage(pageIdx, width, height, this);
        }
    }
}