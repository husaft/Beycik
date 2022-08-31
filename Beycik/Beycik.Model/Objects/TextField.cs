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
        [XmlAttribute("fontblue")]
        public byte FontBlue { get; set; }

        [XmlAttribute("fontgreen")]
        public byte FontGreen { get; set; }

        [XmlAttribute("fontred")]
        public byte FontRed { get; set; }
        
        [XmlIgnore]
        public Direction Align { get; set; }
        
        [XmlAttribute("align")]
        public string AlignStr
        {
            get => ValueEx.FormatEnum(Align);
            set => Align = ValueEx.ParseEnum<Direction>(value);
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

        [XmlAttribute("fsbase")]
        public byte FsBase { get; set; }

        [XmlAttribute("fsmin")]
        public byte FsMin { get; set; }

        [XmlAttribute("group")]
        public short Group { get; set; }

        [XmlAttribute("htmlhidden")]
        public byte HtmlHidden { get; set; }

        [XmlText]
        public string Content { get; set; }
    }
}