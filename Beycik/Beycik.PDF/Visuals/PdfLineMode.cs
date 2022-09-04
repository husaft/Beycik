using Beycik.PDF.Tools;

namespace Beycik.PDF.Visuals
{
    public class PdfLineMode
    {
        private double On { get; set; }
        private double Off { get; set; }
        private double Width { get; set; }
        private bool Changed { get; set; }

        public PdfLineMode()
        {
            On = 0.0D;
            Off = 0.0D;
            Width = 1.0D;
            Changed = true;
        }

        public string Get()
        {
            var ret = string.Empty;
            if (Changed)
            {
                if (On == 0.0D && Off == 0.0D)
                    ret += "2 J [] 0 d ";
                else
                    ret = $"{ret}2 J [{On.T()} {Off.T()}] 0 d ";
                ret = $"{ret}{Width.T()} w ";
                Changed = false;
            }
            return ret;
        }

        public void Set(double width, double on, double off)
        {
            if (!On.Is(on) || !Off.Is(off) || !Width.Is(width))
            {
                Changed = true;
                On = on;
                Off = off;
                Width = width;
            }
        }
    }
}