using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;
using Beycik.PDF.Tools;
using Beycik.PDF.Visuals;

namespace Beycik.PDF.Core
{
    internal sealed class PdfStream : PdfObject
    {
        private readonly PdfColor _color;
        private readonly List<string> _lines;
        private readonly PdfPage _page;

        public PdfStream(IConfig config, PdfPage page) : base(config)
        {
            _color = new PdfColor();
            _lines = new List<string>();
            _page = page;
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

        public void AddImage(byte[] data, PdfRect rect, int width, int height, bool gray)
        {
            var imgName = _page.RegisterImage(data, width, height, gray);
            var xT = rect.Right - rect.Left;
            var x = xT / width;
            var xS = x.T();
            var y1T = rect.Top - rect.Bottom;
            var y1 = y1T / height;
            var y1S = y1.T();
            var y2T = (decimal)rect.Top - (decimal)rect.Bottom;
            var y2 = decimal.Divide(y2T, height);
            var y2S = y2.T();
            var yS = y1S.Length == 19 ? y1S : y2S;
            var line = $"q\n1 0 0 1 {rect.Left.Round2().T()} " +
                       $"{rect.Bottom.Round2().T()} cm\n" +
                       $"{xS} 0 0 {yS} 0 0 cm\n" +
                       $"{width} 0 0 {height} 0 0 cm\n" +
                       $"/{imgName} Do\n" +
                       "s\nQ\n";
            _lines.Add(line);
        }
    }
}