using Beycik.Draw.Fonts.API;

namespace Beycik.PDF.Text
{
    internal sealed class TextMetrics
    {
        private readonly FontTable _fontTable;

        public TextMetrics()
        {
            _fontTable = new FontTable();
        }

        private FontData _currentFont;

        public FontData RegisterFont(FontHandle font, IFontManager fonts)
        {
            _currentFont = _fontTable.RegisterFont(font.Face,
                font.FontAttributes, font.Size, fonts);
            return _currentFont;
        }

        public double CalcWidth(string s) => _currentFont.GetWidth(s);
    }
}