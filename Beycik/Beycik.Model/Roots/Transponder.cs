using System.Xml.Serialization;
using Beycik.Model.Roots.Scraps;
using Beycik.Model.Tools;

namespace Beycik.Model.Roots
{
    [XmlRoot("TRANSPONDER")]
    public sealed class Transponder
    {
        [XmlElement("HOST")]
        public string Host { get; set; }
        
        [XmlIgnore]
        public ushort? Port { get; set; }
        
        [XmlElement("PORT")]
        public string PortStr
        {
            get => ValueEx.FormatUShort(Port);
            set => Port = ValueEx.ParseUShort(value);
        }

        [XmlIgnore]
        public Protocol? Protocol { get; set; }
        
        [XmlElement("PROTOCOL")]
        public string ProtocolStr
        {
            get => ValueEx.FormatEnum(Protocol);
            set => Protocol = ValueEx.ParseEnum<Protocol>(value);
        }
        
        [XmlElement("OSCI")]
        public Osci Osci { get; set; }
        
        [XmlElement("SERVICE")]
        public string Service { get; set; }

        [XmlElement("PROCESS")]
        public string Process { get; set; }

        [XmlElement("ENCRYPTION")]
        public string Encryption { get; set; }

        [XmlElement("SUBJECT")]
        public string Subject { get; set; }
    }
}