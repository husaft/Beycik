using System.Xml.Serialization;
using Beycik.Model.Objects.Core;
using Beycik.Model.Objects.Scraps;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("IMAGE")]
    public class Image : AbstractBox
    {
        [XmlIgnore]
        public bool? GrayScale { get; set; }
        
        [XmlAttribute("grayscale")]
        public string GrayScaleStr
        {
            get => ValueEx.FormatBool(GrayScale);
            set => GrayScale = ValueEx.ParseBool(value);
        }

        [XmlIgnore]
        public SizeType SizeType { get; set; }
        
        [XmlAttribute("sizetype")]
        public string SizeTypeStr
        {
            get => ValueEx.FormatEnum(SizeType);
            set => SizeType = ValueEx.ParseEnum<SizeType>(value);
        }
        
        [XmlAttribute("url")]
        public string Url { get; set; }
        
        [XmlAttribute("halt")]
        public string HAlt { get; set; }
        
        [XmlAttribute("mimetype")]
        public string MimeType { get; set; }

        [XmlAttribute("decodedlength")]
        public int DecodedLength { get; set; }

        [XmlText]
        public byte[] Encoded { get; set; }
    }
}