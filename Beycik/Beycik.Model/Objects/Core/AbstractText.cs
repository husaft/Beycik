using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects.Core
{
    public abstract class AbstractText : AbstractBox, ISize, IStyleable, 
        IColor, ISized, IValidateable
    {
        [XmlIgnore]
        public bool? Bold { get; set; }
        
        [XmlAttribute("bold")]
        public string BoldStr
        {
            get => ValueEx.FormatBool(Bold);
            set => Bold = ValueEx.ParseBool(value);
        }
        
        [XmlIgnore]
        public bool? CustomHeight { get; set; }
        
        [XmlAttribute("custom_height")]
        public string CustomHeightStr
        {
            get => ValueEx.FormatBool(CustomHeight);
            set => CustomHeight = ValueEx.ParseBool(value);
        }
        
        [XmlAttribute("fontface")]
        public string FontFace { get; set; }

        [XmlIgnore]
        public float? FontSize { get; set; }
        
        [XmlAttribute("fontsize")]
        public string FontSizeStr
        {
            get => ValueEx.FormatFloat(FontSize, true);
            set => FontSize = ValueEx.ParseFloat(value);
        }

        [XmlIgnore]
        public bool? IgnoreFontHeight { get; set; }
        
        [XmlAttribute("ignorefontheight")]
        public string IgnoreFontHeightStr
        {
            get => ValueEx.FormatBool(IgnoreFontHeight);
            set => IgnoreFontHeight = ValueEx.ParseBool(value);
        }

        [XmlIgnore]
        public bool? Italic { get; set; }
        
        [XmlAttribute("italic")]
        public string ItalicStr
        {
            get => ValueEx.FormatBool(Italic);
            set => Italic = ValueEx.ParseBool(value);
        }

        [XmlIgnore]
        public bool? Underline { get; set; }
        
        [XmlAttribute("underline")]
        public string UnderlineStr
        {
            get => ValueEx.FormatBool(Underline);
            set => Underline = ValueEx.ParseBool(value);
        }

        [XmlAttribute("valparam1")]
        public string ValParam1 { get; set; }

        [XmlAttribute("validate1")]
        public string Validate1 { get; set; }

        [XmlAttribute("valparam2")]
        public string ValParam2 { get; set; }

        [XmlAttribute("validate2")]
        public string Validate2 { get; set; }
        
        [XmlAttribute("hstruct")]
        public string HStruct { get; set; }

        [XmlIgnore]
        public float? UlEnd { get; set; }
        
        [XmlAttribute("ulend")]
        public string UlEndStr
        {
            get => ValueEx.FormatFloat(UlEnd);
            set => UlEnd = ValueEx.ParseFloat(value);
        }
        
        [XmlIgnore]
        public byte? UlStart { get; set; }
        
        [XmlAttribute("ulstart")]
        public string UlStartStr
        {
            get => ValueEx.FormatByte(UlStart);
            set => UlStart = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? Blue { get; set; }
        
        [XmlAttribute("blue")]
        public string BlueStr
        {
            get => ValueEx.FormatByte(Blue);
            set => Blue = ValueEx.ParseByte(value);
        }

        [XmlIgnore]
        public byte? Green { get; set; }

        [XmlAttribute("green")]
        public string GreenStr
        {
            get => ValueEx.FormatByte(Green);
            set => Green = ValueEx.ParseByte(value);
        }

        [XmlIgnore]
        public byte? Red { get; set; }
        
        [XmlAttribute("red")]
        public string RedStr
        {
            get => ValueEx.FormatByte(Red);
            set => Red = ValueEx.ParseByte(value);
        }

        [XmlIgnore]
        public byte? Transparent { get; set; }
        
        [XmlAttribute("transparent")]
        public string TransparentStr
        {
            get => ValueEx.FormatByte(Transparent);
            set => Transparent = ValueEx.ParseByte(value);
        }
        
        [XmlAttribute("fsdeletelabel")]
        public string FsDeleteLabel { get; set; }

        [XmlAttribute("fsnextlabel")]
        public string FsNextLabel { get; set; }

        [XmlAttribute("fsnext")]
        public string FsNext { get; set; }
        
        [XmlIgnore]
        public byte? FsLast { get; set; }
        
        [XmlAttribute("fslast")]
        public string FsLastStr
        {
            get => ValueEx.FormatByte(FsLast);
            set => FsLast = ValueEx.ParseByte(value);
        }
    }
}