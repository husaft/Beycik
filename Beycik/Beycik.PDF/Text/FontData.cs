using Beycik.Draw.Fonts.API;
using Beycik.PDF.Tools;
using Beycik.PDF.Visuals;
using static Beycik.PDF.Tools.PdfConst;
using FontStyle = Beycik.Draw.Fonts.API.FontStyle;

namespace Beycik.PDF.Text
{
    public record FontData(string Family, FontStyle Style,
        double Size, IFontManager Fonts)
    {
        public double GetCharWidth(string text)
        {
            var num = 0.0;
            foreach (var letter in text)
                num += Metrics.CharWidth(letter) / FontFactor;
            return num;
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
                ? Precompiled.LineHeight[Helvetica][RealSize]
                : null;
        }
    }
}