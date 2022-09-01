using System;
using static System.Globalization.DateTimeStyles;

namespace Beycik.Model.Tools
{
    public static class ValueEx
    {
        public static string FormatBool(bool? value)
        {
            string txt;
            switch (value)
            {
                case true:
                    txt = "yes";
                    break;
                case false:
                    txt = "no";
                    break;
                default:
                    return null;
            }
            txt = txt.ToLowerInvariant();
            return txt;
        }

        public static bool? ParseBool(string value)
        {
            var txt = value?.ToLowerInvariant();
            switch (txt)
            {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    return null;
            }
        }

        public static string FormatFloat(float? value, bool removeZero = false)
        {
            var text = value?.ToString("F2");
            if (removeZero)
                text = text?.Replace(".00", string.Empty);
            return text;
        }

        public static float? ParseFloat(string value)
            => float.TryParse(value, out var v) ? v : null;

        public static double? ParseDouble(string value)
            => double.TryParse(value, out var v) ? v : null;

        public static byte? ParseByte(string value)
            => byte.TryParse(value, out var v) ? v : null;

        public static string FormatEnum<T>(T value, bool upper = false) where T : struct
        {
            var txt = value.ToString();
            return upper ? txt?.ToUpperInvariant() : txt?.ToLowerInvariant();
        }
        
        public static string FormatMyEnum<T>(T value) where T : struct
        {
            var txt = value.ToString();
            return txt;
        }

        public static string FormatEnum<T>(T? value, bool upper = false) where T : struct
        {
            var txt = value?.ToString();
            return upper ? txt?.ToUpperInvariant() : txt?.ToLowerInvariant();
        }
        
        public static T ParseEnum<T>(string value) where T : struct
            => Enum.Parse<T>(value, ignoreCase: true);

        public static T ParseMyEnum<T>(string value) where T : struct
            => Enum.Parse<T>(value, ignoreCase: false);
        
        public static T? TryParseEnum<T>(string value) where T : struct
            => Enum.TryParse<T>(value, ignoreCase: true, out var v) ? v : null;
        
        public static string FormatByte(byte? value)
            => value?.ToString();

        public static string FormatVersion(Version value)
            => value.ToString();

        public static Version ParseVersion(string value)
            => Version.Parse(value);

        public static string FormatUri(Uri value)
            => value.ToString();

        public static Uri ParseUri(string value)
            => new(value, UriKind.Absolute);

        public static string FormatChar(char? value)
            => value?.ToString();

        public static char? ParseChar(string value)
            => char.TryParse(value, out var v) ? v : null;

        public static string FormatDouble(double? value)
            => value?.ToString("F6");

        public static string FormatDate(DateTime date, string format)
            => date.ToString(format);

        public static string FormatDate(DateTime? date, string format)
            => date?.ToString(format);

        public static DateTime ParseDate(string value, string format)
            => DateTime.ParseExact(value, format, null);

        public static DateTime? TryParseDate(string value, string format)
            => DateTime.TryParseExact(value, format, null, None, out var v)
                ? v
                : null;

        public static string FormatBytes(byte[] value) 
            => Convert.ToBase64String(value, Base64FormattingOptions.InsertLineBreaks);

        public static byte[] ParseBytes(string value) 
            => Convert.FromBase64String(value);

        public static short? ParseShort(string value) 
            => short.TryParse(value, out var v) ? v : null;

        public static string FormatShort(short? value) 
            => value?.ToString();
    }
}