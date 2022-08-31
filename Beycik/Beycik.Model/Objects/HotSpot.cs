using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;

namespace Beycik.Model.Objects
{
    [XmlRoot("HOTSPOT")]
    public class HotSpot : AbstractBox, IValidateable
    {
        [XmlAttribute("valparam1")]
        public string ValParam1 { get; set; }

        [XmlAttribute("validate1")]
        public string Validate1 { get; set; }
        
        [XmlAttribute("valparam4")]
        public string ValParam4 { get; set; }

        [XmlAttribute("validate4")]
        public string Validate4 { get; set; }
    }
}