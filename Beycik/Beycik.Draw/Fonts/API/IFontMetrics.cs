namespace Beycik.Draw.Fonts.API
{
    public interface IFontMetrics
    {
        int Height { get; }
        int Ascent { get; }
        int Descent { get; }
        float StringWidth(string text);
        float CharWidth(char text);
    }
}