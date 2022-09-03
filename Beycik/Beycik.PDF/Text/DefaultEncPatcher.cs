using System.Collections.Generic;

namespace Beycik.PDF.Text
{
    public class DefaultEncPatcher : IEncodingPatcher
    {
        private readonly SortedDictionary<char, char> _map;

        public DefaultEncPatcher()
        {
            _map = new SortedDictionary<char, char>
            {
                { (char)0x152, (char)0x8c },
                { (char)0x153, (char)0x9c },
                { (char)0x160, (char)0x8a },
                { (char)0x161, (char)0x8a },
                { (char)0x178, (char)0x9f },
                { (char)0x17d, (char)0x8e },
                { (char)0x17e, (char)0x9e },
                { (char)0x192, (char)0x83 },
                { (char)0x2013, (char)0x96 },
                { (char)0x2014, (char)0x97 },
                { (char)0x2018, (char)0x91 },
                { (char)0x2019, (char)0x92 },
                { (char)0x201c, (char)0x93 },
                { (char)0x201d, (char)0x94 },
                { (char)0x201e, (char)0x84 },
                { (char)0x2020, (char)0x86 },
                { (char)0x2021, (char)0x87 },
                { (char)0x2022, (char)0x95 },
                { (char)0x2026, (char)0x85 },
                { (char)0x2030, (char)0x89 },
                { (char)0x2039, (char)0x8b },
                { (char)0x203a, (char)0x9b },
                { (char)0x20ac, (char)0x80 },
                { (char)0x2122, (char)0x99 },
                { (char)0x2c6, (char)0x88 },
                { (char)0x2dc, (char)0x98 }
            };
        }

        public string Translate(string plain)
        {
            if (plain == null)
                return null;
            var len = plain.Length;
            if (len == 0)
                return string.Empty;
            var array = plain.ToCharArray();
            for (var i = 0; i < len; ++i)
            {
                var orig = array[i];
                if (!_map.TryGetValue(orig, out var letter))
                    continue;
                array[i] = letter;
            }
            return new string(array);
        }
    }
}