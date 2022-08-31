using System.Xml.Serialization;
using Beycik.Model.Tools;

namespace Beycik.Model.Roots
{
    [XmlRoot("ATTACHMENTS")]
    public sealed class Attachments
    {
        [XmlIgnore] 
        public byte? Sigma { get; set; }

        [XmlAttribute("sigma")] 
        public string SigmaStr
        {
            get => ValueEx.FormatByte(Sigma);
            set => Sigma = ValueEx.ParseByte(value);
        }

        [XmlIgnore] 
        public byte? MaxSize { get; set; }

        [XmlAttribute("maxsize")] 
        public string MaxSizeStr
        {
            get => ValueEx.FormatByte(MaxSize);
            set => MaxSize = ValueEx.ParseByte(value);
        }

        [XmlAttribute("filter")] 
        public string Filter { get; set; }
    }
}