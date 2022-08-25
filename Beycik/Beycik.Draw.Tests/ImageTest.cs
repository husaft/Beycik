using Xunit;

namespace Beycik.Draw.Tests
{
    public class ImageTest
    {
        [Theory]
        [InlineData("bmp", 15, 15)]
        [InlineData("gif", 18, 18)]
        [InlineData("jpg", 16, 16)]
        [InlineData("png", 17, 17)]
        [InlineData("tiff", 14, 14)]
        [InlineData("webp", 20, 20)]
        public void ShouldLoadTux(string type, int w, int h)
        {
            var images = Graphics.ImageLoader;
            var data = TestUtils.LoadBytes(GetType(), $"tux.{type}");
            using var img = images.Load(data, type);
            Assert.Equal(w, img.Width);
            Assert.Equal(h, img.Height);
        }
    }
}