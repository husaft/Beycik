﻿using System.Collections.Generic;
using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;
using Beycik.PDF.Text;
using Beycik.PDF.Tools;
using Beycik.PDF.Visuals;

namespace Beycik.PDF.Core
{
    internal sealed class PdfStream : PdfObject
    {
        private readonly PdfColor _color;
        private readonly PdfLineMode _lineMode;
        private readonly List<string> _lines;
        private readonly PdfPage _page;

        public PdfStream(IConfig config, PdfPage page) : base(config)
        {
            _color = new PdfColor();
            _lineMode = new PdfLineMode();
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

        public void PopGraphicsState()
        {
            _lines.Add(" Q\n");
            _color.SetChanged();
        }

        public void PushGraphicsState()
        {
            _lines.Add(" q\n");
        }

        public void SetMatrix(double a, double b, double c, double d, double e, double f)
        {
            var tmp = $"{a.T()} {b.T()} {c.T()} {d.T()} {e.T()} {f.T()} cm S\n";
            _lines.Add(tmp);
        }

        public void AddLine(double x1, double y1, double x2, double y2)
        {
            var tmp = $"{_color.Get()}{_lineMode.Get()}{x1.Round2().T()} " +
                      $"{y1.Round2().T()} m {x2.Round2().T()} {y2.Round2().T()} l S\n";
            _lines.Add(tmp);
        }

        public void SetLineMode(double width, double on, double off)
        {
            _lineMode.Set(width.Round2(), on, off);
        }

        public void AddText(double x, double y, string font,
            double size, string text, IEncodingPatcher encoder)
        {
            var plain = PdfExt.CleanText(text);
            var ansi = encoder.Translate(plain);
            _page.RegisterFont(font);
            var line = $"{_color.Get()}BT /{font} {size.T()} Tf " +
                       $"{x.Round2().T()} {y.Round2().T()} Td ({ansi}) Tj ET\n";
            _lines.Add(line);
        }
    }
}