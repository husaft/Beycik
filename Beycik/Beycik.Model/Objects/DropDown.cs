using System.Collections.Generic;
using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.Model.Objects.Scraps;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("DROPDOWN")]
    public sealed class DropDown : AbstractTextual, ITextItem
    {
        [XmlIgnore]
        public bool? Active { get; set; }
        
        [XmlAttribute("active")]
        public string ActiveStr
        {
            get => ValueEx.FormatBool(Active);
            set => Active = ValueEx.ParseBool(value);
        }
        
        [XmlIgnore]
        public bool? Editable { get; set; }
        
        [XmlAttribute("editable")]
        public string EditableStr
        {
            get => ValueEx.FormatBool(Editable);
            set => Editable = ValueEx.ParseBool(value);
        }

        [XmlAttribute("group")]
        public byte Group { get; set; }

        [XmlElement("VALUE")]
        public string Value { get; set; }
        
        [XmlElement("ITEM")] 
        public List<Item> Items { get; set; }
    }
}