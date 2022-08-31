using System.Xml.Serialization;

namespace Beycik.Model.Roots
{
    [XmlRoot("CONTROLLER")]
    public sealed class Controller
    {
        [XmlElement("CODE")]
        public string Code { get; set; }
        
        [XmlElement("SOURCECODEFILENAME")]
        public string SourceCodeFileName { get; set; }

        [XmlElement("SOURCECODE")]
        public SourceCode SourceCode { get; set; }
    }
}