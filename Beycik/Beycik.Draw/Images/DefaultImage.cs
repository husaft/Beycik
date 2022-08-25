using SixLabors.ImageSharp;
using IImage = Beycik.Draw.Images.API.IImage;

namespace Beycik.Draw.Images
{
    internal class DefaultImage : IImage
    {
        private readonly Image _parent;

        public DefaultImage(Image image)
        {
            _parent = image;
        }

        public int Width => _parent.Width;

        public int Height => _parent.Height;

        public void Dispose()
        {
            _parent.Dispose();
        }
    }
}