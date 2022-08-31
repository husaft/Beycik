using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("LINE")]
    public sealed class Line : ObjectNode, IIdentifiable, IColor
    {
        [XmlIgnore]
        public float? X2 { get; set; }

        [XmlAttribute("x2")]
        public string X2Str
        {
            get => ValueEx.FormatFloat(X2);
            set => X2 = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? Y2 { get; set; }
        
        [XmlAttribute("y2")]
        public string Y2Str
        {
            get => ValueEx.FormatFloat(Y2);
            set => Y2 = ValueEx.ParseFloat(value);
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