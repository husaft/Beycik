using System.Collections.Generic;
using Beycik.Draw.Fonts.API;
using Beycik.PDF.Tools;

namespace Beycik.PDF.Text
{
    internal sealed class FontTable
    {
        private readonly List<FontData> _fonts;

        public FontTable()
        {
            _fonts = new List<FontData>();
        }

        public FontData RegisterFont(string family, FontStyle style,
            double size, IFontManager fonts)
        {
            foreach (var item in _fonts)
                if ((item.Family?.Equals(family) ?? false) && item.Style == style && item.Size.Is(size))
                    return item;
            var data = new FontData(family, style, size, fonts);
            _fonts.Add(data);
            return data;
        }
    }
}