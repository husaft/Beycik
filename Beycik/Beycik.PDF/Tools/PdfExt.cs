using System;
using Beycik.PDF.Text;

namespace Beycik.PDF.Tools
{
    internal static class PdfExt
    {
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
    }
}