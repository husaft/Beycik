using System.Xml.Serialization;
using Beycik.Model.Core;
using Beycik.Model.Tools;

namespace Beycik.Model.Infos
{
    [XmlRoot("EDITOR")]
    public sealed class Editor
    {
        [XmlAttribute("label")] 
        public string Label { get; set; }
        
        [XmlAttribute("version")] 
        public string Version { get; set; }
        
        [XmlElement("RASTERCOLOR")] 
        public Color RasterColor { get; set; }
        
        [XmlElement("SNAPCOLOR")] 
        public Color SnapColor { get; set; }
        
        [XmlIgnore] 
        public double? SnapSize { get; set; }
        
        [XmlElement("SNAPSIZE")]
        public string SnapSizeStr
        {
            get => SnapSize?.ToString("F6");
            set => SnapSize = ValueEx.ParseDouble(value);
        }
        
        [XmlElement("RULER")]
        public Ruler Ruler { get; set; }
        
        [XmlElement("COPYOFFSET")]
        public Position CopyOffset { get; set; }
    }
}