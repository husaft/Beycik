using System;
using Beycik.Draw;
using Beycik.Model.Roots;
using Beycik.PDF.Config;
using Beycik.Draw.Fonts.API;
using Beycik.PDF.Core;
using Beycik.PDF.Text;
using Beycik.PDF.Visuals;
using static Beycik.PDF.Tools.PdfConst;
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

        private static (double width, double height) GetPageSize(XmlDoc doc)
        {
            var pageSize = doc.FormInfo.PageSize;
            var pageHeight = ((pageSize.Height ?? DinA4H) * PicaPerMm).Round2();
            var pageWidth = ((pageSize.Width ?? DinA4W) * PicaPerMm).Round2();
            return (width: pageWidth, height: pageHeight);
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
            var (pageWidth, pageHeight) = GetPageSize(doc);
            var pdf = new PdfDocument(config, options);

            var pages = pdf.Catalog.Pages.Pages;
            var pageIdx = -1;
            foreach (var item in doc.Objects.Items)
                while (pageIdx < item.Page)
                {
                    ++pageIdx;
                    var page = pdf.CreatePage(pageIdx, pageWidth, pageHeight);
                    if (options.PrintOnly)
                    {
                        page.Stream.SetColor(Colors.Gray);
                    }
                }

            foreach (var item in doc.Objects.Items)
            {
                var page = pages[item.Page];
                var font = FontHandle.ApplyFrom(item);
                var rect = PdfRect.ApplyFrom(item);

                // TODO
            }

            return pdf;
        }
    }
}