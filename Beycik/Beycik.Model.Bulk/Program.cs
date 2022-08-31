using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Beycik.Model.Bulk
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: (exe) [folder]");
                return;
            }

            var folder = args[0];
            folder = Path.GetFullPath(folder);
            Console.WriteLine($"Root => {folder}");

            const string pattern = "*.xml";
            const SearchOption opt = SearchOption.AllDirectories;
            var files = Directory.EnumerateFiles(folder, pattern, opt);

            var errors = new List<string>();
            XmlHelper.Errors = errors;

            foreach (var file in files)
            {
                errors.Clear();
                var label = file.Replace(folder, string.Empty);
                Console.Write($" * '{label}'");

                var doc = XmlHelper.ReadFile(file);
                var size = doc?.Objects.Items.Count ?? -1;
                Console.WriteLine($" --> {size} objects found");

                if (!errors.Any())
                    continue;

                var text = string.Join(Environment.NewLine, errors.Select(e => $"   {e}"));
                Console.WriteLine(text);
                break;
            }

            Console.WriteLine("Done.");
        }
    }
}