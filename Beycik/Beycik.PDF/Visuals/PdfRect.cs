using Beycik.Model.API;
using Beycik.Model.Objects.Core;

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
    }
}