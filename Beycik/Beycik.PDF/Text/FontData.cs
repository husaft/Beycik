using Beycik.Draw.Fonts.API;
using static Beycik.PDF.Tools.PdfConst;
using FontStyle = Beycik.Draw.Fonts.API.FontStyle;

namespace Beycik.PDF.Text
{
    internal record FontData(string Family, FontStyle Style,
        double RawSize, IFontManager Fonts)
    {
        public double GetWidth(string text)
        {
            LoadFont();
            var num = 0.0;
            foreach (var letter in text)
            {
                num += Metrics.CharWidth(letter) / FontFactor;
            }
            return num;
        }

        public IFontMetrics Metrics { get; private set; }
        public IFont Font { get; private set; }

        private void LoadFont()
        {
            if (Font != null)
                return;
            Font = Create(Fonts, Family, Style, (int)(Size * FontFactor));
            Metrics = Font.GetFontMetrics();
        }

        public bool Bold => Style.HasFlag(FontStyle.Bold);
        public bool Italic => Style.HasFlag(FontStyle.Italic);
        public double Size => RawSize / FontFactor;

        private static IFont Create(IFontManager fonts, string face, FontStyle style, int size)
        {
            var desc = new FontDescriptor(face, style, size);
            var retVal = fonts?.Create(desc);
            return retVal;
        }

        public double Height
        {
            get
            {
                LoadFont();
                return Metrics.Height / FontFactor;
            }
        }
    }
}