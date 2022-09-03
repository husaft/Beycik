using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal sealed class PdfPage : PdfObject
    {
        public int ParentId { get; set; }

        public PdfPage(IConfig config) : base(config)
        {
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument pdf)
        {
            throw new System.NotImplementedException();
        }
    }
}