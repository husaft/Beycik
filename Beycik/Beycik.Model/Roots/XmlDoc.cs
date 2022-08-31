using System;
using System.Globalization;
using System.Xml.Serialization;
using Beycik.Model.Objects;
using Beycik.Model.Tools;
using static Beycik.Model.Tools.Constants;

namespace Beycik.Model.Roots
{
    [XmlRoot("CIRALI")]
    public sealed class XmlDoc
    {
        [XmlAttribute("changeProg")] 
        public string ChangeProg { get; set; }
        
        [XmlIgnore] 
        public DateTime? ChangeTime { get; set; }

        [XmlAttribute("changeTime")]
        public string ChangeTimeStr
        {
            get => ChangeTime?.ToString(DeDate);
            set => ChangeTime = DateTime.TryParseExact(value, DeDate,
                null, DateTimeStyles.None, out var v)
                ? v
                : null;
        }

        [XmlIgnore] 
        public Version Version { get; set; }

        [XmlAttribute("version")]
        public string VersionStr
        {
            get => ValueEx.FormatVersion(Version);
            set => Version = ValueEx.ParseVersion(value);
        }

        [XmlElement("FORMINFO")] 
        public FormInfo FormInfo { get; set; }
        
        [XmlElement("CONTROLLER")]
        public Controller Controller { get; set; }
        
        [XmlElement("WORKFLOW")]
        public Workflow Workflow { get; set; }
        
        [XmlElement("OBJECTS")]
        public ObjectList Objects { get; set; }
        
        [XmlElement("RESOURCES")]
        public ObjectList Resources { get; set; }
    }
}