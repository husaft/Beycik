using System.Collections.Generic;
using SixLabors.Fonts;

namespace Beycik.Draw.Fonts.API
{
    public interface IFontExManager : IFontManager
    {
        IDictionary<string, string> Mapping { get; }

        FontCollection Fonts { get; }
    }
}