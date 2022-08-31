using System;
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
        public DrawType DrawType { get; set; }

        [XmlAttribute("drawtype")]
        public string DrawTypeStr
        {
            get => ValueEx.FormatEnum(DrawType);
            set => DrawType = Enum.Parse<DrawType>(value, true);
        }
        
        [XmlIgnore]
        public float? LineSize { get; set; }
        
        [XmlAttribute("linesize")]
        public string LineSizeStr
        {
            get => ValueEx.FormatFloat(LineSize);
            set => LineSize = ValueEx.ParseFloat(value);
        }

        [XmlAttribute("blue")]
        public byte Blue { get; set; }

        [XmlAttribute("transparent")]
        public byte Transparent { get; set; }

        [XmlAttribute("green")]
        public byte Green { get; set; }

        [XmlAttribute("red")]
        public byte Red { get; set; }
        
        [XmlIgnore]
        public Shape Shape { get; set; }

        [XmlAttribute("shape")]
        public string ShapeStr
        {
            get => ValueEx.FormatEnum(Shape);
            set => Shape = ValueEx.ParseEnum<Shape>(value);
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