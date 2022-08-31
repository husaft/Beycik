using System.Collections.Generic;
using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.Model.Objects.Scraps;

namespace Beycik.Model.Objects
{
    [XmlRoot("TEXTCLUSTER")]
    public sealed class TextCluster : AbstractTextual, IIdentifiable, ISized
    {
        [XmlElement("ATOM")] 
        public List<Atom> Atoms { get; set; }
    }
}