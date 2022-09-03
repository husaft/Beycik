namespace Beycik.PDF.Tools
{
    internal static class PdfExt
    {
        public static string CleanText(string text)
        {
            return text.Replace("\\", "\\\\")
                .Replace("(", "\\(")
                .Replace(")", "\\)");
        }
    }
}