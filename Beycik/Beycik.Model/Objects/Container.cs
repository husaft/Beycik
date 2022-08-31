using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;

namespace Beycik.Model.Objects
{
    [XmlRoot("CONTAINER")]
    public sealed class Container : AbstractBox, IContent
    {
        [XmlText]
        public string Content { get; set; }
    }
}