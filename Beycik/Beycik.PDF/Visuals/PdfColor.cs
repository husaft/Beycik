using Beycik.PDF.Tools;

namespace Beycik.PDF.Visuals
{
    internal sealed class PdfColor
    {
        private (double r, double g, double b) _one;
        private bool _oneChanged;
        private (double r, double g, double b) _two;
        private bool _twoChanged;

        internal PdfColor()
        {
            _one = (r: 0.0, g: 0.0, b: 0.0);
            _oneChanged = true;
            _two = (r: 0.0, g: 0.0, b: 0.0);
            _twoChanged = true;
        }

        public void SetRgb(double red, double green, double blue)
        {
            if (!_one.r.Is(red) || !_one.g.Is(green) || !_one.b.Is(blue))
            {
                _one = (r: red, g: green, b: blue);
                _oneChanged = true;
            }
            if (!_two.r.Is(red) || !_two.g.Is(green) || !_two.b.Is(blue))
            {
                _two = (r: red, g: green, b: blue);
                _twoChanged = true;
            }
        }

        public void SetChanged()
        {
            _oneChanged = _twoChanged = true;
        }

        public string Get()
        {
            var ret = string.Empty;
            if (_oneChanged)
            {
                ret = $"{ret}{_one.r.Round2().T()} {_one.g.Round2().T()} {_one.b.Round2().T()} RG ";
                _oneChanged = false;
            }
            if (_twoChanged)
            {
                ret = $"{ret}{_two.r.Round2().T()} {_two.g.Round2().T()} {_two.b.Round2().T()} rg ";
                _twoChanged = false;
            }
            return ret;
        }
    }
}