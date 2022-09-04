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
        public void ShouldWriteV3PartI(string name, double? boPatch = null)
            => ShouldWrite(name, "part", "3", true, boPatch);

        [Theory]
        [InlineData("3266_im")]
        public void ShouldWriteV3PartR(string name, double? boPatch = null)
            => ShouldWrite(name, "part", "3", false, boPatch);

        // [Theory]
        [InlineData("3491_te", 0.1)]
        public void ShouldWriteV4PartI(string name, double? boPatch = null)
            => ShouldWrite(name, "part", "4", true, boPatch);

        [Theory]
        [InlineData("3491_te", 0.1)]
        public void ShouldWriteV4PartR(string name, double? boPatch = null)
            => ShouldWrite(name, "part", "4", false, boPatch);

        private static void ShouldWrite(string name, string dir, string ver,
            bool interactive, double? boPatch = null)
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
            convertor.Save(dest, options, GetStd(boPatch));

            var (a, b) = LoadLines(src, dest);
            Assert.Equal(a, b);
            Assert.Equal(new FileInfo(src).Length, new FileInfo(dest).Length);
        }
    }
}