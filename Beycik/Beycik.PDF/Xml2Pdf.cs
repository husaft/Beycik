using System;
using Beycik.Draw;
using Beycik.Model.Roots;
using Beycik.PDF.Config;
using Beycik.Draw.Fonts.API;
using Beycik.PDF.Core;
using Beycik.PDF.Text;
using static Beycik.PDF.Tools.PdfExt;

namespace Beycik.PDF
{
    public sealed class Xml2Pdf : IDisposable
    {
        private readonly XmlDoc _doc;

        public Xml2Pdf(XmlDoc doc)
        {
            _doc = doc;
        }

        public void Dispose()
        {
        }

        private static void FillConfig(IConfig config, XmlDoc model)
        {
            config.Title ??= model.FormInfo.FormServer.FormName;
            config.Title = CleanText(config.Title);
            config.Author ??= model.FormInfo.FormServer.Copyright;
            config.Author = CleanText(config.Author);
        }

        public int Save(string pdfFile, PdfOptions options, IConfig cfg = null,
            IFontManager fm = null, IEncodingPatcher enc = null)
        {
            var config = cfg ?? new PdfConfig();
            FillConfig(config, _doc);

            var fonts = fm ?? Graphics.FontManager;
            var defEnc = enc ?? new DefaultEncPatcher();

            var pdf = Transform(fonts, defEnc, _doc, config, options);
            var size = pdf.ExportToFile(pdfFile);
            return size;
        }

        private static PdfDocument Transform(IFontManager fonts, IEncodingPatcher enc,
            XmlDoc doc, IConfig config, PdfOptions options)
        {
            var pdf = new PdfDocument(config, options);

            // TODO

            return pdf;
        }
    }
}