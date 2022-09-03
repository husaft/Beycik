using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;

namespace Beycik.PDF.Core
{
    internal abstract class PdfObject
    {
        public int Id { get; set; }
        public int Version { get; set; }

        protected IConfig Config { get; }

        protected PdfObject(IConfig config)
        {
            Config = config;
        }

        public abstract int Write(Stream stream, PdfXref xRef, int pos, PdfDocument pdf);

        public int WriteHead(Stream stream)
        {
            var e = Config.Enc;
            var bin = e.GetBytes($"{Id} {Version} obj\n");
            stream.Write(bin);
            return bin.Length;
        }

        protected int Write(Stream stream, string text)
        {
            var e = Config.Enc;
            var bin = e.GetBytes(text);
            stream.Write(bin);
            return bin.Length;
        }
    }
}