using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Beycik.Model.Objects.Core;
using Beycik.Model.Tools;

namespace Beycik.Model.Objects
{
    [XmlRoot("OBJECTS")]
    public sealed class ObjectList
    {
        [XmlIgnore]
        public byte? MaxBtn { get; set; }
        
        [XmlAttribute("maxBTN")]
        public string MaxBtnStr
        {
            get => ValueEx.FormatByte(MaxBtn);
            set => MaxBtn = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxChb { get; set; }
        
        [XmlAttribute("maxCHB")]
        public string MaxChbStr
        {
            get => ValueEx.FormatByte(MaxChb);
            set => MaxChb = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxCnt { get; set; }
        
        [XmlAttribute("maxCNT")]
        public string MaxCntStr
        {
            get => ValueEx.FormatByte(MaxCnt);
            set => MaxCnt = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxDrd { get; set; }
        
        [XmlAttribute("maxDRD")]
        public string MaxDrdStr
        {
            get => ValueEx.FormatByte(MaxDrd);
            set => MaxDrd = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxFrm { get; set; }
        
        [XmlAttribute("maxFRM")]
        public string MaxFrmStr
        {
            get => ValueEx.FormatByte(MaxFrm);
            set => MaxFrm = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxFsg { get; set; }
        
        [XmlAttribute("maxFSG")]
        public string MaxFsgStr
        {
            get => ValueEx.FormatByte(MaxFsg);
            set => MaxFsg = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxHts { get; set; }
        
        [XmlAttribute("maxHTS")]
        public string MaxHtsStr
        {
            get => ValueEx.FormatByte(MaxHts);
            set => MaxHts = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxImg { get; set; }
        
        [XmlAttribute("maxIMG")]
        public string MaxImgStr
        {
            get => ValueEx.FormatByte(MaxImg);
            set => MaxImg = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxInf { get; set; }
        
        [XmlAttribute("maxINF")]
        public string MaxInfStr
        {
            get => ValueEx.FormatByte(MaxInf);
            set => MaxInf = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxLin { get; set; }
        
        [XmlAttribute("maxLIN")]
        public string MaxLinStr
        {
            get => ValueEx.FormatByte(MaxLin);
            set => MaxLin = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public short? MaxRta { get; set; }
        
        [XmlAttribute("maxRTA")]
        public string MaxRtaStr
        {
            get => ValueEx.FormatShort(MaxRta);
            set => MaxRta = ValueEx.ParseShort(value);
        }
        
        [XmlIgnore]
        public byte? MaxTxa { get; set; }
        
        [XmlAttribute("maxTXA")]
        public string MaxTxaStr
        {
            get => ValueEx.FormatByte(MaxTxa);
            set => MaxTxa = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxTxc { get; set; }
        
        [XmlAttribute("maxTXC")]
        public string MaxTxcStr
        {
            get => ValueEx.FormatByte(MaxTxc);
            set => MaxTxc = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxTxf { get; set; }
        
        [XmlAttribute("maxTXF")]
        public string MaxTxfStr
        {
            get => ValueEx.FormatByte(MaxTxf);
            set => MaxTxf = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxTxt { get; set; }
        
        [XmlAttribute("maxTXT")]
        public string MaxTxtStr
        {
            get => ValueEx.FormatByte(MaxTxt);
            set => MaxTxt = ValueEx.ParseByte(value);
        }
        
        [XmlIgnore]
        public byte? MaxUlg { get; set; }
        
        [XmlAttribute("maxULG")]
        public string MaxUlgStr
        {
            get => ValueEx.FormatByte(MaxUlg);
            set => MaxUlg = ValueEx.ParseByte(value);
        }
        
        [XmlElement("RECTANGLE", typeof(Rectangle))]
        [XmlElement("TEXT", typeof(Text))]
        [XmlElement("LINE", typeof(Line))]
        [XmlElement("TEXTCLUSTER", typeof(TextCluster))]
        [XmlElement("FRAME", typeof(Frame))]
        [XmlElement("CHECKBOX", typeof(CheckBox))]
        [XmlElement("TEXTAREA", typeof(TextArea))]
        [XmlElement("TEXTFIELD", typeof(TextField))]
        [XmlElement("IMAGE", typeof(Image))]
        [XmlElement("HOTSPOT", typeof(HotSpot))]
        [XmlElement("INFO", typeof(Info))]
        [XmlElement("DROPDOWN", typeof(DropDown))]
        [XmlElement("CONTAINER", typeof(Container))]
        [XmlElement("BUTTON", typeof(Button))]
        public List<ObjectNode> Items { get; set; }
        
        [XmlIgnore] public IEnumerable<Button> Buttons => Items.OfType<Button>();
        [XmlIgnore] public IEnumerable<CheckBox> CheckBoxes => Items.OfType<CheckBox>();
        [XmlIgnore] public IEnumerable<Container> Containers => Items.OfType<Container>();
        [XmlIgnore] public IEnumerable<DropDown> DropDowns => Items.OfType<DropDown>();
        [XmlIgnore] public IEnumerable<Frame> Frames => Items.OfType<Frame>();
        [XmlIgnore] public IEnumerable<HotSpot> HotSpots => Items.OfType<HotSpot>();
        [XmlIgnore] public IEnumerable<Image> Images => Items.OfType<Image>();
        [XmlIgnore] public IEnumerable<Info> Infos => Items.OfType<Info>();
        [XmlIgnore] public IEnumerable<Line> Lines => Items.OfType<Line>();
        [XmlIgnore] public IEnumerable<Rectangle> Rectangles => Items.OfType<Rectangle>();
        [XmlIgnore] public IEnumerable<Text> Texts => Items.OfType<Text>();
        [XmlIgnore] public IEnumerable<TextArea> TextAreas => Items.OfType<TextArea>();
        [XmlIgnore] public IEnumerable<TextCluster> TextClusters => Items.OfType<TextCluster>();
        [XmlIgnore] public IEnumerable<TextField> TextFields => Items.OfType<TextField>();
    }
}