using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Core;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects.Core
{
    public abstract class ObjectNode : Position, IPosition, IPdfNameable, IPageable
    {
        [XmlAttribute("page")]
        public byte Page { get; set; }

        [XmlIgnore]
        public bool? Print { get; set; }
        
        [XmlAttribute("print")]
        public string PrintStr
        {
            get => ValueEx.FormatBool(Print);
            set => Print = ValueEx.ParseBool(value);
        }
        
        [XmlIgnore] 
        public bool? Hidden { get; set; }
        
        [XmlAttribute("hidden")] 
        public string HiddenStr
        {
            get => ValueEx.FormatBool(Hidden);
            set => Hidden = ValueEx.ParseBool(value);
        }
        
        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("objid")]
        public string ObjId { get; set; }

        [XmlAttribute("objnext")]
        public string ObjNext { get; set; }

        [XmlAttribute("objprev")]
        public string ObjPrev { get; set; }
        
        [XmlIgnore] 
        public bool? View { get; set; }
        
        [XmlAttribute("view")] 
        public string ViewStr
        {
            get => ValueEx.FormatBool(View);
            set => View = ValueEx.ParseBool(value);
        }
        
        [XmlIgnore]
        public string PdfName { get; set; }
    }
}