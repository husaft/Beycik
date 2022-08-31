using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Scraps;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects.Core
{
    public abstract class AbstractTextual : AbstractText, IFontColor, ISized
    {
        [XmlIgnore]
        public Direction? Align { get; set; }
        
        [XmlAttribute("align")]
        public string AlignStr
        {
            get => ValueEx.FormatEnum(Align);
            set => Align = ValueEx.TryParseEnum<Direction>(value);
        }
        
        [XmlIgnore]
        public float? LineHeight { get; set; }
        
        [XmlAttribute("lineheight")]
        public string LineHeightStr
        {
            get => ValueEx.FormatFloat(LineHeight);
            set => LineHeight = ValueEx.ParseFloat(value);
        }
        
        [XmlIgnore]
        public byte? Angle { get; set; }
        
        [XmlAttribute("angle")]
        public string AngleStr
        {
            get => ValueEx.FormatByte(Angle);
            set => Angle = ValueEx.ParseByte(value);
        }
        
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
    }
}