using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Beycik.Model.Tools;

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

            var outFolder = "Outputs";
            outFolder = Path.GetFullPath(outFolder);
            if (!Directory.Exists(outFolder))
                Directory.CreateDirectory(outFolder);
            Console.WriteLine($"Out => {outFolder}");

            const string pattern = "*.xml";
            const SearchOption opt = SearchOption.AllDirectories;
            var files = Directory.EnumerateFiles(folder, pattern, opt);

            var errors = new List<string>();
            XmlHelper.Errors = errors;
            DiffTools.CleanUp(outFolder);
            ValueEx.SetUpQuirks(
                null,
                null,
                new Dictionary<string, EnumStyle>()
            );

            var num = 0;
            foreach (var file in files)
            {
                errors.Clear();
                var label = file.Replace(folder, string.Empty);
                Console.Write($" * ({++num}) '{label}'");

                var doc = XmlHelper.ReadFile(file);
                var size = doc?.Objects.Items.Count ?? -1;
                Console.WriteLine($" --> {size} objects found");

                if (!DiffTools.CheckAsJson(file, doc, outFolder))
                    errors.Add("One or more differences in model!");

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