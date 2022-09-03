using Beycik.Draw.Fonts.API;
using Beycik.Model.Objects;
using Beycik.PDF.Core;
using Beycik.PDF.Text;
using Beycik.PDF.Visuals;
using TextO = Beycik.Model.Objects.Text;

namespace Beycik.PDF
{
    internal static class XmlRender
    {
        public static void Handle(PdfRect rect, Image image, PdfPage page,
            PdfDocument pdf, FontHandle font)
        {
            throw new System.NotImplementedException();
        }

        public static void Handle(IFontManager fonts, TextO text,
            PdfPage page, PdfDocument pdf, PdfRect rect, FontHandle font)
        {
            throw new System.NotImplementedException();
        }
    }
}