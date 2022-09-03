using System;
using System.Globalization;
using Beycik.PDF.Text;

namespace Beycik.PDF.Tools
{
    internal static class PdfExt
    {
        public static readonly CultureInfo Inv
            = CultureInfo.InvariantCulture;
        public static readonly StringComparison InvIgn
            = StringComparison.InvariantCultureIgnoreCase;

        public static string CleanText(string text)
        {
            return text.Replace("\\", "\\\\")
                .Replace("(", "\\(")
                .Replace(")", "\\)");
        }

        public static string ToName(this FontEncoding encoding)
        {
            if (encoding == default)
                return string.Empty;

            var name = encoding.ToString();
            var combined = $"{name}Encoding";
            return combined;
        }

        public static double Round2(this double value) => Math.Round(value, 2);

        public static string T(this double value)
        {
            var txt = value.ToString(Inv);
            return txt.Contains('.') ? txt : $"{txt}.0";
        }

        public static string T(this decimal value)
        {
            var txt = value.ToString("N17", Inv);
            return txt.Contains('.') ? txt : $"{txt}.0";
        }

        public static bool Is(this double first, double second)
        {
            return Math.Abs(first - second) < 0.001;
        }
    }
}