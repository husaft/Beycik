using System;
using Beycik.Model.Roots;
using Beycik.PDF.Config;

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

        public void Save(string filePath, PdfOptions options, IConfig config)
        {








            throw new NotImplementedException();
        }
    }
}