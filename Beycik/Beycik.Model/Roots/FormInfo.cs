using System.Xml.Serialization;
using Beycik.Model.Core;
using Beycik.Model.Infos;

namespace Beycik.Model.Roots
{
    [XmlRoot("FORMINFO")]
    public sealed class FormInfo
    {
        [XmlElement("PAGESIZE")]
        public Size PageSize { get; set; }
        
        [XmlElement("BACKGROUND")]
        public Color Background { get; set; }
        
        [XmlElement("EDITOR")]
        public Editor Editor { get; set; }
        
        [XmlElement("FORMSERVER")] 
        public FormServer FormServer { get; set; }
        
        [XmlElement("PAGESIGMA")]
        public byte PageSigma { get; set; }
        
        [XmlElement("CONTROL")]
        public Control Control { get; set; }
        
        [XmlElement ("TAGS")]
        public Tags Tags { get; set; }
        
        [XmlElement("OPTIONS")]
        public Options Options { get; set; }
    }
}