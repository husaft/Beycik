﻿using System.Text;

namespace Beycik.PDF.Config
{
    public class PdfConfig : IConfig
    {
        public PdfConfig(Encoding enc = null)
        {
            Enc = enc ?? Encoding.GetEncoding("ISO-8859-1");
        }

        public Encoding Enc { get; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string CreatorName { get; set; }
        public string CreatorVersion { get; set; }
        public string ProducerName { get; set; }
        public string ProducerWeb { get; set; }

        public Quirks Quirks { get; set; }
    }
}