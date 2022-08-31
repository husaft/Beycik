using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;

namespace Beycik.Model.Objects
{
    [XmlRoot("FRAME")]
    public sealed class Frame : AbstractBox, INameable, IIdentifiable
    {
    }
}