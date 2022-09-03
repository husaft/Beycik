using System.Collections.Generic;
using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal sealed class PdfAnnotations : PdfObject
    {
        public List<PdfObject> References { get; }

        public PdfAnnotations(IConfig config) : base(config)
        {
            References = new List<PdfObject>();
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument _)
        {
            var off = WriteHead(stream);
            xRef.Register(pos, 0, 'n');
            off += Write(stream, "[\n");
            foreach (var field in References)
                off += Write(stream, $"{field.Id} 0 R\n");
            off += Write(stream, "]\nendobj\n");
            return off;
        }
    }
}