using System.IO;
using System.Text;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal sealed class PdfImage : PdfObject
    {
        public int Width { get; }
        public int Height { get; }
        public byte[] Data { get; }
        public string Name { get; }
        public bool IsGrayScale { get; }

        public PdfImage(IConfig config, byte[] data, int width, int height,
            string name, bool isGrayScale) : base(config)
        {
            Width = width;
            Height = height;
            Data = data;
            Name = name;
            IsGrayScale = isGrayScale;
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument pdf)
        {
            var off = WriteHead(stream);
            xRef.Register(pos, 0, 'n');
            off += Write(stream, "<< ") +
                   Write(stream, "/Type /XObject\n") +
                   Write(stream, "/Subtype /Image\n") +
                   Write(stream, $"/Name /{Name}\n") +
                   Write(stream, $"/Width {Width}\n") +
                   Write(stream, $"/Height {Height}\n") +
                   Write(stream, "/BitsPerComponent 8\n");
            return (!IsGrayScale
                       ? off + Write(stream, "/ColorSpace /DeviceRGB\n")
                       : off + Write(stream, "/ColorSpace /DeviceGray\n"))
                   + Write(stream, "/Filter [ /DCTDecode ] \n")
                   + Write(stream, $"/Length {Data.Length} >>\nstream\n")
                   + Write(stream, Data)
                   + Write(stream, "endstream\nendobj\n");
        }
    }
}