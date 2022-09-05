using System.Collections.Generic;
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

        public void AddRect(PdfRect rect)
        {
            AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
            AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
            AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
            AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top);
        }

        public void AddSolidRect(PdfRect rect)
        {
            MoveTo(rect.Left, rect.Top);
            LineTo(rect.Right, rect.Top);
            LineTo(rect.Right, rect.Bottom);
            LineTo(rect.Left, rect.Bottom);
            LineTo(rect.Left, rect.Top);
            Fill();
        }

        private void LineTo(double x, double y)
        {
            var tmp = $" {_color.Get()}{x.Round2().T()} {y.Round2().T()} l\n";
            _lines.Add(tmp);
        }

        private void MoveTo(double x, double y)
        {
            var tmp = $" {x.Round2().T()} {y.Round2().T()} m\n";
            _lines.Add(tmp);
        }

        private void Fill()
        {
            _lines.Add(" f\n");
        }

        public void AddTriangle(PdfRect rect, char orient)
        {
            if (orient == 'r')
            {
                AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom);
                AddLine(rect.Left, rect.Top, rect.Right, rect.Top - rect.Height / 2.0);
                AddLine(rect.Left, rect.Bottom, rect.Right, rect.Top - rect.Height / 2.0);
                return;
            }
            if (orient == 'l')
            {
                AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
                AddLine(rect.Right, rect.Top, rect.Left, rect.Top - rect.Height / 2.0);
                AddLine(rect.Right, rect.Bottom, rect.Left, rect.Top - rect.Height / 2.0);
                return;
            }
            if (orient == 't')
            {
                AddLine(rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                AddLine(rect.Left, rect.Bottom, rect.Left + rect.Width / 2.0, rect.Top);
                AddLine(rect.Right, rect.Bottom, rect.Left + rect.Width / 2.0, rect.Top);
                return;
            }
            if (orient != 'b')
                return;
            AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
            AddLine(rect.Left, rect.Top, rect.Left + rect.Width / 2.0, rect.Bottom);
            AddLine(rect.Right, rect.Top, rect.Left + rect.Width / 2.0, rect.Bottom);
        }

        public void AddSolidTriangle(PdfRect rect, char orient)
        {
            if (orient == 'r')
            {
                MoveTo(rect.Left, rect.Top);
                LineTo(rect.Left, rect.Bottom);
                LineTo(rect.Right, rect.Top - rect.Height / 2.0);
                LineTo(rect.Left, rect.Top);
                Fill();
                return;
            }
            if (orient == 'l')
            {
                MoveTo(rect.Right, rect.Top);
                LineTo(rect.Right, rect.Bottom);
                LineTo(rect.Left, rect.Top - rect.Height / 2.0);
                LineTo(rect.Right, rect.Top);
                Fill();
                return;
            }
            if (orient == 't')
            {
                MoveTo(rect.Left, rect.Bottom);
                LineTo(rect.Right, rect.Bottom);
                LineTo(rect.Left + rect.Width / 2.0, rect.Top);
                LineTo(rect.Left, rect.Bottom);
                Fill();
                return;
            }
            if (orient != 'b')
                return;
            MoveTo(rect.Left, rect.Top);
            LineTo(rect.Right, rect.Top);
            LineTo(rect.Left + rect.Width / 2.0, rect.Bottom);
            LineTo(rect.Left, rect.Top);
            Fill();
        }

        public void AddCircle(PdfRect rect)
            => AddCircle(rect.Left + rect.Width / 2.0, rect.Top - rect.Height / 2.0,
                rect.Width / 2.0, rect.Height / 2.0, false);

        public void AddSolidCircle(PdfRect rect)
            => AddCircle(rect.Left + rect.Width / 2.0, rect.Top - rect.Height / 2.0,
                rect.Width / 2.0, rect.Height / 2.0, true);

        private void AddCircle(double a, double b, double c, double d, bool isSolid)
        {
            var str = $"{_color.Get()}{_lineMode.Get()}{a + c} {b} m\n" +
                      $"{a + c} {b + d * 0.5} {a + c * 0.5} {b + d} {a} {b + d} c\n" +
                      $"{a - c * 0.5} {b + d} {a - c} {b + d * 0.5} {a - c} {b} c\n" +
                      $"{a - c} {b - d * 0.5} {a - c * 0.5} {b - d} {a} {b - d} c\n" +
                      $"{a + c * 0.5} {b - d} {a + c} {b - d * 0.5} {a + c} {b} c";
            _lines.Add(!isSolid ? $"{str} S\n" : $"{str} B\n");
        }
    }
}