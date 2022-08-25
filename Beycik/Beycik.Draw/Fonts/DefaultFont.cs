using System;
using Beycik.Draw.Fonts.API;
using SixLabors.Fonts;
using FontStyle = Beycik.Draw.Fonts.API.FontStyle;

namespace Beycik.Draw.Fonts
{
    internal class DefaultFont : IFont, IFontMetrics
    {
        private readonly Font _parent;

        public DefaultFont(Font font)
        {
            _parent = font;
        }

        public IFontMetrics GetFontMetrics() => this;
        public int Size => (int)Math.Ceiling(_parent.Size);
        public string FontName => _parent.Name;
        public string Family => _parent.Family.Name;
        public string Name => Family;
        public FontStyle Style => _parent.FontMetrics.Description.Style.Convert();

        public int Height
        {
            get
            {
                const float add = 0.95f;
                var size = _parent.Size;
                var fm = _parent.FontMetrics;
                var raw = fm.LineHeight * 1.0 * size / fm.UnitsPerEm;
                var line = Math.Ceiling(raw + add);
                return (int)line;
            }
        }

        public int Ascent
        {
            get
            {
                var size = _parent.Size;
                var fm = _parent.FontMetrics;
                var raw = fm.Ascender * 1.0 * size / fm.UnitsPerEm;
                var ascent = Math.Ceiling(raw);
                return (int)ascent;
            }
        }

        public int Descent
        {
            get
            {
                var size = _parent.Size;
                var fm = _parent.FontMetrics;
                var raw = Math.Abs(fm.Descender) * 1.0 * size / fm.UnitsPerEm;
                var descent = Math.Ceiling(raw);
                return (int)descent;
            }
        }

        public float StringWidth(string text)
        {
            var options = new TextOptions(_parent);
            var bounds = TextMeasurer.Measure(text, options);
            var value = bounds.Width;
            return value;
        }

        public float CharWidth(char text)
        {
            var options = new TextOptions(_parent);
            var bounds = TextMeasurer.Measure(new[] { text }, options);
            var value = bounds.Width;
            return value;
        }
    }
}