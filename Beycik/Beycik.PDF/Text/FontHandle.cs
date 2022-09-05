using Beycik.Draw.Fonts.API;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using static Beycik.Draw.Fonts.FontTool;
using static Beycik.PDF.Tools.PdfConst;

namespace Beycik.PDF.Text
{
    internal record FontHandle(string Face, double Size,
        int Red, int Green, int Blue,
        bool Bold, bool Italic, bool Underline)
    {
        public static FontHandle ApplyFrom(object item)
        {
            var styleObj = item as IStyleable;
            var face = styleObj?.FontFace ?? Helvetica;
            var size = styleObj?.FontSize ?? StdFontSize;
            var bold = styleObj?.Bold ?? false;
            var italic = styleObj?.Italic ?? false;
            var underline = styleObj?.Underline ?? false;

            var fontObj = item as IFontColor;
            var red = fontObj?.FontRed ?? 0;
            var green = fontObj?.FontGreen ?? 0;
            var blue = fontObj?.FontBlue ?? 0;

            return new FontHandle(face, size, red, green, blue, bold, italic, underline);
        }

        public static FontHandle CopyFrom(FontHandle orig)
        {
            var face = orig.Face;
            var size = orig.Size;
            var red = orig.Red;
            var green = orig.Green;
            var blue = orig.Blue;
            var bold = orig.Bold;
            var italic = orig.Italic;
            var underline = orig.Underline;

            return new FontHandle(face, size, red, green, blue, bold, italic, underline);
        }

        public FontStyle FontAttributes => Convert(Bold, Italic);
    }
}