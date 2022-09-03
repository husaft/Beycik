using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal class PdfFonts : PdfObject
    {
        public PdfFonts(IConfig config) : base(config)
        {
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument pdf)
        {
            // TODO
            return 0;
        }
    }
}