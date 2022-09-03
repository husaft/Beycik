using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;
using Beycik.PDF.Text;
using Beycik.PDF.Tools;

namespace Beycik.PDF.Core
{
    internal sealed class PdfFont : PdfObject
    {
        public string Face { get; }
        public string Name { get; }
        public bool Italic { get; }
        public FontEncoding Encoding { get; }

        public PdfFont(IConfig config, string face, string name,
            bool italic, FontEncoding encoding) : base(config)
        {
            Face = face;
            Name = name;
            Italic = italic;
            Encoding = encoding;
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument _)
        {
            var off = WriteHead(stream);
            xRef.Register(pos, 0, 'n');
            string tmp;
            if (Encoding != FontEncoding.NotInclude)
            {
                tmp = $"<< /Type /Font\n/Subtype /Type1\n/Name /{Name}\n" +
                      $"/BaseFont /{Face}\n/Encoding /{Encoding.ToName()}\n>>\nendobj\n";
                off += Write(stream, tmp);
                return off;
            }
            tmp = $"<< /Type /Font\n/Subtype /Type1\n/Name /{Name}\n" +
                  $"/BaseFont /{Face}\n>>\nendobj\n";
            off += Write(stream, tmp);
            return off;
        }
    }
}