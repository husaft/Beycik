using System.Xml.Serialization;
using Beycik.Model.Tools;

namespace Beycik.Model.Roots
{
    [XmlRoot("SOURCECODE")]
    public sealed class SourceCode
    {
        [XmlAttribute("decodedlength")]
        public short DecodedLength { get; set; }
        
        [XmlIgnore]
        public byte[] Encoded { get; set; }
        
        [XmlText]
        public string EncodedStr
        {
            get => ValueEx.FormatBytes(Encoded);
            set => Encoded = ValueEx.ParseBytes(value);
        }
    }
}