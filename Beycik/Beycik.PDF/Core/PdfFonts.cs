using System.Collections.Generic;
using System.IO;
using Beycik.PDF.Config;
using Beycik.PDF.Refs;
using Beycik.PDF.Text;
using static Beycik.PDF.Text.FontEncoding;
using static Beycik.PDF.Tools.PdfConst;
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

        private static string GetPdfFontName(string faceName, bool bold, bool italic)
        {
            var pdfFace = Helvetica;
            if (faceName.StartsWith(Courier))
                pdfFace = Courier;
            switch (bold)
            {
                case true when italic:
                    pdfFace += $"-{BoldOblique}";
                    break;
                case true:
                    pdfFace += $"-{Bold}";
                    break;
                default:
                {
                    if (italic)
                        pdfFace += $"-{Oblique}";
                    break;
                }
            }
            return pdfFace;
        }

        public string Register(string faceName, bool bold, bool italic, FontEncoding enc)
        {
            var face = GetPdfFontName(faceName, bold, italic);
            foreach (var item in _fonts)
                if (item.Face.Equals(face) && item.Italic == italic && item.Encoding == enc)
                    return item.Name;
            var count = _fonts.Count + 1;
            var font = new PdfFont(Config, face, $"F{count}", italic, enc);
            _fonts.Add(font);
            return font.Name;
        }
    }
}