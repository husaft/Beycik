using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Tools;

namespace Beycik.Model.Core
{
    public class Color : IColor
    {
        [XmlIgnore]
        public byte? Blue { get; set; }
        
        [XmlAttribute("blue")]
        public string BlueStr
        {
            get => ValueEx.FormatByte(Blue);
            set => Blue = ValueEx.ParseByte(value);
        }

        [XmlIgnore]
        public byte? Green { get; set; }

        [XmlAttribute("green")]
        public string GreenStr
        {
            get => ValueEx.FormatByte(Green);
            set => Green = ValueEx.ParseByte(value);
        }

        [XmlIgnore]
        public byte? Red { get; set; }
        
        [XmlAttribute("red")]
        public string RedStr
        {
            get => ValueEx.FormatByte(Red);
            set => Red = ValueEx.ParseByte(value);
        }

        [XmlIgnore]
        public byte? Transparent { get; set; }
        
        [XmlAttribute("transparent")]
        public string TransparentStr
        {
            get => ValueEx.FormatByte(Transparent);
            set => Transparent = ValueEx.ParseByte(value);
        }
    }
}