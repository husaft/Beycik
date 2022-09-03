using System.Collections.Generic;
using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;
using Beycik.PDF.Visuals;

namespace Beycik.PDF.Core
{
    internal sealed class PdfStream : PdfObject
    {
        private readonly PdfColor _color;
        private readonly List<string> _lines;

        public PdfStream(IConfig config) : base(config)
        {
            _color = new PdfColor();
            _lines = new List<string>();
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument _)
        {
            var length = 0;
            var off = WriteHead(stream);
            if (_lines.Count == 0)
                length = "q\ns\nQ\n".Length;
            else
                foreach (var tmp in _lines)
                    length += tmp.Length;
            xRef.Register(pos, 0, 'n');
            off += Write(stream, $"<< /Length {length} >>\nstream\n");
            if (_lines.Count == 0)
                off += Write(stream, "q\ns\nQ\n");
            else
                foreach (var tmp in _lines)
                    off += Write(stream, tmp);
            off += Write(stream, "endstream\nendobj\n");
            return off;
        }

        public void SetColor(Color color)
        {
            var (red, green, blue) = color;
            _color.SetRgb(red / 255.0, green / 255.0, blue / 255.0);
        }
    }
}