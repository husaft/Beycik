namespace Beycik.Draw.Fonts.API
{
    public interface IFont
    {
        IFontMetrics GetFontMetrics();

        int Size { get; }
        string FontName { get; }
        string Family { get; }
        string Name { get; }
        FontStyle Style { get; }
    }
}