using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("TEXTAREA")]
    public sealed class TextArea : AbstractText, IContent, INameable, ITextItem 
    {
        [XmlAttribute("group")]
        public short Group { get; set; }
        
        [XmlIgnore]
        public bool? IgnoreLines { get; set; }
        
        [XmlAttribute("ignorelines")]
        public string IgnoreLinesStr
        {
            get => ValueEx.FormatBool(IgnoreLines);
            set => IgnoreLines = ValueEx.ParseBool(value);
        }

        [XmlIgnore]
        public float? LineHeight { get; set; }
        
        [XmlAttribute("lineheight")]
        public string LineHeightStr
        {
            get => ValueEx.FormatFloat(LineHeight);
            set => LineHeight = ValueEx.ParseFloat(value);
        }

        [XmlAttribute("lines")]
        public byte Lines { get; set; }

        [XmlIgnore]
        public bool? Active { get; set; }
        
        [XmlAttribute("active")]
        public string ActiveStr
        {
            get => ValueEx.FormatBool(Active);
            set => Active = ValueEx.ParseBool(value);
        }

        [XmlIgnore]
        public float? LineSize { get; set; }
        
        [XmlAttribute("linesize")]
        public string LineSizeStr
        {
            get => ValueEx.FormatFloat(LineSize);
            set => LineSize = ValueEx.ParseFloat(value);
        }
        
        [XmlAttribute("htmlhidden")]
        public byte HtmlHidden { get; set; }

        [XmlAttribute("pdfandprintfontdownsizing")]
        public byte PdfAndPrintFontDownSizing { get; set; }

        [XmlAttribute("fsbase")]
        public byte FsBase { get; set; }

        [XmlAttribute("fsmin")]
        public byte FsMin { get; set; }

        [XmlAttribute("maxlen")]
        public short MaxLen { get; set; }

        [XmlText]
        public string Content { get; set; }
    }
}