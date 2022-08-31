using System;

namespace Beycik.Model.Tools
{
    public static class ValueEx
    {
        public static string FormatBool(bool? value)
        {
            return value?.ToString();
        }

        public static bool? ParseBool(string value)
        {
            var txt = value?.ToLowerInvariant();
            switch (txt)
            {
                case "yes": return true;
                case "no": return false;
                default: return null;
            }
        }

        public static string FormatFloat(float? value)
            => value?.ToString("F2");

        public static float? ParseFloat(string value)
            => float.TryParse(value, out var v) ? v : null;

        public static double? ParseDouble(string value)
            => double.TryParse(value, out var v) ? v : null;

        public static byte? ParseByte(string value)
            => byte.TryParse(value, out var v) ? v : null;

        public static string FormatEnum<T>(T value) where T : struct
            => value.ToString();

        public static T ParseEnum<T>(string value) where T : struct
            => Enum.Parse<T>(value, ignoreCase: true);

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
    }
}