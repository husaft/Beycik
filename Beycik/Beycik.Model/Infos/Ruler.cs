using System.Xml.Serialization;
using Beycik.Model.Core;
using Beycik.Model.Tools;

namespace Beycik.Model.Infos
{
    [XmlRoot("RULER")]
    public sealed class Ruler : Color
    {
        [XmlIgnore]
        public float? BMargin { get; set; }
        
        [XmlAttribute("bmargin")]
        public string BMarginStr
        {
            get => ValueEx.FormatFloat(BMargin);
            set => BMargin = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? DuplexOffset { get; set; }
        
        [XmlAttribute("duplexoffset")]
        public string DuplexOffsetStr
        {
            get => ValueEx.FormatFloat(DuplexOffset);
            set => DuplexOffset = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? H10Y { get; set; }

        [XmlAttribute("h10y")]
        public string H10YStr
        {
            get => ValueEx.FormatFloat(H10Y);
            set => H10Y = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? H1Y { get; set; }
        
        [XmlAttribute("h1y")]
        public string H1YStr
        {
            get => ValueEx.FormatFloat(H1Y);
            set => H1Y = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? H2Y { get; set; }
        
        [XmlAttribute("h2y")]
        public string H2YStr
        {
            get => ValueEx.FormatFloat(H2Y);
            set => H2Y = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? H3Y { get; set; }
        
        [XmlAttribute("h3y")]
        public string H3YStr
        {
            get => ValueEx.FormatFloat(H3Y);
            set => H3Y = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? H4Y { get; set; }
        
        [XmlAttribute("h4y")]
        public string H4YStr
        {
            get => ValueEx.FormatFloat(H4Y);
            set => H4Y = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? H5Y { get; set; }
        
        [XmlAttribute("h5y")]
        public string H5YStr
        {
            get => ValueEx.FormatFloat(H5Y);
            set => H5Y = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? H6Y { get; set; }

        [XmlAttribute("h6y")]
        public string H6YStr
        {
            get => ValueEx.FormatFloat(H6Y);
            set => H6Y = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? H7Y { get; set; }

        [XmlAttribute("h7y")]
        public string H7YStr
        {
            get => ValueEx.FormatFloat(H7Y);
            set => H7Y = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? H8Y { get; set; }

        [XmlAttribute("h8y")]
        public string H8YStr
        {
            get => ValueEx.FormatFloat(H8Y);
            set => H8Y = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? H9Y { get; set; }

        [XmlAttribute("h9y")]
        public string H9YStr
        {
            get => ValueEx.FormatFloat(H9Y);
            set => H9Y = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? LMargin { get; set; }

        [XmlAttribute("lmargin")]
        public string LMarginStr
        {
            get => ValueEx.FormatFloat(LMargin);
            set => LMargin = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? RMargin { get; set; }

        [XmlAttribute("rmargin")]
        public string RMarginStr
        {
            get => ValueEx.FormatFloat(RMargin);
            set => RMargin = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? TMargin { get; set; }

        [XmlAttribute("tmargin")]
        public string TMarginStr
        {
            get => ValueEx.FormatFloat(TMargin);
            set => TMargin = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? V10X { get; set; }

        [XmlAttribute("v10x")]
        public string V10XStr
        {
            get => ValueEx.FormatFloat(V10X);
            set => V10X = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? V1X { get; set; }

        [XmlAttribute("v1x")]
        public string V1XStr
        {
            get => ValueEx.FormatFloat(V1X);
            set => V1X = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? V2X { get; set; }

        [XmlAttribute("v2x")]
        public string V2XStr
        {
            get => ValueEx.FormatFloat(V2X);
            set => V2X = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? V3X { get; set; }

        [XmlAttribute("v3x")]
        public string V3XStr
        {
            get => ValueEx.FormatFloat(V3X);
            set => V3X = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? V4X { get; set; }

        [XmlAttribute("v4x")]
        public string V4XStr
        {
            get => ValueEx.FormatFloat(V4X);
            set => V4X = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? V5X { get; set; }

        [XmlAttribute("v5x")]
        public string V5XStr
        {
            get => ValueEx.FormatFloat(V5X);
            set => V5X = ValueEx.ParseFloat(value);        
        }

        [XmlIgnore]
        public float? V6X { get; set; }

        [XmlAttribute("v6x")]
        public string V6XStr
        {
            get => ValueEx.FormatFloat(V6X);
            set => V6X = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? V7X { get; set; }

        [XmlAttribute("v7x")]
        public string V7XStr
        {
            get => ValueEx.FormatFloat(V7X);
            set => V7X = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? V8X { get; set; }

        [XmlAttribute("v8x")]
        public string V8XStr
        {
            get => ValueEx.FormatFloat(V8X);
            set => V8X = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public float? V9X { get; set; }
        
        [XmlAttribute("v9x")]
        public string V9XStr
        {
            get => ValueEx.FormatFloat(V9X);
            set => V9X = ValueEx.ParseFloat(value);
        }
    }
}