using Beycik.Draw.Images.API;
using SixLabors.ImageSharp;
using IImage = Beycik.Draw.Images.API.IImage;

namespace Beycik.Draw.Images
{
    internal class DefaultImageLoader : IImageLoader
    {
        public IImage Load(byte[] data, string _)
        {
            var image = Image.Load(data);
            return new DefaultImage(image);
        }
    }
}