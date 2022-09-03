using System.Collections.Generic;
using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal sealed class PdfFields : PdfObject
    {
        public List<PdfObject> Fields { get; }

        public PdfFields(IConfig config) : base(config)
        {
            Fields = new List<PdfObject>();
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument doc)
        {
            var off = WriteHead(stream);
            xRef.Register(pos, 0, 'n');
            off += Write(stream, "<< /Fields [");
            foreach (var field in Fields)
                off += Write(stream, $" {field.Id} 0 R");
            off += Write(stream, " ]\n");

            var h = doc.Fonts.GetIdByName("Helv");
            var c = doc.Fonts.GetIdByName("Cour");
            var z = doc.Fonts.GetIdByName("ZaDb");
            var fo = $"/DR << /Font << /Helv {h} 0 R /Cour {c} 0 R /ZaDb {z} 0 R >> >>\n";
            off += Write(stream, fo);

            off += Write(stream, "/DA (/Helv 0 Tf 0 g )\n");
            off += Write(stream, ">>\nendobj\n");
            foreach (var field in Fields)
                off += field.Write(stream, xRef, pos + off, doc);
            return off;
        }

        public override int ReNumber(int id)
        {
            id = base.ReNumber(id);
            foreach (var field in Fields)
                id = field.ReNumber(id);
            return id;
        }
    }
}