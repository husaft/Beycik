using Xunit;
using System.IO;
using Beycik.Model;
using Xunit;
using static Beycik.Model.Tests.TestHelper;
using System;
using System.IO;
using System.Linq;
using Beycik.Model.Tests;
using Xunit;
using static Beycik.Model.Tests.TestHelper;

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



            ;



        }
    }
}