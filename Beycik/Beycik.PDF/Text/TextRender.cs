using System;
using Beycik.Draw.Fonts.API;
using Beycik.Model.Objects.Scraps;
using Beycik.PDF.Core;
using Beycik.PDF.Visuals;

namespace Beycik.PDF.Text
{
    internal static class TextRender
    {
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
            throw new InvalidOperationException();
        }
    }
}