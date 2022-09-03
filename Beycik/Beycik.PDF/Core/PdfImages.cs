using System.Collections.Generic;
using System.IO;
using System.Text;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal sealed class PdfImages : PdfObject
    {
        private readonly List<PdfImage> _images;

        public PdfImages(IConfig config) : base(config)
        {
            _images = new List<PdfImage>();
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument pdf)
        {
            var off = 0;
            foreach (var image in _images)
                off += image.Write(stream, xRef, pos + off, pdf);
            return off;
        }

        public override int ReNumber(int id)
        {
            foreach (var image in _images)
                id = image.ReNumber(id);
            return id;
        }

        public int GetIdByName(string name)
        {
            foreach (var image in _images)
                if (image.Name.Equals((object)name))
                    return image.Id;
            return 0;
        }

        public string Register(byte[] obj0, int obj1, int obj2, bool obj3)
        {
            var count = _images.Count + 1;
            var imageName = $"I{count}";
            _images.Add(new PdfImage(Config, obj0, obj1, obj2, imageName, obj3));
            return imageName;
        }
    }
}