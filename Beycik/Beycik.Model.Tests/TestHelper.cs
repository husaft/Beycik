using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.XmlDiffPatch;

namespace Beycik.Model.Tests
{
    public static class TestHelper
    {
        public static (string[] a, string[] b) LoadLines(string first, string second)
        {
            var firstFile = File.ReadAllLines(first, Encoding.UTF8);
            var secondFile = File.ReadAllLines(second, Encoding.UTF8);
            return (firstFile, secondFile);
        }

        public static string GetResource(string name, params string[] paths)
        {
            var root = AppContext.BaseDirectory;
            root = Path.Combine(root, "..", "..", "..", "Resources");
            if (paths.Length >= 1)
                root = Path.Combine(root, Path.Combine(paths));
            root = Path.GetFullPath(root);
            var file = Path.Combine(root, name);
            return file;
        }

        public static (string a, string b) LoadXNode(string first, string second)
        {
            using var firstFile = File.OpenRead(first);
            using var secondFile = File.OpenRead(second);
            var doc1 = XDocument.Load(firstFile, LoadOptions.None);
            var doc2 = XDocument.Load(secondFile, LoadOptions.None);
            using var doc1Out = new Utf8StrWriter();
            doc1.Save(doc1Out, SaveOptions.None);
            using var doc2Out = new Utf8StrWriter();
            doc2.Save(doc2Out, SaveOptions.None);
            return (doc1Out.ToString(), doc2Out.ToString());
        }

        public static void CreateFolderOf(string file)
        {
            var dir = Path.GetDirectoryName(file) ?? string.Empty;
            Directory.CreateDirectory(dir);
        }

        private static XmlReader ReadXml(string file, bool patch)
        {
            if (!patch)
            {
                return XmlReader.Create(File.OpenRead(file));
            }
            var content = File.ReadAllText(file, Encoding.UTF8);
            content = content.Replace("&#13;", "\r")
                .Replace("&#xD;", "\r")
                .Replace("&#10;", "\n")
                .Replace("&#xA;", "\n");
            return XmlReader.Create(new StringReader(content));
        }

        public static string CompareXml(string firstFile, string secondFile, bool patch)
        {
            using var first = ReadXml(firstFile, patch);
            using var second = ReadXml(secondFile, patch);
            const int b = (int)XmlDiffOptions.IgnoreXmlDecl |
                          (int)XmlDiffOptions.IgnoreNamespaces |
                          (int)XmlDiffOptions.IgnoreChildOrder;
            var diff = new XmlDiff((XmlDiffOptions)b);
            var bld = new StringBuilder();
            using var writer = XmlWriter.Create(bld, new XmlWriterSettings { Indent = true });
            var res = diff.Compare(first, second, writer);
            return res ? null : bld.ToString();
        }

        public static void WriteLines(string aText, string aFile, string bText, string bFile)
            => WriteLines(new[] { aText }, aFile, new[] { bText }, bFile);

        private static void WriteLines(string[] aLines, string aFile, string[] bLines, string bFile)
        {
            File.WriteAllLines(aFile, aLines, Encoding.UTF8);
            File.WriteAllLines(bFile, bLines, Encoding.UTF8);
        }
    }
}