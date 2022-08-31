using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Tools;

namespace Beycik.Model.Core
{
    public sealed class Size : ISize
    {
        [XmlIgnore] 
        public float? Height { get; set; }

        [XmlAttribute("height")]
        public string HeightStr
        {
            get => ValueEx.FormatFloat(Height);
            set => Height = ValueEx.ParseFloat(value);
        }

        [XmlIgnore] 
        public float? Width { get; set; }

        [XmlAttribute("width")]
        public string WidthStr
        {
            get => ValueEx.FormatFloat(Width);
            set => Width = ValueEx.ParseFloat(value);
        }
    }
}