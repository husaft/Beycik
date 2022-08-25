using System;
using System.IO;

namespace Beycik.Draw.Tests
{
    public static class TestUtils
    {
        public static byte[] LoadBytes(Type type, string name)
        {
            var assembly = type.Assembly;
            var path = $"{type.Namespace}.Resources.{name}";
            using var stream = assembly.GetManifestResourceStream(path)!;
            using var mem = new MemoryStream();
            stream.CopyTo(mem);
            return mem.ToArray();
        }
    }
}