using System.Xml.Serialization;

namespace Beycik.Model.Roots
{
    [XmlRoot("ATTACHMENTS")]
    public sealed class Attachments
    {
        [XmlAttribute("sigma")] 
        public byte Sigma { get; set; }

        [XmlAttribute("maxsize")] 
        public byte MaxSize { get; set; }
        
        [XmlAttribute("filter")] 
        public string Filter { get; set; }
    }
}