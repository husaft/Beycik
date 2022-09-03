using System;
using Beycik.Model.Roots;
using Beycik.PDF.Config;
using Beycik.Draw.Fonts.API;
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

        public void Save(string pdfFile, PdfOptions options,
            IConfig cfg = null, IFontManager fm = null)
        {
            var config = cfg ?? new PdfConfig();
            FillConfig(config, _doc);

            throw new NotImplementedException();
        }
    }
}