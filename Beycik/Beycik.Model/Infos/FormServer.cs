using System;
using System.Xml.Serialization;
using Beycik.Model.Tools;
using static Beycik.Model.Tools.Constants;

namespace Beycik.Model.Infos
{
    [XmlRoot("FORMSERVER")]
    public sealed class FormServer
    {
        [XmlElement("FORMNAME")]
        public string FormName { get; set; }

        [XmlElement("COPYRIGHT")]
        public string Copyright { get; set; }
        
        [XmlElement("FORMID")] 
        public short FormId { get; set; }
        
        [XmlElement("FORMUID")]
        public string FormUid { get; set; }
        
        [XmlElement("CURLAYOUTHC")]
        public byte[] CurLayoutHc { get; set; }
        
        [XmlElement("FORMVERSION")]
        public byte FormVersion { get; set; }
        
        [XmlIgnore]
        public DateTime FormTime { get; set; }
        
        [XmlElement("FORMTIME")]
        public string FormTimeStr
        {
            get => ValueEx.FormatDate(FormTime, StdDate);
            set => FormTime = ValueEx.ParseDate(value, StdDate);
        }
        
        [XmlElement("UID")]
        public short Uid { get; set; }
        
        [XmlElement("PRODID")]
        public string ProdId { get; set; }
        
        [XmlElement("INSTITUTE")]
        public string Institute { get; set; }
        
        [XmlElement("PHYSNAME")]
        public string PhysName { get; set; }
        
        [XmlIgnore]
        public Uri Href { get; set; }

        [XmlElement("HREF")]
        public string HrefStr
        {
            get => ValueEx.FormatUri(Href);
            set => Href = ValueEx.ParseUri(value);
        }
        
        [XmlElement("MANDANTID")]
        public short MandantId { get; set; }

        [XmlElement("MANDANTUID")]
        public string MandantUid { get; set; }
    }
}