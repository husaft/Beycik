using System.Xml.Serialization;

namespace Beycik.Model.Infos
{
    [XmlRoot("CONTROL")]
    public class Control
    {
        [XmlElement("ENCRYPT")] 
        public byte Encrypt { get; set; }
    }
}