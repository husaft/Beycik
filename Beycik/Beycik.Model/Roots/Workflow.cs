using System.Xml.Serialization;

namespace Beycik.Model.Roots
{
    [XmlRoot("WORKFLOW")]
    public sealed class Workflow
    {
        [XmlElement("ATTACHMENTS")]
        public Attachments Attachments { get; set; }

        [XmlElement("TRANSPONDER")]
        public Transponder Transponder { get; set; }
    }
}