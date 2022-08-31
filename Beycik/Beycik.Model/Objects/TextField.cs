using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.Model.Objects.Scraps;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("TEXTFIELD")]
    public sealed class TextField : AbstractText, IContent, INameable, 
        IValidateable, IColor, ITextItem 
    {
        [XmlIgnore]
        public byte? FontBlue { get; set; }
        
        [XmlAttribute("fontblue")]
        public string FontBlueStr
        {
            get => ValueEx.FormatByte(FontBlue);
            set => FontBlue = ValueEx.ParseByte(value);
        }

        [XmlIgnore]
        public byte? FontGreen { get; set; }

        [XmlAttribute("fontgreen")]
        public string FontGreenStr
        {
            get => ValueEx.FormatByte(FontGreen);
            set => FontGreen = ValueEx.ParseByte(value);
        }

        [XmlIgnore]
        public byte? FontRed { get; set; }
        
        [XmlAttribute("fontred")]
        public string FontRedStr
        {
            get => ValueEx.FormatByte(FontRed);
            set => FontRed = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public Direction? Align { get; set; }
        
        [XmlAttribute("align")]
        public string AlignStr
        {
            get => ValueEx.FormatEnum(Align);
            set => Align = ValueEx.TryParseEnum<Direction>(value);
        }

        [XmlAttribute("maxlen")]
        public byte MaxLen { get; set; }
        
        [XmlAttribute("validate3")]
        public string Validate3 { get; set; }

        [XmlAttribute("valparam3")]
        public string ValParam3 { get; set; }
        
        [XmlAttribute("validate4")]
        public string Validate4 { get; set; }

        [XmlAttribute("valparam4")]
        public string ValParam4 { get; set; }
        
        [XmlAttribute("validate5")]
        public string Validate5 { get; set; }

        [XmlAttribute("valparam5")]
        public string ValParam5 { get; set; }

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
        public short? Group { get; set; }
        
        [XmlAttribute("group")]
        public string GroupStr
        {
            get => ValueEx.FormatShort(Group);
            set => Group = ValueEx.ParseShort(value);
        }
        
        [XmlIgnore]
        public byte? HtmlHidden { get; set; }
        
        [XmlAttribute("htmlhidden")]
        public string HtmlHiddenStr
        {
            get => ValueEx.FormatByte(HtmlHidden);
            set => HtmlHidden = ValueEx.ParseByte(value);
        }
        
        [XmlText]
        public string Content { get; set; }
    }
}