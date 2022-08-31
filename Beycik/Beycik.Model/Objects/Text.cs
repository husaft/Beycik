using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;

namespace Beycik.Model.Objects
{
    [XmlRoot("TEXT")]
    public sealed class Text : AbstractTextual, IContent,
        INameable, IIdentifiable, IValidateable
    {
        [XmlText] 
        public string Content { get; set; }
    }
}