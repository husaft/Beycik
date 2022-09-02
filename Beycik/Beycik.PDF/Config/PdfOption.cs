namespace Beycik.PDF.Config
{
    public class PdfOption
    {
        public static PdfOptions GetInteractive()
        {
            return new PdfOptions
            {
                GenerateJavascriptForGlobals = true,
                GenerateJavascriptForCheckboxes = true,
                GenerateJavascriptForOpen = true,
                GenerateJavascriptForWorkaround = true,
                GenerateJavascriptForPrint = true,
            };
        }

        public static PdfOptions GetReadOnly()
        {
            return new PdfOptions
            {
                GenerateJavascriptForGlobals = false,
                GenerateJavascriptForCheckboxes = false,
                GenerateJavascriptForOpen = false,
                GenerateJavascriptForWorkaround = false,
                GenerateJavascriptForPrint = false
            };
        }
    }
}