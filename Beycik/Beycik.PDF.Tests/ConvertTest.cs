using System;
using System.IO;
using Xunit;
using Beycik.Model;
using System.Linq;
using Beycik.PDF.Config;
using static Beycik.Model.Tests.TestHelper;
using static Beycik.PDF.Tests.PestHelper;

namespace Beycik.PDF.Tests
{
    public class ConvertTest
    {
        // [Theory]
        [InlineData("3266_im")]
        public void ShouldWriteV3PartI(string name, params double[] boPatch)
            => ShouldWrite(name, "part", "3", true, boPatch);

        [Theory]
        [InlineData("0888_fr")]
        [InlineData("0888_li")]
        [InlineData("0888_re")]
        [InlineData("0888_tc", 0.1)]
        [InlineData("0888_td", 0.1)]
        [InlineData("0888_tx")]
        [InlineData("3266_im")]
        [InlineData("0888_cb")]
        [InlineData("0888_tf")]
        [InlineData("2900_dd")]
        [InlineData("2900_in")]
        [InlineData("3001_ta")]
        public void ShouldWriteV3PartR(string name, params double[] boPatch)
            => ShouldWrite(name, "part", "3", false, boPatch);

        // [Theory]
        [InlineData("3491_te", 0.1)]
        public void ShouldWriteV4PartI(string name, params double[] boPatch)
            => ShouldWrite(name, "part", "4", true, boPatch);

        [Theory]
        [InlineData("2454_co")]
        [InlineData("3660_ho")]
        [InlineData("0443_ua")]
        [InlineData("2845_ub", 0.1)]
        [InlineData("4531_uc", 0.1)]
        [InlineData("4627_ud", 0.0, 0.0, -0.01, -0.01, 0.0, 0.0)]
        public void ShouldWriteV4PartR(string name, params double[] boPatch)
            => ShouldWrite(name, "part", "4", false, boPatch);

        private static void ShouldWrite(string name, string dir, string ver,
            bool interactive, params double[] boPatch)
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
                var idx = 0;
                patcher = () => boPatch[boPatch.Length == 1 ? 0 : idx++];
            }
            convertor.Save(dest, options, GetStd(patcher));

            var (a, b) = LoadLines(src, dest);
            Assert.Equal(a, b);
            Assert.Equal(new FileInfo(src).Length, new FileInfo(dest).Length);
        }
    }
}