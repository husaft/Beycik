using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Tools;

namespace Beycik.Model.Core
{
    public class Position : IPosition
    {
        [XmlIgnore]
        public float? X { get; set; }

        [XmlAttribute("x")]
        public string XStr
        {
            get => ValueEx.FormatFloat(X, this);
            set => X = ValueEx.ParseFloat(value, this);
        }

        [XmlIgnore]
        public float? Y { get; set; }
        
        [XmlAttribute("y")]
        public string YStr
        {
            get => ValueEx.FormatFloat(Y, this);
            set => Y = ValueEx.ParseFloat(value, this);
        }
    }
}