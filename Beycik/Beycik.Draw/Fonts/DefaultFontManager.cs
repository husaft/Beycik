using System.Collections.Generic;
using Beycik.Draw.Fonts.API;
using SixLabors.Fonts;

namespace Beycik.Draw.Fonts
{
    internal class DefaultFontManager : IFontExManager
    {
        private readonly FontCollection _collection;
        private readonly IDictionary<string, string> _mapping;

        public DefaultFontManager(bool addSystemFonts = true)
        {
            _collection = new FontCollection();
            _mapping = new Dictionary<string, string>
            {
                { "Helvetica", "Arial" },
                { "Courier", "Courier New" },
                { "MetaCorr", "Arial" }
            };
            if (addSystemFonts) _collection.AddSystemFonts();
        }

        IDictionary<string, string> IFontExManager.Mapping => _mapping;
        FontCollection IFontExManager.Fonts => _collection;

        public IFont Create(FontDescriptor desc)
        {
            var fontName = desc.Face;
            var fontSize = desc.Size;
            var fontStyle = desc.Style.Convert();
            if (!_collection.TryGet(fontName, out _) &&
                _mapping.TryGetValue(fontName, out var newFontName))
                fontName = newFontName;
            var font = _collection.Get(fontName).CreateFont(fontSize, fontStyle);
            return new DefaultFont(font);
        }
    }
}