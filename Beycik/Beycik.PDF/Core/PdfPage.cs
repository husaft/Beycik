using System.Collections.Generic;
using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;
using Beycik.PDF.Tools;
using static Beycik.PDF.Tools.PdfExt;

namespace Beycik.PDF.Core
{
    internal sealed class PdfPage : PdfObject
    {
        public int ParentId { get; set; }
        public double Width { get; }
        public double Height { get; }
        public int PageIdx { get; }
        public PdfStream Stream { get; }
        public PdfAnnotations Annotations { get; }

        private readonly List<string> _fontNames;
        private readonly List<string> _imageNames;
        private readonly PdfDocument _doc;

        public PdfPage(IConfig config, int pageIdx,
            double width, double height, PdfDocument doc) : base(config)
        {
            _doc = doc;
            _fontNames = new List<string>();
            _imageNames = new List<string>();
            PageIdx = pageIdx;
            Width = width;
            Height = height;
            Stream = new PdfStream(Config);
            Annotations = new PdfAnnotations(Config);
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument doc)
        {
            var off = WriteHead(stream);
            xRef.Register(pos, 0, 'n');
            var tmp = $"<< /Type /Page\n/Parent {ParentId} 0 R\n/Annots " +
                      $"{Annotations.Id} 0 R\n/MediaBox [ 0 0 {Width.T()} {Height.T()} ]" +
                      $"\n/Contents [ {Stream.Id} {Stream.Version} R ]\n";
            tmp += "/Resources\n<<";
            tmp += " /ProcSet [ /PDF /ImageC ] \n";
            if (_fontNames.Count != 0)
            {
                tmp += " /Font << ";
                foreach (var t in _fontNames)
                {
                    var fontId = doc.Fonts.GetIdByName(t);
                    tmp = $"{tmp}/{t} {fontId} 0 R\n";
                }
                tmp += ">>";
            }
            if (_imageNames.Count != 0)
            {
                tmp += "/XObject<<";
                foreach (var t in _imageNames)
                {
                    var imageId = doc.Images.GetIdByName(t);
                    tmp = $"{tmp}/{t} {imageId} 0 R\n";
                }
                tmp += ">>\n";
            }
            tmp += ">>\n>>\nendobj\n";
            off += Write(stream, tmp);
            off += Stream.Write(stream, xRef, pos + off, doc);
            off += Annotations.Write(stream, xRef, pos + off, doc);
            return off;
        }

        public override int ReNumber(int id)
        {
            id = base.ReNumber(id);
            id = Stream.ReNumber(id);
            return Annotations.ReNumber(id);
        }

        public void RegisterFont(string name)
        {
            foreach (var fontName in _fontNames)
                if (fontName.Equals(name, InvIgn))
                    return;
            _fontNames.Add(name);
        }

        public string RegisterImage(byte[] data, int width, int height, bool gray)
        {
            var name = _doc.RegisterImage(data, width, height, gray);
            _imageNames.Add(name);
            return name;
        }
    }
}