using System.Collections.Generic;
using System.Xml.Serialization;

namespace Beycik.Model.Infos
{
    [XmlRoot("TAGS")]
    public class Tags
    {
        [XmlElement("TAG")]
        public List<string> Tag { get; set; }
    }
}