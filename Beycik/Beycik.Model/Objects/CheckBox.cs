using System.Xml.Serialization;
using Beycik.Model.API;
using Beycik.Model.Objects.Core;
using Beycik.Model.Objects.Scraps;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("CHECKBOX")]
    public sealed class CheckBox : AbstractBox, IContent, IColor, 
        INameable, ITextItem, IValidateable
    {
        [XmlIgnore]
        public short? GroupExclusive { get; set; }
        
        [XmlAttribute("group_exclusive")]
        public string GroupExclusiveStr
        {
            get => ValueEx.FormatShort(GroupExclusive);
            set => GroupExclusive = ValueEx.ParseShort(value);
        }
        
        [XmlIgnore]
        public short? Group { get; set; }
        
        [XmlAttribute("group")]
        public string GroupStr
        {
            get => ValueEx.FormatShort(Group);
            set => Group = ValueEx.ParseShort(value);
        }
        
        [XmlIgnore]
        public bool? Radio { get; set; }
        
        [XmlAttribute("radio")]
        public string RadioStr
        {
            get => ValueEx.FormatBool(Radio);
            set => Radio = ValueEx.ParseBool(value);
        }
        
        [XmlIgnore]
        public Shape? Shape { get; set; }

        [XmlAttribute("shape")]
        public string ShapeStr
        {
            get => ValueEx.FormatEnum(Shape);
            set => Shape = ValueEx.ParseEnum<Shape>(value);
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
        
        [XmlIgnore]
        public byte? HtmlDisabled { get; set; }
        
        [XmlAttribute("htmldisabled")]
        public string HtmlDisabledStr
        {
            get => ValueEx.FormatByte(HtmlDisabled);
            set => HtmlDisabled = ValueEx.ParseByte(value);
        }
        
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
        
        [XmlIgnore]
        public byte? FsLast { get; set; }
        
        [XmlAttribute("fslast")]
        public string FsLastStr
        {
            get => ValueEx.FormatByte(FsLast);
            set => FsLast = ValueEx.ParseByte(value);
        }
        
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