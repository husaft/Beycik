using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("TEXTAREA")]
    public sealed class TextArea : AbstractText, IContent, INameable, ITextItem 
    {
        [XmlIgnore]
        public short? Group { get; set; }
        
        [XmlAttribute("group")]
        public string GroupStr
        {
            get => ValueEx.FormatShort(Group);
            set => Group = ValueEx.ParseShort(value);
        }
        
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
        
        [XmlIgnore]
        public byte? HtmlHidden { get; set; }
        
        [XmlAttribute("htmlhidden")]
        public string HtmlHiddenStr
        {
            get => ValueEx.FormatByte(HtmlHidden);
            set => HtmlHidden = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? PdfAndPrintFontDownSizing { get; set; }
        
        [XmlAttribute("pdfandprintfontdownsizing")]
        public string PdfAndPrintFontDownSizingStr
        {
            get => ValueEx.FormatByte(PdfAndPrintFontDownSizing);
            set => PdfAndPrintFontDownSizing = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? FsBase { get; set; }
        
        [XmlAttribute("fsbase")]
        public string FsBaseStr
        {
            get => ValueEx.FormatByte(FsBase);
            set => FsBase = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? FsMin { get; set; }
        
        [XmlAttribute("fsmin")]
        public string FsMinStr
        {
            get => ValueEx.FormatByte(FsMin);
            set => FsMin = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public short? MaxLen { get; set; }
        
        [XmlAttribute("maxlen")]
        public string MaxLenStr
        {
            get => ValueEx.FormatShort(MaxLen);
            set => MaxLen = ValueEx.ParseShort(value);
        }
        
        [XmlText]
        public string Content { get; set; }
    }
}