using Beycik.Draw.Fonts.API;
using FStyle = SixLabors.Fonts.FontStyle;

namespace Beycik.Draw.Fonts
{
    public static class FontTool
    {
        public static FStyle Convert(this FontStyle style)
        {
            var value = default(FStyle);
            if (style.HasFlag(FontStyle.Regular))
                value |= FStyle.Regular;
            if (style.HasFlag(FontStyle.Bold))
                value |= FStyle.Bold;
            if (style.HasFlag(FontStyle.Italic))
                value |= FStyle.Italic;
            return value;
        }

        public static FontStyle Convert(this FStyle style)
        {
            var value = default(FontStyle);
            if (style.HasFlag(FStyle.Regular))
                value |= FontStyle.Regular;
            if (style.HasFlag(FStyle.Bold))
                value |= FontStyle.Bold;
            if (style.HasFlag(FStyle.Italic))
                value |= FontStyle.Italic;
            return value;
        }

        public static FontStyle Convert(bool bold, bool italic)
        {
            var value = default(FontStyle);
            if (bold)
                value |= FontStyle.Bold;
            if (italic)
                value |= FontStyle.Italic;
            return value;
        }
    }
}