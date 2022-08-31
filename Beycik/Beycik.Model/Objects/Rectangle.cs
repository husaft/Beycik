using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.Model.Objects.Scraps;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("RECTANGLE")]
    public sealed class Rectangle : AbstractBox, IIdentifiable, IColor, ISized
    {
        [XmlIgnore]
        public DrawType? DrawType { get; set; }

        [XmlAttribute("drawtype")]
        public string DrawTypeStr
        {
            get => ValueEx.FormatEnum(DrawType);
            set => DrawType = ValueEx.TryParseEnum<DrawType>(value);
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
        
        [XmlIgnore]
        public Shape? Shape { get; set; }

        [XmlAttribute("shape")]
        public string ShapeStr
        {
            get => ValueEx.FormatEnum(Shape);
            set => Shape = ValueEx.TryParseEnum<Shape>(value);
        }
        
        [XmlIgnore]
        public char? Orientation { get; set; }
        
        [XmlAttribute("orientation")]
        public string OrientationStr
        {
            get => ValueEx.FormatChar(Orientation);
            set => Orientation = ValueEx.ParseChar(value);
        }
    }
}