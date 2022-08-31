using System.Xml.Serialization;
using Beycik.Model.API;

namespace Beycik.Model.Core
{
    public class Color : IColor
    {
        [XmlAttribute("blue")] 
        public byte Blue { get; set; }

        [XmlAttribute("green")] 
        public byte Green { get; set; }

        [XmlAttribute("red")] 
        public byte Red { get; set; }
    }
}