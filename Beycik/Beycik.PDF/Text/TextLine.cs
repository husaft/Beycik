using System.Collections.Generic;

namespace Beycik.PDF.Text
{
    internal sealed class TextLine
    {
        public double AddWidth { get; set; }
        public double Width { get; set; }
        public string Line { get; set; }
        public double LineHeight { get; set; }
        public List<TextAtom> Atoms { get; set; }
        public LineType Mode { get; set; }

        public TextLine()
        {
            Atoms = new List<TextAtom>();
            Line = "";
            Mode = LineType.AutoBreak;
        }

        public int NumberOfAtoms
        {
            get
            {
                var count = 0;
                foreach (var atom in Atoms)
                    if (atom.Type == AtomType.Text)
                        ++count;
                return count;
            }
        }
    }
}