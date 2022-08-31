using System.Xml.Serialization;
using Beycik.Model.Tools;

namespace Beycik.Model.Infos
{
    [XmlRoot("OPTIONS")]
    public sealed class Options
    {
        [XmlIgnore] 
        public bool? AddFields { get; set; }
        
        [XmlAttribute("addfields")] 
        public string AddFieldsStr
        {
            get => ValueEx.FormatBool(AddFields);
            set => AddFields = ValueEx.ParseBool(value);
        }
    }
}