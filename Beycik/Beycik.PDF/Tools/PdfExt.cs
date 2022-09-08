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

        public static readonly StringComparison Ord
            = StringComparison.Ordinal;

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

        public static string T(this double value, string format = null)
        {
            var txt = format == null
                ? value.ToString(Inv)
                : value.ToString(format, Inv);
            return txt.Contains('.') ? txt : $"{txt}.0";
        }

        public static string T(this decimal value, string format = "N17")
        {
            var txt = value.ToString(format, Inv);
            return txt.Contains('.') ? txt : $"{txt}.0";
        }

        public static bool Is(this double first, double second)
        {
            return Math.Abs(first - second) < 0.001;
        }

        public static string ParseEntry(string src, int count, string term)
        {
            if (src == null)
                return null;
            var start = 0;
            for (var i = 0; i < count; ++i)
            {
                if ((start = src.IndexOf(term, start, Ord)) == -1)
                    return null;
                ++start;
            }
            int end;
            if ((end = src.IndexOf(term, start, Ord)) == -1)
            {
                end = src.Length;
            }
            var length = end - start;
            return src.Substring(start, length);
        }
    }
}