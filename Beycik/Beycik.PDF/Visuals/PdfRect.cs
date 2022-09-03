using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.PDF.Tools;
using static Beycik.PDF.Tools.PdfConst;

namespace Beycik.PDF.Visuals
{
    internal record PdfRect(double Left, double Top, double Right, double Bottom)
    {
        public static PdfRect ApplyFrom(ObjectNode item)
        {
            var sizeObj = item as ISized;
            var left = sizeObj?.X ?? 0.0;
            var top = sizeObj?.Y ?? 0.0;
            var right = left + (sizeObj?.Width ?? 0.0);
            var bottom = top + (sizeObj?.Height ?? 0.0);

            return new PdfRect(left, top, right, bottom);
        }

        public static PdfRect CopyFrom(PdfRect orig)
        {
            var left = orig.Left;
            var right = orig.Right;
            var top = orig.Top;
            var bottom = orig.Bottom;

            return new PdfRect(left, top, right, bottom);
        }

        public double Width => Right - Left;
        public double Height => Top - Bottom;

        public PdfRect Convert(double pageHeight)
        {
            var left = Left * PicaPerMmD;
            var right = Right * PicaPerMmD;
            var top = Top * PicaPerMmD;
            var bottom = Bottom * PicaPerMmD;

            bottom = pageHeight - bottom;
            top = pageHeight - top;

            return new PdfRect(left, top, right, bottom);
        }

        public PdfRect Round()
        {
            var left = Left.Round2();
            var right = Right.Round2();
            var top = Top.Round2();
            var bottom = Bottom.Round2();

            return new PdfRect(left, top, right, bottom);
        }
    }
}