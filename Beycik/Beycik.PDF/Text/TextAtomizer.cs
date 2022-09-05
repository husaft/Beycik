using System.Collections.Generic;
using Beycik.Draw.Fonts.API;
using Beycik.Model.Objects;
using static Beycik.PDF.Tools.PdfExt;

namespace Beycik.PDF.Text
{
    internal sealed class TextAtomizer
    {
        private readonly List<TextAtom> _atoms;
        private readonly List<TextLine> _lines;

        public TextAtomizer()
        {
            _atoms = new List<TextAtom>();
            _lines = new List<TextLine>();
        }

        public TextLine GetLine(int idx)
        {
            return _lines.Count == 0 ? new TextLine() : _lines[idx];
        }

        public int LineSigma { get; private set; }
        private double FrameHeight { get; set; }

        public int AssembleLine(double lineWidth, double lineHeight)
        {
            var line = new TextLine();
            FrameHeight = 0.0;
            foreach (var atom in _atoms)
            {
                double height;
                if (atom.Type == AtomType.Text)
                {
                    if (atom.Width + line.AddWidth <= lineWidth)
                    {
                        if (line.AddWidth > 0.0)
                        {
                            line.Line += " ";
                            line.Width = line.AddWidth;
                        }
                        line.Atoms.Add(atom);
                        height = atom.FontData.Height;
                        if (line.LineHeight < height)
                        {
                            line.LineHeight = height;
                        }
                        line.Line += atom.Text;
                        line.Width += atom.Width;
                        line.AddWidth = line.Width + atom.WsWidth;
                        continue;
                    }
                    if (line.Width == 0.0)
                    {
                        line.Atoms.Add(atom);
                        height = atom.FontData.Height;
                        if (line.LineHeight < height)
                        {
                            line.LineHeight = height;
                        }
                        line.Line += atom.Text;
                        line.Width = atom.Width;
                        _lines.Add(line);
                        if (FrameHeight != 0.0)
                        {
                            FrameHeight += line.LineHeight * lineHeight;
                        }
                        else
                        {
                            FrameHeight += line.LineHeight;
                        }
                        line = new TextLine();
                        continue;
                    }
                    _lines.Add(line);
                    if (FrameHeight != 0.0)
                    {
                        FrameHeight += line.LineHeight * lineHeight;
                    }
                    else
                    {
                        FrameHeight += line.LineHeight;
                    }
                    line = new TextLine();
                    line.Atoms.Add(atom);
                    line.Line += atom.Text;
                    line.Width = atom.Width;
                    line.AddWidth = line.Width + atom.WsWidth;
                    height = atom.FontData.Height;
                    if (line.LineHeight < height)
                    {
                        line.LineHeight = height;
                    }
                    continue;
                }
                line.Mode = LineType.HardBreak;
                line.Atoms.Add(atom);
                height = atom.FontData.Height;
                if (line.LineHeight < height)
                {
                    line.LineHeight = height;
                }
                _lines.Add(line);
                if (FrameHeight != 0.0)
                {
                    FrameHeight += line.LineHeight * lineHeight;
                }
                else
                {
                    FrameHeight += line.LineHeight;
                }
                line = new TextLine();
            }
            if (!line.Line.Equals(""))
            {
                _lines.Add(line);
                if (FrameHeight != 0.0)
                {
                    FrameHeight += line.LineHeight * lineHeight;
                }
                else
                {
                    FrameHeight += line.LineHeight;
                }
            }
            return LineSigma = _lines.Count;
        }

        public void Atomize(string text, FontHandle font, TextMetrics metrics,
            IFontManager fonts, IEncodingPatcher encoder)
        {
            if (encoder != null)
                text = encoder.Translate(text);
            var fontData = metrics.RegisterFont(font, fonts);
            for (var i = 0; ParseEntry(text, i, "\n") is { } src; ++i)
            {
                if (i > 0)
                {
                    var textAtom = new TextAtom(AtomType.LineBreak, fontData,
                        font.Red, font.Green, font.Blue, font.Underline);
                    _atoms.Add(textAtom);
                }
                for (var j = 0; ParseEntry(src, j, " ") is { } middle; ++j)
                {
                    if (middle.Equals("\r"))
                        continue;
                    var textAtom = new TextAtom(middle, AtomType.Text, fontData,
                        metrics.CalcWidth(middle), metrics.CalcWidth(" "),
                        font.Red, font.Green, font.Blue, font.Underline);
                    _atoms.Add(textAtom);
                }
                if (_atoms.Count < 1)
                    continue;
                var index = _atoms.Count - 1;
                _atoms[index].WsWidth = 0.0;
            }
        }

        public void AtomizeCluster(TextCluster cluster, TextMetrics metrics,
            IFontManager fonts, IEncodingPatcher encoder)
        {
            foreach (var item in cluster.Atoms)
            {
                var font = FontHandle.ApplyFrom(item);
                var fontData = metrics.RegisterFont(font, fonts);
                var text = item.Content;
                if (encoder != null)
                    text = encoder.Translate(text);
                for (var lineIdx = 0; ParseEntry(text, lineIdx, "\n") is { } line; lineIdx++)
                {
                    if (lineIdx > 0)
                    {
                        var atom = new TextAtom(AtomType.LineBreak, fontData,
                            font.Red, font.Green, font.Blue, font.Underline);
                        _atoms.Add(atom);
                    }
                    for (var wordIdx = 0; ParseEntry(line, wordIdx, " ") is { } word; wordIdx++)
                    {
                        if (word.Equals("\r"))
                            continue;
                        var mwa = metrics.CalcWidth(word);
                        var mwb = metrics.CalcWidth(" ");
                        var atom = new TextAtom(word, AtomType.Text, fontData, mwa, mwb,
                            font.Red, font.Green, font.Blue, font.Underline);
                        _atoms.Add(atom);
                    }
                    if (_atoms.Count < 1)
                        continue;
                    var index = _atoms.Count - 1;
                    _atoms[index].WsWidth = 0.0;
                }
            }
        }
    }
}