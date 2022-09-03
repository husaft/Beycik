using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal class PdfInfo : PdfObject
    {
        public PdfInfo(IConfig config) : base(config)
        {
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument _)
        {
            var c = Config;
            var off = WriteHead(stream);
            xRef.Register(pos, 0, 'n');
            off += Write(stream, "<<\n");
            off += Write(stream, $"/Title ({c.Title})\n");
            off += Write(stream, $"/Producer ({c.ProducerName} {c.ProducerWeb})\n");
            off += Write(stream, $"/Creator ({c.CreatorName} {c.CreatorVersion} {c.ProducerWeb})\n");
            off += Write(stream, $"/Author ({c.Author})\n");
            off += Write(stream, ">>\nendobj\n");
            return off;
        }
    }
}