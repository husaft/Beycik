using System.Xml.Serialization;

namespace Beycik.Model.Roots
{
    [XmlRoot("SOURCECODE")]
    public sealed class SourceCode
    {
        [XmlAttribute("decodedlength")]
        public short DecodedLength { get; set; }

        [XmlText]
        public byte[] Encoded { get; set; }
    }
}