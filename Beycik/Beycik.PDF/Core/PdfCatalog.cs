using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal class PdfCatalog : PdfObject
    {
        public PdfCatalog(IConfig config, PdfOptions options) : base(config)
        {
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument pdf)
        {
            // TODO
            return 0;
        }
    }
}