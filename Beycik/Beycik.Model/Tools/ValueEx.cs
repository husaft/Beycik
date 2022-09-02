using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DS = System.Globalization.DateTimeStyles;
using NU = System.Globalization.NumberStyles;

namespace Beycik.Model.Tools
{
    public static class ValueEx
    {
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        #region Bool
        private enum YesNo { No = 0, Yes = 1 }

        public static string FormatBool(bool? value,
            object t = null, [CallerFilePath] string f = "", [CallerMemberName] string m = "")
        {
            var origin = GetOrigin(t ?? f, m);
            if (_styles == null || !_styles.TryGetValue(origin, out var style)) style = EnumStyle.LowerCase;
            YesNo? answer = value.HasValue ? value.Value ? YesNo.Yes : YesNo.No : null;
            var txt = WithEnumStyle(answer, style);
            return txt;
        }

        public static bool? ParseBool(string value,
            object t = null, [CallerFilePath] string f = "", [CallerMemberName] string m = "")
        {
            if (_styles != null)
            {
                var origin = GetOrigin(t ?? f, m);
                _styles[origin] = GetEnumStyle(value);
            }
            return Enum.TryParse<YesNo>(value, ignoreCase: true, out var v)
                ? v == YesNo.Yes
                : null;
        }
        #endregion

        #region Byte
        public static string FormatByte(byte? value)
        {
            return value?.ToString();
        }

        public static byte? ParseByte(string value)
        {
            return byte.TryParse(value, out var v) ? v : null;
        }
        #endregion

        #region Short
        public static string FormatShort(short? value)
        {
            return value?.ToString();
        }

        public static short? ParseShort(string value)
        {
            return short.TryParse(value, out var v) ? v : null;
        }
        #endregion

        #region Helpers
        private static int GetFractionLength(string value)
        {
            const StringComparison cmp = StringComparison.Ordinal;
            const string pt = ".";
            if (!value.Contains(pt, cmp)) return 0;
            return value.Length - (value.IndexOf(pt, cmp) + 1);
        }

        private static EnumStyle GetEnumStyle(string value)
        {
            return value.All(char.IsUpper) ? EnumStyle.UpperCase :
                value.All(char.IsLower) ? EnumStyle.LowerCase :
                default;
        }

        private static string WithEnumStyle(object value, EnumStyle style)
        {
            var txt = value as string ?? value?.ToString();
            switch (style)
            {
                case EnumStyle.LowerCase: return txt?.ToLowerInvariant();
                case EnumStyle.UpperCase: return txt?.ToUpperInvariant();
                default: return txt;
            }
        }

        private static string GetOrigin(object obj, string member)
        {
            var clazz = obj is string s
                ? Path.GetFileNameWithoutExtension(s)
                : $"{obj.GetType().Name}_{obj.GetHashCode()}";
            return $"{clazz}#{member}";
        }

        private static IDictionary<string, int> _fractions;
        private static IDictionary<string, EnumStyle> _styles;
        private static IDictionary<string, bool> _newLines;
        
        public static void SetUpQuirks(IDictionary<string, int> fractions, 
            IDictionary<string, bool> newLines, IDictionary<string, EnumStyle> styles)
        {
            _fractions = fractions; _styles = styles; _newLines = newLines;
        }
        #endregion

        #region Float
        public static string FormatFloat(float? value,
            object t = null, [CallerFilePath] string f = "", [CallerMemberName] string m = "")
        {
            var origin = GetOrigin(t ?? f, m);
            if (_fractions == null || !_fractions.TryGetValue(origin, out var length)) length = 2;
            var txt = value?.ToString($"F{length}", Inv);
            return txt;
        }

        public static float? ParseFloat(string value,
            object t = null, [CallerFilePath] string f = "", [CallerMemberName] string m = "")
        {
            if (_fractions != null)
            {
                var origin = GetOrigin(t ?? f, m);
                _fractions[origin] = GetFractionLength(value);
            }
            return float.TryParse(value, NU.Any, Inv, out var v) ? v : null;
        }
        #endregion

        #region Double
        public static string FormatDouble(double? value,
            object t = null, [CallerFilePath] string f = "", [CallerMemberName] string m = "")
        {
            var origin = GetOrigin(t ?? f, m);
            if (_fractions == null || !_fractions.TryGetValue(origin, out var length)) length = 6;
            var txt = value?.ToString($"F{length}", Inv);
            return txt;
        }

        public static double? ParseDouble(string value,
            object t = null, [CallerFilePath] string f = "", [CallerMemberName] string m = "")
        {
            if (_fractions != null)
            {
                var origin = GetOrigin(t ?? f, m);
                _fractions[origin] = GetFractionLength(value);
            }
            return double.TryParse(value, NU.Any, Inv, out var v) ? v : null;
        }
        #endregion

        #region Char
        public static string FormatChar(char? value)
        {
            return value?.ToString();
        }

        public static char? ParseChar(string value)
        {
            return char.TryParse(value, out var v) ? v : null;
        }
        #endregion

        #region Enum
        public static string FormatEnum<T>(T? value,
            object t = null, [CallerFilePath] string f = "", [CallerMemberName] string m = "") 
            where T : struct
        {
            var origin = GetOrigin(t ?? f, m);
            if (_styles == null || !_styles.TryGetValue(origin, out var style)) style = EnumStyle.LowerCase;
            var txt = WithEnumStyle(value, style);
            return txt;
        }

        public static T? ParseEnum<T>(string value,
            object t = null, [CallerFilePath] string f = "", [CallerMemberName] string m = "") 
            where T : struct
        {
            if (_styles != null)
            {
                var origin = GetOrigin(t ?? f, m);
                _styles[origin] = GetEnumStyle(value);
            }
            return Enum.TryParse<T>(value, ignoreCase: true, out var v) ? v : null;
        }
        #endregion

        #region Version
        public static string FormatVersion(Version value)
        {
            return value?.ToString();
        }

        public static Version ParseVersion(string value)
        {
            return Version.TryParse(value, out var v) ? v : null;
        }
        #endregion

        #region Uri
        public static string FormatUri(Uri value)
        {
            return value.ToString();
        }

        public static Uri ParseUri(string value)
        {
            return new Uri(value, UriKind.Absolute);
        }
        #endregion

        #region Bytes
        public static string FormatBytes(byte[] value,
            object t = null, [CallerFilePath] string f = "", [CallerMemberName] string m = "")
        {
            var origin = GetOrigin(t ?? f, m);
            if (_newLines == null || !_newLines.TryGetValue(origin, out var addFeed)) addFeed = false;
            var txt = Convert.ToBase64String(value, Base64FormattingOptions.InsertLineBreaks);
            if (addFeed)
                txt += "\r\n";
            return txt;
        }

        public static byte[] ParseBytes(string value,
            object t = null, [CallerFilePath] string f = "", [CallerMemberName] string m = "")
        {
            if (_newLines != null)
            {
                var origin = GetOrigin(t ?? f, m);
                _newLines[origin] = value.LastOrDefault() == '\n';
            }
            var array = Convert.FromBase64String(value);
            return array;
        }
        #endregion

        #region Date
        public static string FormatDate(DateTime? value, string format)
        {
            return value?.ToString(format);
        }

        public static DateTime? ParseDate(string value, string format)
        {
            return DateTime.TryParseExact(value, format, Inv, DS.None, out var v)
                ? v
                : null;
        }
        #endregion
    }
}