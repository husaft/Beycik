using Beycik.Draw.Fonts;
using Beycik.Draw.Fonts.API;
using Xunit;

namespace Beycik.Draw.Tests
{
    public class FontTest
    {
        [Theory]
        [InlineData("Arial", FontStyle.BoldItalic, 70, 64, 82,
            1.8, 15, "Arial Bold Italic", 3, 35 + 2, 163 + 1)]
        [InlineData("Arial", FontStyle.Italic, 70, 64, 82,
            1.8, 15, "Arial Italic", 2, 33 + 3, 149 - 1)]
        [InlineData("Arial", FontStyle.Bold, 70, 64, 82,
            1.8, 15, "Arial Bold", 1, 35, 163 + 1)]
        [InlineData("Arial", FontStyle.Regular, 70, 64, 82,
            1.8, 15, "Arial", 0, 35, 149 - 1)]
        [InlineData("Times New Roman", FontStyle.BoldItalic, 47, 42, 55,
            1.3, 11, "Times New Roman Bold Italic", 3, 18 + 1, 97)]
        [InlineData("Times New Roman", FontStyle.Italic, 47, 42, 55,
            1.3, 11, "Times New Roman Italic", 2, 18 + 1, 95 - 1)]
        [InlineData("Times New Roman", FontStyle.Bold, 47, 42, 55,
            1.3, 11, "Times New Roman Bold", 1, 21, 97)]
        [InlineData("Times New Roman", FontStyle.Regular, 47, 42, 55,
            1.3, 11, "Times New Roman", 0, 21, 92 + 2)]
        public void ShouldMeasure(string name, FontStyle style, int size,
            int ascent, int height, double baseOff, int descent,
            string fontName, int styleNum, int charW, int strW)
        {
            var fonts = Graphics.FontManager;
            var font = fonts.Create(new FontDescriptor(name, style, size));
            var m = font.GetFontMetrics();
            Assert.Equal(fontName, font.FontName);
            Assert.Equal(name, font.Name);
            Assert.Equal(name, font.Family);
            Assert.Equal(size, font.Size);
            Assert.Equal(styleNum, (int)font.Style);
            Assert.Equal(style, font.Style);
            Assert.Equal(ascent, m.Ascent);
            Assert.Equal(descent, m.Descent);
            Assert.Equal(height, m.Height);
            Assert.Equal(baseOff, (m.Height - m.Ascent) / 10.0);
            Assert.Equal((charW, strW),
                (m.CharWidth('z'), m.StringWidth("hello")));
        }
    }
}