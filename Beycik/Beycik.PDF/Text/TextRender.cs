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

        public static void RenderSimple(PdfDocument doc, PdfPage page, PdfRect rect,
            FontHandle font, string text, Direction mode, double height,
            IFontManager fonts, IEncodingPatcher ec, TextMetrics metrics)
        {
            var atomizer = new TextAtomizer();
            atomizer.Atomize(text, font, metrics, fonts, ec);
            atomizer.AssembleLine(rect.Width, height);
            RenderAtomized(doc, page, rect, atomizer, mode, height, ec);
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
                        // TODO Two
                        break;
                    case Direction.Justify:
                        // TODO Three
                        break;
                    case Direction.Center:
                        // TODO Four
                        break;
                }
                if (top < rect.Bottom)
                    break;
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
                    var baseOff = tfd.BaseOffset;
                    baseOff -= doc.Config.Quirks?.BaseOffsetFix?.Invoke() ?? 0;
                    var y = top + baseOff;
                    page.Stream.AddText(x, y, name, tfd.RawSize, atom.Text, ec);
                    if (atom.Underline)
                    {
                        page.Stream.SetLineMode(tfd.RawSize / 13.0, 0.0, 0.0);
                        if (index < line.Atoms.Count - 1)
                            page.Stream.AddLine(x, top, x + atom.Width + atom.WsWidth, top);
                        else
                            page.Stream.AddLine(x, top, x + atom.Width, top);
                    }
                    x = x + atom.Width + atom.WsWidth;
                }
            }
        }
    }
}