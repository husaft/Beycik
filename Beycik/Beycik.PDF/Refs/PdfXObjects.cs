using System.Collections.Generic;
using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Core;

namespace Beycik.PDF.Refs
{
    internal sealed class PdfXObjects : PdfObject
    {
        public List<PdfObject> Objects { get; }

        public PdfXObjects(IConfig config) : base(config)
        {
            Objects = new List<PdfObject>();
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument doc)
        {
            var off = WriteHead(stream);
            foreach (var obj in Objects)
                off += obj.Write(stream, xRef, pos + off, doc);
            return off;
        }

        public override int ReNumber(int id)
        {
            foreach (var item in Objects)
                id = item.ReNumber(id);
            return id;
        }
    }
}