using System.Collections.Generic;
using Beycik.Draw.Fonts.API;
using SixLabors.Fonts;

namespace Beycik.Draw.Fonts
{
    internal class DefaultFontManager : IFontManager
    {
        private readonly IDictionary<string, string> _mapping;

        public DefaultFontManager()
        {
            _mapping = new Dictionary<string, string>
            {
                { "Helvetica", "Arial" },
                { "Courier", "Courier New" }
            };
        }

        public IFont Create(FontDescriptor desc)
        {
            var fontName = desc.Face;
            var fontSize = desc.Size;
            var fontStyle = desc.Style.Convert();
            if (!SystemFonts.TryGet(fontName, out _) &&
                _mapping.TryGetValue(fontName, out var newFontName))
                fontName = newFontName;
            var font = SystemFonts.CreateFont(fontName, fontSize, fontStyle);
            return new DefaultFont(font);
        }
    }
}