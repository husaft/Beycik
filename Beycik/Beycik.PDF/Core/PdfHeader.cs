using System.IO;
using Beycik.PDF.Config;

namespace Beycik.PDF.Core
{
    internal class PdfHeader
    {
        public const string PdfVersion = "1.4";

        private readonly IConfig _config;

        public PdfHeader(IConfig config)
        {
            _config = config;
        }

        public int Write(Stream stream)
        {
            var array = _config.Enc.GetBytes($"%PDF-{PdfVersion}\n");
            stream.Write(array);
            var length = array.Length;
            array = new byte[] { 0x25, 0xAA, 0xAB, 0xAC, 0xAD, 0x0A };
            stream.Write(array);
            length += array.Length;
            return length;
        }
    }
}