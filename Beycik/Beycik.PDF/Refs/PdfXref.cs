using System.Collections.Generic;
using System.IO;
using Beycik.PDF.Config;

namespace Beycik.PDF.Refs
{
    internal class PdfXref
    {
        private readonly IConfig _config;
        private readonly List<PdfXrefEntry> _entries;

        public PdfXref(IConfig config)
        {
            _config = config;
            var li = new PdfXrefEntry(0, ushort.MaxValue, 'f');
            _entries = new List<PdfXrefEntry> { li };
        }

        public void Register(int offset, int gen, char use)
        {
            var li = new PdfXrefEntry(offset, gen, use);
            _entries.Add(li);
        }

        public int Write(Stream stream, int pos)
        {
            var e = _config.Enc;
            var array = e.GetBytes($"xref\n0 {_entries.Count}\n");
            stream.Write(array);

            foreach (var li in _entries)
            {
                var tmp = li.Offset.ToString();
                var pad = "0000000000";
                var ofsStr = pad[tmp.Length..] + tmp;
                tmp = li.Gen.ToString();
                pad = "00000";
                var genStr = pad[tmp.Length..] + tmp;
                array = e.GetBytes($"{ofsStr} {genStr} {li.Use} \n");
                stream.Write(array);
            }

            var t = $"\ntrailer\n<</Size {_entries.Count}\n/Root " +
                    $"2 0 R\n/Info 1 0 R\n>>\nstartxref\n{pos}\n%%EOF";
            array = e.GetBytes(t);
            stream.Write(array);
            return 1;
        }
    }
}