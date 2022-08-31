using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;

namespace Beycik.Model.Objects
{
    [XmlRoot("BUTTON")]
    public sealed class Button : AbstractText, IContent
    {
        [XmlText]
        public string Content { get; set; }
    }
}