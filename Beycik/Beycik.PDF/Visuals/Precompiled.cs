using System.Collections.Generic;
using static Beycik.PDF.Tools.PdfConst;

namespace Beycik.PDF.Visuals
{
    internal static class Precompiled
    {
        internal static readonly Dictionary<string, IDictionary<int, double>> LineHeight = new()
        {
            {
                Helvetica, new Dictionary<int, double>
                {
                    { 5, 6.4 }, { 6, 7.7 }, { 7, 8.9 }, { 8, 10.19 },
                    { 9, 11.4 }, { 10, 12.7 }, { 11, 13.9 }, { 12, 15.2 },
                    { 13, 16.39 }, { 14, 17.7 }, { 15, 18.89 }, { 16, 20.2 },
                    { 17, 21.4 }, { 18, 22.7 }, { 19, 23.9 }, { 20, 25.3 }
                }
            }
        };
    }
}