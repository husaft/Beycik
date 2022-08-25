namespace Beycik.Draw.Fonts.API
{
    public interface IFontManager
    {
        IFont Create(FontDescriptor desc);
    }
}