using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.Model.Objects.Scraps;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("INFO")]
    public class Info : AbstractBox, IContent
    {
        [XmlIgnore]
        public IconSize IconSize { get; set; }
        
        [XmlAttribute("iconsize")]
        public string IconSizeStr
        {
            get => ValueEx.FormatEnum(IconSize, false);
            set => IconSize = ValueEx.ParseEnum<IconSize>(value);
        }

        [XmlText]
        public string Content { get; set; }
    }
}