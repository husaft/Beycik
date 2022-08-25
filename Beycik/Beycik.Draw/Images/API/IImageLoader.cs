namespace Beycik.Draw.Images.API
{
    public interface IImageLoader
    {
        IImage Load(byte[] data, string type);
    }
}