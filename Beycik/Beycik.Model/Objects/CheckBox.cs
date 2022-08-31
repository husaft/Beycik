using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("CHECKBOX")]
    public sealed class CheckBox : AbstractBox, IContent, IColor, 
        INameable, ITextItem, IValidateable
    {
        [XmlAttribute("group_exclusive")]
        public short GroupExclusive { get; set; }

        [XmlAttribute("group")]
        public short Group { get; set; }
        
        [XmlIgnore]
        public bool? Radio { get; set; }
        
        [XmlAttribute("radio")]
        public string RadioStr
        {
            get => ValueEx.FormatBool(Radio);
            set => Radio = ValueEx.ParseBool(value);
        }
        
        [XmlAttribute("shape")]
        public byte Shape { get; set; }

        [XmlAttribute("blue")]
        public byte Blue { get; set; }

        [XmlAttribute("green")]
        public byte Green { get; set; }

        [XmlAttribute("red")]
        public byte Red { get; set; }

        [XmlAttribute("transparent")]
        public byte Transparent { get; set; }
        
        [XmlAttribute("htmldisabled")]
        public byte HtmlDisabled { get; set; }
        
        [XmlIgnore]
        public bool? PrintBorder { get; set; }
        
        [XmlAttribute("printborder")]
        public string PrintBorderStr
        {
            get => ValueEx.FormatBool(PrintBorder);
            set => PrintBorder = ValueEx.ParseBool(value);
        }

        [XmlIgnore]
        public bool? Active { get; set; }
        
        [XmlAttribute("active")]
        public string ActiveStr
        {
            get => ValueEx.FormatBool(Active);
            set => Active = ValueEx.ParseBool(value);
        }
        
        [XmlAttribute("fsnext")]
        public string FsNext { get; set; }
        
        [XmlAttribute("fsnextlabel")]
        public string FsNextLabel { get; set; }
        
        [XmlAttribute("fsdeletelabel")]
        public string FsDeleteLabel { get; set; }
        
        [XmlAttribute("fslast")]
        public byte FsLast { get; set; }
        
        [XmlAttribute("valparam1")]
        public string ValParam1 { get; set; }

        [XmlAttribute("validate1")]
        public string Validate1 { get; set; }

        [XmlAttribute("valparam2")]
        public string ValParam2 { get; set; }

        [XmlAttribute("validate2")]
        public string Validate2 { get; set; }

        [XmlAttribute("valparam3")]
        public string ValParam3 { get; set; }

        [XmlAttribute("validate3")]
        public string Validate3 { get; set; }

        [XmlAttribute("valparam4")]
        public string ValParam4 { get; set; }

        [XmlAttribute("validate4")]
        public string Validate4 { get; set; }
        
        [XmlAttribute("valparam5")]
        public string ValParam5 { get; set; }

        [XmlAttribute("validate5")]
        public string Validate5 { get; set; }
        
        [XmlAttribute("valparam6")]
        public string ValParam6 { get; set; }

        [XmlAttribute("validate6")]
        public string Validate6 { get; set; }
        
        [XmlText]
        public string Content { get; set; }
    }
}