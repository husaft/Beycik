using System.Collections.Generic;
using System.IO;
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

        public string Register(byte[] data, int width, int height, bool gray)
        {
            var count = _images.Count + 1;
            var imageName = $"I{count}";
            _images.Add(new PdfImage(Config, data, width, height, imageName, gray));
            return imageName;
        }
    }
}