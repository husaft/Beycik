using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects.Scraps
{
    [XmlRoot("ATOM")]
    public sealed class Atom : IContent, IStyleable, IFontColor
    {
        [XmlText] 
        public string Content { get; set; }

        [XmlIgnore] 
        public bool? Bold { get; set; }
        
        [XmlAttribute("bold")] 
        public string BoldStr
        {
            get => ValueEx.FormatBool(Bold);
            set => Bold = ValueEx.ParseBool(value);
        }

        [XmlAttribute("fontface")] 
        public string FontFace { get; set; }

        [XmlIgnore] 
        public float? FontSize { get; set; }
        
        [XmlAttribute("fontsize")] 
        public string FontSizeStr
        {
            get => ValueEx.FormatFloat(FontSize, this);
            set => FontSize = ValueEx.ParseFloat(value, this);
        }
        
        [XmlIgnore] 
        public bool? Italic { get; set; }
        
        [XmlAttribute("italic")]
        public string ItalicStr
        {
            get => ValueEx.FormatBool(Italic);
            set => Italic = ValueEx.ParseBool(value);
        }
        
        [XmlIgnore] 
        public bool? Underline { get; set; }
        
        [XmlAttribute("underline")]
        public string UnderlineStr
        {
            get => ValueEx.FormatBool(Underline);
            set => Underline = ValueEx.ParseBool(value);
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