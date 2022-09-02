using Xunit;
using Beycik.Model;
using static Beycik.Model.Tests.TestHelper;
using System.Linq;
using Beycik.PDF.Config;

namespace Beycik.PDF.Tests
{
    public class ConvertTest
    {
        [Theory]
        [InlineData("3266_im")]
        public void ShouldWriteV3PartI(string name, double? boPatch = null)
            => ShouldWrite(name, "part", "3", true, boPatch);

        [Theory]
        [InlineData("3266_im")]
        public void ShouldWriteV3PartR(string name, double? boPatch = null)
            => ShouldWrite(name, "part", "3", false, boPatch);

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






            // TODO ?!
            ;







        }
    }
}