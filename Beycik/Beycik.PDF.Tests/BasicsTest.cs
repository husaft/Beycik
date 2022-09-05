using Beycik.Draw;
using Beycik.Draw.Fonts.API;
using Beycik.PDF.Text;
using Beycik.PDF.Tools;
using Xunit;

namespace Beycik.PDF.Tests
{
    public class BasicsTest
    {
        [Theory]
        [InlineData("Helvetica", FontStyle.Regular, 7, false, 8.9, 1.8, 25.699999999999996, 7.9, 6.4, 1.5, 256, 82)]
        [InlineData("Helvetica", FontStyle.Bold, 9, true, 11.4, 2.3, 34.2, 10.2, 8.2, 2, 342, 105)]
        [InlineData("Helvetica", FontStyle.Regular, 9, false, 11.4, 2.3, 33, 10.2, 8.2, 2, 329, 105)]
        public void ShouldCheckFont(string family, FontStyle style, double size,
            bool bold, double height, double baseOff, double w,
            double rh, double asc, double des, double uw, double fh)
        {
            var fontManager = Graphics.FontManager;
            var data = new FontData(family, style, size, fontManager);

            Assert.Equal(family, data.Family);
            Assert.False(data.Italic);
            Assert.Equal(bold, data.Bold);
            Assert.Equal(style, data.Style);
            Assert.Equal(size, data.RealSize);
            Assert.Equal(size, data.Size);
            Assert.Equal(height, data.Height);
            Assert.Equal(baseOff, data.BaseOffset);
            Assert.Equal(rh, data.RealHeight);
            Assert.Equal(asc, data.Ascent);
            Assert.Equal(des, data.Descent);
            Assert.Equal(size, data.UnscaledSize);

            const double factor = PdfConst.FontFactor;
            Assert.NotNull(data.Font);
            Assert.Equal(size * factor, data.Font.Size);
            Assert.NotNull(data.Metrics);
            Assert.Equal(asc * factor, data.Metrics.Ascent);
            Assert.Equal(des * factor, data.Metrics.Descent);
            Assert.Equal(fh, data.Metrics.Height);

            const string txt = "aAvTqQ";
            Assert.Equal(w, data.GetCharWidth(txt));
            Assert.Equal(uw, data.GetStringWidth(txt));
        }
    }
}