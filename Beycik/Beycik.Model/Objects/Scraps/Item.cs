using System.Xml.Serialization;
using Beycik.Model.API;

namespace Beycik.Model.Objects.Scraps
{
    [XmlRoot("ITEM")]
    public sealed class Item : IContent, IValidateable
    {
        [XmlAttribute("map")]
        public string Map { get; set; }

        [XmlAttribute("validate1")]
        public string Validate1 { get; set; }

        [XmlAttribute("valparam1")]
        public string ValParam1 { get; set; }
        
        [XmlAttribute("validate2")]
        public string Validate2 { get; set; }

        [XmlAttribute("valparam2")]
        public string ValParam2 { get; set; }

        [XmlAttribute("validate3")]
        public string Validate3 { get; set; }

        [XmlAttribute("valparam3")]
        public string ValParam3 { get; set; }

        [XmlText]
        public string Content { get; set; }
    }
}