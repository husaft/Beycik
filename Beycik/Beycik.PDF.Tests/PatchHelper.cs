using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace Beycik.PDF.Tests
{
    internal static class PatchHelper
    {
        public static void FixMinorIssues(string srcFile, string dstFile, Encoding enc)
        {
            var src = File.ReadAllText(srcFile, enc);
            var dst = File.ReadAllText(dstFile, enc);
            var diff = InlineDiffBuilder.Diff(src, dst);
            var delLines = new List<string>();
            var insLines = new List<string>();
            foreach (var piece in diff.Lines)
            {
                if (piece.Type == ChangeType.Deleted)
                    delLines.Add(piece.Text);
                if (piece.Type is ChangeType.Inserted or ChangeType.Unchanged)
                    insLines.Add(piece.Text);
            }
            var maybeFixed = false;
            for (var i = 0; i < insLines.Count; i++)
            {
                var inserted = insLines[i];
                var match = delLines.Select((d, j) => (idx: j,
                        diff: GetDiff(d, d.Length == inserted.Length ? inserted : null).ToArray()))
                    .FirstOrDefault(d => (d.diff.Length == 1
                                          && char.IsDigit(d.diff[0].before)
                                          && char.IsDigit(d.diff[0].after)) ||
                                         (d.diff.Length == 2
                                          && char.IsDigit(d.diff[0].before)
                                          && char.IsDigit(d.diff[0].after)
                                          && char.IsDigit(d.diff[1].before)
                                          && char.IsDigit(d.diff[1].after)) ||
                                         (d.diff.Length == 3
                                          && char.IsDigit(d.diff[0].before)
                                          && char.IsDigit(d.diff[0].after)
                                          && char.IsDigit(d.diff[1].before)
                                          && char.IsDigit(d.diff[1].after)
                                          && char.IsDigit(d.diff[2].before)
                                          && char.IsDigit(d.diff[2].after)));
                if (match.diff == null)
                    continue;
                var replace = delLines[match.idx];
                delLines.RemoveAt(match.idx);
                insLines.RemoveAt(i);
                insLines.Insert(i, replace);
                maybeFixed = true;
            }
            if (!maybeFixed)
                return;
            File.WriteAllLines(dstFile, insLines, enc);
        }

        private static IEnumerable<(int index, char before, char after)> GetDiff(string first, string second)
        {
            var firstLen = first?.Length ?? 0;
            var secondLen = second?.Length ?? 0;
            for (var i = 0; i < firstLen && i < secondLen; i++)
            {
                var a = first?[i];
                var b = second?[i];
                if (a == null || b == null || a == b)
                    continue;
                yield return (i, a.Value, b.Value);
            }
        }
    }
}