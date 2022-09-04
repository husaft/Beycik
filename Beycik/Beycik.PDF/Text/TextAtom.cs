namespace Beycik.PDF.Text
{
    internal sealed class TextAtom
    {
        public AtomType Type { get; }
        public FontData FontData { get; }
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }
        public bool Underline { get; }
        public string Text { get; }

        public double WsWidth { get; set; }
        public double Width { get; }

        public TextAtom(AtomType type, FontData data,
            int red, int green, int blue, bool underline)
        {
            Type = type;
            FontData = data;
            Red = red;
            Green = green;
            Blue = blue;
            Underline = underline;

            Width = 0.0;
            WsWidth = 0.0;
        }

        public TextAtom(string text, AtomType type,
            FontData data, double width, double wsWidth,
            int red, int green, int blue, bool underline)
        {
            Text = text;
            Type = type;
            Width = width;
            WsWidth = wsWidth;
            FontData = data;
            Red = red;
            Green = green;
            Blue = blue;
            Underline = underline;
        }
    }
}