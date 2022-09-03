using System.Collections.Generic;
using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal sealed class PdfPages : PdfObject
    {
        public List<PdfPage> Pages { get; }

        public PdfPages(IConfig config) : base(config)
        {
            Pages = new List<PdfPage>();
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument doc)
        {
            var off = WriteHead(stream);
            xRef.Register(pos, 0, 'n');
            off += Write(stream, "<< /Type /Pages\n");
            if (Pages.Count != 0)
            {
                off += Write(stream, "/Kids [");
                foreach (var page in Pages)
                    off += Write(stream, $" {page.Id} 0 R");
                off += Write(stream, "]\n");
            }
            off += Write(stream, $"/Count {Pages.Count}\n>>\nendobj\n");
            foreach (var page in Pages)
                off += page.Write(stream, xRef, pos + off, doc);
            return off;
        }

        public override int ReNumber(int id)
        {
            foreach (var page in Pages)
                page.ParentId = id;
            id = base.ReNumber(id);
            foreach (var page in Pages)
                id = page.ReNumber(id);
            return id;
        }

        public PdfPage CreatePage(int pageIdx, double width, double height, PdfDocument doc)
        {
            var page = new PdfPage(Config, pageIdx, width, height, doc);
            Pages.Add(page);
            return page;
        }
    }
}