using Beycik.Draw.Fonts;
using Beycik.Draw.Fonts.API;
using Beycik.Draw.Images;
using Beycik.Draw.Images.API;

namespace Beycik.Draw
{
    public static class Graphics
    {
        public static IFontManager FontManager { get; } = new DefaultFontManager();

        public static IImageLoader ImageLoader { get; } = new DefaultImageLoader();
    }
}