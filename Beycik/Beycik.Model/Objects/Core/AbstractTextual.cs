using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Scraps;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects.Core
{
    public abstract class AbstractTextual : AbstractText, IFontColor, ISized
    {
        [XmlIgnore]
        public Direction Align { get; set; }
        
        [XmlAttribute("align")]
        public string AlignStr
        {
            get => ValueEx.FormatEnum(Align);
            set => Align = ValueEx.ParseEnum<Direction>(value);
        }
        
        [XmlIgnore]
        public float? LineHeight { get; set; }
        
        [XmlAttribute("lineheight")]
        public string LineHeightStr
        {
            get => ValueEx.FormatFloat(LineHeight);
            set => LineHeight = ValueEx.ParseFloat(value);
        }
        
        [XmlAttribute("angle")]
        public byte Angle { get; set; }

        [XmlAttribute("fontblue")]
        public byte FontBlue { get; set; }

        [XmlAttribute("fontgreen")]
        public byte FontGreen { get; set; }

        [XmlAttribute("fontred")]
        public byte FontRed { get; set; }
    }
}