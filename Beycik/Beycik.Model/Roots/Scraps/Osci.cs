using System;
using System.Xml.Serialization;
using Beycik.Model.Tools;

namespace Beycik.Model.Roots.Scraps
{
    [XmlRoot("OSCI")]
    public sealed class Osci
    {
        [XmlIgnore] 
        public bool? Attachments { get; set; }
        
        [XmlElement("ATTACHMENTS")] 
        public string AttachmentsStr
        {
            get => ValueEx.FormatBool(Attachments);
            set => Attachments = ValueEx.ParseBool(value);
        }
        
        [XmlIgnore]
        public Uri InterMedUrl { get; set; }

        [XmlElement("INTERMED_URL")]
        public string InterMedUrlStr
        {
            get => ValueEx.FormatUri(InterMedUrl);
            set => InterMedUrl = ValueEx.ParseUri(value);
        }
        
        [XmlElement("SIGNATURE_NUMBER")]
        public byte SignatureNumber { get; set; } 

        [XmlElement("SIGNATURE_LEVEL")]
        public string SignatureLevel { get; set; }       

        [XmlElement("PROVIDER_ACCREDITATION")]
        public string ProviderAccreditation { get; set; }
        
        [XmlIgnore]
        public Level DebugLevel { get; set; }
        
        [XmlElement("DEBUG_LEVEL")]
        public string DebugLevelStr
        {
            get => ValueEx.FormatEnum(DebugLevel);
            set => DebugLevel = ValueEx.ParseEnum<Level>(value);
        }
        
        [XmlElement("ATTACHMENTS_EXTS")]
        public string AttachmentsExts { get; set; }

        [XmlElement("ATTACHMENTS_MAX_MB")]
        public string AttachmentsMaxMb { get; set; }       

        [XmlElement("INTERMED_CER")] 
        public byte[] IntermedCer { get; set; }

        [XmlElement("BACKEND_CER")] 
        public byte[] BackendCer { get; set; }
    }
}