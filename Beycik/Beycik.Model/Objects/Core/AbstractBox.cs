using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects.Core
{
    public abstract class AbstractBox : ObjectNode, ISize, ISized
    {
        [XmlIgnore]
        public bool? Customizable { get; set; }
        
        [XmlAttribute("customizable")]
        public string CustomizableStr
        {
            get => ValueEx.FormatBool(Customizable);
            set => Customizable = ValueEx.ParseBool(value);
        }
        
        [XmlIgnore] 
        public float? Height { get; set; }

        [XmlAttribute("height")] 
        public string HeightStr
        {
            get => ValueEx.FormatFloat(Height);
            set => Height = ValueEx.ParseFloat(value);
        }

        [XmlIgnore] 
        public float? Width { get; set; }

        [XmlAttribute("width")] 
        public string WidthStr
        {
            get => ValueEx.FormatFloat(Width);
            set => Width = ValueEx.ParseFloat(value);
        }

        [XmlIgnore] 
        public bool? MustFill { get; set; }
        
        [XmlAttribute("mustfill")] 
        public string MustFillStr
        {
            get => ValueEx.FormatBool(MustFill);
            set => MustFill = ValueEx.ParseBool(value);
        }

        [XmlAttribute("nobarrier")] 
        public string NoBarrier { get; set; }

        [XmlIgnore] 
        public bool? Border { get; set; }
        
        [XmlAttribute("border")] 
        public string BorderStr
        {
            get => ValueEx.FormatBool(Border);
            set => Border = ValueEx.ParseBool(value);
        }
        
        [XmlIgnore] 
        public bool? Tab { get; set; }
        
        [XmlAttribute("tab")] 
        public string TabStr
        {
            get => ValueEx.FormatBool(Tab);
            set => Tab = ValueEx.ParseBool(value);
        }

        [XmlAttribute("label")] 
        public string Label { get; set; }

        [XmlIgnore] 
        public float? FsEnd { get; set; }

        [XmlAttribute("fsend")]
        public string FsEndStr
        {
            get => ValueEx.FormatFloat(FsEnd);
            set => FsEnd = ValueEx.ParseFloat(value);
        }
        
        [XmlAttribute("fsstart")] 
        public byte FsStart { get; set; }

        [XmlAttribute("fslegend")] 
        public string FsLegend { get; set; }

        [XmlAttribute("fshidden")] 
        public byte FsHidden { get; set; }
    }
}