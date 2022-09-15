using System;
using System.IO;
using Xunit;
using Beycik.Model;
using System.Linq;
using Beycik.Model.Tools;
using Beycik.PDF.Config;
using static Beycik.Model.Tests.TestHelper;
using static Beycik.PDF.Tests.PestHelper;

namespace Beycik.PDF.Tests
{
    public class ConvertTest
    {
        [Theory]
        [InlineData("2309")]
        [InlineData("2317")]
        public void ShouldWriteV3FullR(string name, params string[] boPatch)
            => ShouldWrite(name, "full", "3", false, boPatch);

        [Theory]
        [InlineData("0888_fr")]
        [InlineData("0888_li")]
        [InlineData("0888_re")]
        [InlineData("0888_tc", "0:0.1")]
        [InlineData("0888_td", "0:0.1")]
        [InlineData("0888_tx")]
        [InlineData("0888_fs", "5:0.1", "7:0.1", "9:0.1", "11:0.1", "13:0.1", "14:0.1")]
        [InlineData("1666_tj", "0:0.1")]
        [InlineData("3266_im")]
        [InlineData("0888_cb")]
        [InlineData("0888_tf")]
        [InlineData("2900_dd")]
        [InlineData("2900_in")]
        [InlineData("1423_bv")]
        [InlineData("3001_ta")]
        [InlineData("3999_on", "0:0.1", "1:0.1", "11:0.1", "12:0.1", "13:0.1",
            "14:0.1", "15:0.1", "16:0.1", "17:0.1", "18:0.1", "19:0.1")]
        public void ShouldWriteV3PartR(string name, params string[] boPatch)
            => ShouldWrite(name, "part", "3", false, boPatch);

        [Theory]
        [InlineData("4529")]
        [InlineData("3252")]
        public void ShouldWriteV4FullR(string name, params string[] boPatch)
            => ShouldWrite(name, "full", "4", false, boPatch);

        [Theory]
        [InlineData("2454_co")]
        [InlineData("3660_ho")]
        [InlineData("0443_ua")]
        [InlineData("3491_te", "0:0.1")]
        [InlineData("2845_ub", "0:0.1")]
        [InlineData("4531_uc", "0:0.1")]
        [InlineData("4627_ud", "2:-0.01", "3:-0.01")]
        [InlineData("4999_on", "0:0.1", "1:0.1", "2:0.1", "3:0.1", "4:0.1", "5:0.1",
            "6:0.1", "7:0.1", "8:0.1", "9:0.1", "10:0.1", "26:0.1", "27:0.1")]
        public void ShouldWriteV4PartR(string name, params string[] boPatch)
            => ShouldWrite(name, "part", "4", false, boPatch);

        private static void ShouldWrite(string name, string dir, string ver,
            bool interactive, params string[] boPatch)
        {
            var origFile = GetResource($"{name}", $"v{ver}", dir);
            var otherDir = origFile.Replace(".PDF.Tests", ".Model.Tests");
            var inputDoc = XmlHelper.ReadFile($"{otherDir}.xml");

            Assert.Equal($"{ver}.0", inputDoc.Version.ToString());
            var formId = inputDoc.FormInfo.FormServer.FormId.ToString();
            var fName = name.Split('_').First();
            Assert.Equal(fName, formId.PadLeft(4, '0'));

            var options = interactive ? PdfOption.GetInteractive() : PdfOption.GetReadOnly();
            var src = $"{origFile}_{(interactive ? "iv" : "ro")}.pdf";
            var dest = src.Replace("Resources", "Outputs");
            CreateFolderOf(dest);

            using var convertor = new Xml2Pdf(inputDoc);
            Func<double?> patcher = null;
            if (boPatch.Length >= 1)
            {
                var map = boPatch
                    .Select(t => t.Split(":", 2))
                    .ToDictionary(k => int.Parse(k[0]),
                        v => double.Parse(v[1], ValueEx.Inv));
                var idx = 0;
                patcher = () => map.Count == 1 && map.TryGetValue(0, out var val) ? val :
                    map.TryGetValue(idx++, out val) ? val :
                    0;
            }
            var config = GetStd(patcher);
            convertor.Save(dest, options, config);

            if (!name.Contains('_'))
                PatchHelper.FixMinorIssues(src, dest, config.Enc);

            var (a, b) = LoadLines(src, dest);
            Assert.Equal(a, b);
            Assert.Equal(new FileInfo(src).Length, new FileInfo(dest).Length);
        }
    }
}