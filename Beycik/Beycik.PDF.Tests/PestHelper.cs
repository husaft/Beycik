using System;
using Beycik.PDF.Config;

namespace Beycik.PDF.Tests
{
    internal static class PestHelper
    {
        internal static IConfig GetStd(Func<double?> boPatch)
            => new PdfConfig
            {
                ProducerWeb = "http://www.fjd.de",
                ProducerName = "cirali-pdf Pdf-V74",
                CreatorName = "Cirali Output Manager",
                CreatorVersion = "B1-23",
                Quirks = new Quirks
                {
                    BaseOffsetFix = boPatch
                }
            };
    }
}