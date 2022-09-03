using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal sealed class PdfCatalog : PdfObject
    {
        public PdfPages Pages { get; }
        public PdfFields Fields { get; }
        public PdfXObjects XObjects { get; }

        public PdfCatalog(IConfig config, PdfOptions options) : base(config)
        {
            Pages = new PdfPages(config);
            Fields = new PdfFields(config);
            XObjects = new PdfXObjects(config);
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument doc)
        {
            var off = WriteHead(stream);
            xRef.Register(pos, 0, 'n');
            off += Write(stream, "<< /Type /Catalog\n");
            off += Write(stream, $"/Pages {Pages.Id} {Pages.Version} R\n");
            off += Write(stream, $"/AcroForm {Fields.Id} {Fields.Version} R\n");
            off += Write(stream, ">>\nendobj\n");
            off += Pages.Write(stream, xRef, pos + off, doc);
            off += Fields.Write(stream, xRef, pos + off, doc);
            off += XObjects.Write(stream, xRef, pos + off, doc);
            return off;
        }

        public override int ReNumber(int id)
        {
            id = base.ReNumber(id);
            id = Pages.ReNumber(id);
            id = Fields.ReNumber(id);
            id = XObjects.ReNumber(id);
            return id;
        }
    }
}