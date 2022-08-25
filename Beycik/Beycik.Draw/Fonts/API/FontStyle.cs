using System;

namespace Beycik.Draw.Fonts.API
{
    [Flags]
    public enum FontStyle
    {
        Regular = 0,

        Bold = 1,

        Italic = 2,

        BoldItalic = Bold | Italic
    }
}