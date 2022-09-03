using System.Collections.Generic;
using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;
using Beycik.PDF.Text;
using static Beycik.PDF.Text.FontEncoding;
using static Beycik.PDF.Tools.PdfExt;

namespace Beycik.PDF.Core
{
    internal class PdfFonts : PdfObject
    {
        private readonly List<PdfFont> _fonts;

        public PdfFonts(IConfig c) : base(c)
        {
            _fonts = new List<PdfFont>
            {
                new(c, "Helvetica", "Helv", false, WinAnsi),
                new(c, "Helvetica", "HeBo", false, WinAnsi),
                new(c, "ZapfDingbats", "ZaDb", false, NotInclude),
                new(c, "Courier", "Cour", false, WinAnsi)
            };
        }

        public override int Write(Stream stream, PdfXref xRef, int pos, PdfDocument doc)
        {
            var off = 0;
            foreach (var font in _fonts)
                off += font.Write(stream, xRef, pos + off, doc);
            return off;
        }

        public override int ReNumber(int id)
        {
            if (_fonts.Count != 0)
                foreach (var font in _fonts)
                    id = font.ReNumber(id);
            return id;
        }

        public int GetIdByName(string name, FontEncoding encoding = WinAnsi)
        {
            foreach (var font in _fonts)
                if (font.Name.Equals(name, InvIgn) && font.Encoding == encoding)
                    return font.Id;
            return 0;
        }
    }
}