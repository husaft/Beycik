using Beycik.Draw.Fonts.API;
using Beycik.Model.Objects;
using Beycik.Model.Objects.Scraps;
using Beycik.PDF.Core;
using Beycik.PDF.Visuals;

namespace Beycik.PDF.Text
{
    internal static class TextRender
    {
        public static void RenderClustered(PdfDocument doc, PdfPage page, PdfRect rect,
            TextCluster tc, Direction mode, double height, IFontManager fonts,
            IEncodingPatcher ec, TextMetrics metrics)
        {
            var atomizer = new TextAtomizer();
            atomizer.AtomizeCluster(tc, metrics, fonts, ec);
            atomizer.AssembleLine(rect.Width, height);
            RenderAtomized(doc, page, rect, atomizer, mode, height, ec);
        }

        public static void RenderInside(PdfDocument doc, PdfPage page, PdfRect rect,
            FontHandle font, string text, Direction mode, double height, IFontManager fonts,
            IEncodingPatcher ec, TextMetrics metrics)
        {
            var atomizer = new TextAtomizer();
            atomizer.Atomize(text, font, metrics, rect.Width, fonts, ec);
            atomizer.AssembleLine(rect.Width, height);
            RenderAtomized(doc, page, rect, atomizer, mode, height, ec);
        }

        public static void RenderSimple(PdfDocument doc, PdfPage page, PdfRect rect,
            FontHandle font, string text, Direction mode, double height,
            IFontManager fonts, IEncodingPatcher ec, TextMetrics metrics)
        {
            var atomizer = new TextAtomizer();
            atomizer.Atomize(text, font, metrics, fonts, ec);
            atomizer.AssembleLine(rect.Width, height);
            RenderAtomized(doc, page, rect, atomizer, mode, height, ec);
        }

        public static double GetFontHeightForNull(FontHandle font, IFontManager fonts,
            IEncodingPatcher texts, TextMetrics metrics)
        {
            var atomizer = new TextAtomizer();
            atomizer.Atomize(null, font, metrics, fonts, texts);
            atomizer.AssembleLine(100.0, 1.0);
            return atomizer.GetLine(0).LineHeight;
        }

        private static void RenderAtomized(PdfDocument doc, PdfPage page, PdfRect rect,
            TextAtomizer atomizer, Direction mode, double factor, IEncodingPatcher ec)
        {
            var top = rect.Top;
            for (var i = 0; i < atomizer.LineSigma; ++i)
            {
                var line = atomizer.GetLine(i);
                if (i > 0)
                    top -= line.LineHeight * factor;
                else
                    top -= line.LineHeight;
                switch (mode)
                {
                    case Direction.Left:
                        RenderAtomizedLeft(rect, line, page, top, doc, ec);
                        break;
                    case Direction.Right:
                        RenderAtomizedRight(doc, page, rect, ec, line, top);
                        break;
                    case Direction.Justify:
                        RenderAtomizedJustify(doc, page, rect, atomizer, ec, line, i, top);
                        break;
                    case Direction.Center:
                        RenderAtomizedCenter(doc, page, rect, ec, line, top);
                        break;
                }
                if (top < rect.Bottom)
                    break;
            }
        }

        private static void RenderAtomizedCenter(PdfDocument doc, PdfPage page, PdfRect rect,
            IEncodingPatcher ec, TextLine line, double top)
        {
            var x = rect.Left + (rect.Width - line.Width) / 2.0;
            for (var i = 0; i < line.Atoms.Count; ++i)
            {
                var atom = line.Atoms[i];
                if (atom.Type != AtomType.Text)
                    continue;
                var font = doc.RegisterFont(atom.FontData.Family, atom.FontData.Bold,
                    atom.FontData.Italic, FontEncoding.WinAnsi);
                var color = new Color(atom.Red, atom.Green, atom.Blue);
                page.Stream.SetColor(color);
                var y = top + GetBaseOffset(atom.FontData, doc);
                page.Stream.AddText(x, y, font, atom.FontData.Size, atom.Text, ec);
                if (atom.Underline)
                {
                    page.Stream.SetLineMode(atom.FontData.Size / 13.0, 0.0, 0.0);
                    if (i < line.Atoms.Count - 1)
                        page.Stream.AddLine(x, top, x + atom.Width + atom.WsWidth, top);
                    else
                        page.Stream.AddLine(x, top, x + atom.Width, top);
                }
                x = x + atom.Width + atom.WsWidth;
            }
        }

        private static void RenderAtomizedJustify(PdfDocument doc, PdfPage page, PdfRect rect,
            TextAtomizer atomizer, IEncodingPatcher ec, TextLine line, int lineCtr, double top)
        {
            var count = line.Atoms.Count;
            if (count <= 0)
                return;
            if (line.Atoms[count - 1].Type == AtomType.LineBreak || count < 2 ||
                lineCtr == atomizer.LineSigma - 1 || line.Mode == LineType.HardBreak)
            {
                var x = rect.Left;
                for (var i = 0; i < line.Atoms.Count; ++i)
                {
                    var atom = line.Atoms[i];
                    if (atom.Type != AtomType.Text)
                        continue;
                    var font = doc.RegisterFont(atom.FontData.Family, atom.FontData.Bold,
                        atom.FontData.Italic, FontEncoding.WinAnsi);
                    var color = new Color(atom.Red, atom.Green, atom.Blue);
                    page.Stream.SetColor(color);
                    var y = top + GetBaseOffset(atom.FontData, doc);
                    page.Stream.AddText(x, y, font, atom.FontData.Size, atom.Text, ec);
                    if (atom.Underline)
                    {
                        page.Stream.SetLineMode(atom.FontData.Size / 13.0, 0.0, 0.0);
                        if (i < line.Atoms.Count - 1)
                            page.Stream.AddLine(x, top,
                                x + atom.Width + atom.WsWidth, top);
                        else
                            page.Stream.AddLine(x, top, x + atom.Width, top);
                    }
                    x = x + atom.Width + atom.WsWidth;
                }
                return;
            }
            var push = (rect.Width - line.Width) / (count - 1);
            var left = rect.Left;
            for (var index = 0; index < count; ++index)
            {
                var atom = line.Atoms[index];
                var font = doc.RegisterFont(atom.FontData.Family, atom.FontData.Bold,
                    atom.FontData.Italic, FontEncoding.WinAnsi);
                var color = new Color(atom.Red, atom.Green, atom.Blue);
                page.Stream.SetColor(color);
                var y = top + GetBaseOffset(atom.FontData, doc);
                page.Stream.AddText(left, y, font, atom.FontData.Size, atom.Text, ec);
                if (atom.Underline)
                {
                    page.Stream.SetLineMode(atom.FontData.Size / 13.0, 0.0, 0.0);
                    if (index < line.Atoms.Count - 1)
                        page.Stream.AddLine(left, top,
                            left + atom.Width + atom.WsWidth + push, top);
                    else
                        page.Stream.AddLine(left, top, left + atom.Width, top);
                }
                left += atom.Width + atom.WsWidth + push;
            }
        }

        private static void RenderAtomizedRight(PdfDocument doc, PdfPage page, PdfRect rect,
            IEncodingPatcher ec, TextLine line, double top)
        {
            var x = rect.Right - line.Width;
            for (var i = 0; i < line.Atoms.Count; ++i)
            {
                var atom = line.Atoms[i];
                if (atom.Type != AtomType.Text)
                    continue;
                var font = doc.RegisterFont(atom.FontData.Family, atom.FontData.Bold,
                    atom.FontData.Italic, FontEncoding.WinAnsi);
                var color = new Color(atom.Red, atom.Green, atom.Blue);
                page.Stream.SetColor(color);
                var y = top + GetBaseOffset(atom.FontData, doc);
                page.Stream.AddText(x, y, font, atom.FontData.Size, atom.Text, ec);
                if (atom.Underline)
                {
                    page.Stream.SetLineMode(atom.FontData.Size / 13.0, 0.0, 0.0);
                    if (i < line.Atoms.Count - 1)
                        page.Stream.AddLine(x, top, x + atom.Width + atom.WsWidth, top);
                    else
                        page.Stream.AddLine(x, top, x + atom.Width, top);
                }
                x = x + atom.Width + atom.WsWidth;
            }
        }

        private static void RenderAtomizedLeft(PdfRect rect, TextLine line,
            PdfPage page, double top, PdfDocument doc, IEncodingPatcher ec)
        {
            var x = rect.Left;
            for (var index = 0; index < line.Atoms.Count; ++index)
            {
                var atom = line.Atoms[index];
                if (atom.Type == AtomType.Text)
                {
                    var tfd = atom.FontData;
                    var name = doc.RegisterFont(tfd.Family, tfd.Bold, tfd.Italic, FontEncoding.WinAnsi);
                    var color = new Color(atom.Red, atom.Green, atom.Blue);
                    page.Stream.SetColor(color);
                    var y = top + GetBaseOffset(tfd, doc);
                    page.Stream.AddText(x, y, name, tfd.Size, atom.Text, ec);
                    if (atom.Underline)
                    {
                        page.Stream.SetLineMode(tfd.Size / 13.0, 0.0, 0.0);
                        if (index < line.Atoms.Count - 1)
                            page.Stream.AddLine(x, top, x + atom.Width + atom.WsWidth, top);
                        else
                            page.Stream.AddLine(x, top, x + atom.Width, top);
                    }
                    x = x + atom.Width + atom.WsWidth;
                }
            }
        }

        private static double GetBaseOffset(FontData data, PdfDocument doc)
        {
            var baseOff = data.BaseOffset;
            var fix = doc.Config.Quirks?.BaseOffsetFix;
            if (fix != null) baseOff -= fix.Invoke() ?? 0;
            return baseOff;
        }
    }
}