using Beycik.Draw.Fonts.API;
using static Beycik.PDF.Tools.PdfConst;
using static Beycik.PDF.Visuals.Precompiled;
using F = Beycik.Draw.Fonts.API.FontStyle;

namespace Beycik.PDF.Text
{
    public record FontData(string Family, FontStyle Style,
        double Size, IFontManager Fonts)
    {
        public double GetCharWidth(string text)
        {
            var width = 0.0;
            foreach (var letter in text)
                width += GetPreWidth(letter) ?? Metrics.CharWidth(letter) / FontFactor;
            return width;
        }

        public double GetStringWidth(string txt) => Metrics.StringWidth(txt);

        public IFontMetrics Metrics => LoadFont().metrics;
        public IFont Font => LoadFont().font;

        private (IFont, IFontMetrics)? _loaded;

        private (IFont font, IFontMetrics metrics) LoadFont()
        {
            if (_loaded != null)
                return _loaded.Value;

            var scaled = (int)(Size * FontFactor);
            var font = Create(Fonts, Family, Style, scaled);
            var metrics = font.GetFontMetrics();
            return (_loaded = (font, metrics)).Value;
        }

        public bool Bold => Style.HasFlag(FontStyle.Bold);
        public bool Italic => Style.HasFlag(FontStyle.Italic);

        private static IFont Create(IFontManager fonts, string face, FontStyle style, int size)
        {
            var desc = new FontDescriptor(face, style, size);
            var retVal = fonts?.Create(desc);
            return retVal;
        }

        public double Height => GetPreHeight() ?? Metrics.Height / FontFactor;
        public double BaseOffset => (Metrics.Height - Metrics.Ascent) / FontFactor;
        public double RealHeight => (Metrics.Ascent + Metrics.Descent) / FontFactor;
        public double UnscaledSize => Size;
        public double Ascent => Metrics.Ascent / FontFactor;
        public double Descent => Metrics.Descent / FontFactor;
        public int RealSize => (int)Size;

        private bool UsePrecompiled => Family?.Equals(Helvetica) ?? false;

        private double? GetPreHeight()
        {
            const int start = 5;
            const int end = 20;
            return UsePrecompiled && RealSize is >= start and <= end
                ? LineHeight[Helvetica][RealSize]
                : null;
        }

        private FontStyle FunStyle => Bold ? F.Bold : Italic ? F.Italic : F.Regular;

        private double? GetPreWidth(char letter)
        {
            const int start = 5;
            const int end = 15;
            const int count = 256;
            return UsePrecompiled && letter < count && RealSize is >= start and <= end
                ? CharWidth[Helvetica][FunStyle][RealSize][letter]
                : null;
        }
    }
}