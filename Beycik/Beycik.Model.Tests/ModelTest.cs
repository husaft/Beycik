using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Beycik.Model.Tools;
using Xunit;
using static Beycik.Model.Tests.TestHelper;

namespace Beycik.Model.Tests
{
    public class ModelTest
    {
        static ModelTest()
        {
            ValueEx.SetUpQuirks(
                new Dictionary<string, int>(),
                new Dictionary<string, bool>(),
                new Dictionary<string, EnumStyle>()
            );
        }
        
        [Theory]
        [InlineData("0001")]
        [InlineData("0002")]
        [InlineData("0003")]
        [InlineData("0004")]
        [InlineData("0167")]
        [InlineData("0360")]
        [InlineData("0468")]
        [InlineData("0887")]
        [InlineData("0888")]
        [InlineData("0893")]
        [InlineData("0894")]
        [InlineData("1007")]
        [InlineData("1220")]
        [InlineData("1245")]
        [InlineData("1295")]
        [InlineData("1415")]
        [InlineData("1423")]
        [InlineData("1527")]
        [InlineData("1529")]
        [InlineData("1531")]
        [InlineData("1666")]
        [InlineData("2309")]
        [InlineData("2313")]
        [InlineData("2317")]
        [InlineData("2422")]
        [InlineData("2629")]
        [InlineData("2900")]
        [InlineData("3001")]
        [InlineData("3039")]
        [InlineData("3108")]
        [InlineData("3197")]
        [InlineData("3266")]
        [InlineData("3860")]
        [InlineData("4243")]
        [InlineData("4250")]
        [InlineData("4525")]
        [InlineData("5855")]
        public void ShouldReadV3Full(string name)
            => ShouldRead(name, "full", "3");
        
        [Theory]
        [InlineData("0888_cb")]
        [InlineData("0888_fr")]
        [InlineData("0888_li")]
        [InlineData("0888_re")]
        [InlineData("0888_tc")]
        [InlineData("0888_td")]
        [InlineData("0888_tf")]
        [InlineData("0888_tx")]
        [InlineData("0888_fs")]
        [InlineData("1666_tj")]
        [InlineData("3001_ta")]
        [InlineData("2900_dd")]
        [InlineData("2900_in")]
        [InlineData("3266_im")]
        public void ShouldReadV3Part(string name)
            => ShouldRead(name, "part", "3");
        
        [Theory]
        [InlineData("4217")]
        [InlineData("0111")]
        [InlineData("0180")]
        [InlineData("0230")]
        [InlineData("0443", true)]
        [InlineData("0507")]
        [InlineData("0634")]
        [InlineData("0757")]
        [InlineData("0796")]
        [InlineData("0807")]
        [InlineData("1048")]
        [InlineData("1147")]
        [InlineData("2423")]
        [InlineData("2427")]
        [InlineData("2454")]
        [InlineData("2809")]
        [InlineData("2845", true)]
        [InlineData("2912")]
        [InlineData("3251")]
        [InlineData("3252")]
        [InlineData("3256")]
        [InlineData("3259")]
        [InlineData("3302")]
        [InlineData("3303")]
        [InlineData("3304")]
        [InlineData("3491")]
        [InlineData("3614")]
        [InlineData("3660")]
        [InlineData("3689")]
        [InlineData("3691")]
        [InlineData("3692")]
        [InlineData("3695")]
        [InlineData("3696")]
        [InlineData("4071")]
        [InlineData("4374")]
        [InlineData("4376")]
        [InlineData("4378")]
        [InlineData("4379")]
        [InlineData("4380")]
        [InlineData("4381")]
        [InlineData("4382")]
        [InlineData("4529")]
        [InlineData("4530")]
        [InlineData("4531", true)]
        [InlineData("4532")]
        [InlineData("4627", true)]
        [InlineData("5430")]
        [InlineData("5589")]
        [InlineData("5850")]
        [InlineData("6245")]
        [InlineData("6246")]
        [InlineData("6289")]
        [InlineData("6316")]
        [InlineData("6362")]
        [InlineData("6395")]
        public void ShouldReadV4Full(string name, bool p13 = false)
            => ShouldRead(name, "full", "4", p13);
        
        [Theory]
        [InlineData("3491_te")]
        [InlineData("3660_ho")]
        [InlineData("2454_co")]
        [InlineData("0443_ua", true)]
        [InlineData("2845_ub", true)]
        [InlineData("4531_uc", true)]
        [InlineData("4627_ud", true)]
        public void ShouldReadV4Part(string name, bool p13 = false)
            => ShouldRead(name, "part", "4", p13);
        
        private static void ShouldRead(string name, string dir, string ver, bool p13 = false)
        {
            var errors = new List<string>();
            XmlHelper.Errors = errors;

            var origFile = GetResource($"{name}.xml", $"v{ver}", dir);
            var origDoc = XmlHelper.ReadFile(origFile);

            if (origDoc == null)
                throw new InvalidOperationException(string.Join(Environment.NewLine, errors));

            Assert.Equal($"{ver}.0", origDoc.Version.ToString());
            var formId = origDoc.FormInfo?.FormServer?.FormId.ToString();
            var fName = name.Split('_').First();
            Assert.Equal(fName, formId?.PadLeft(4, '0'));

            var newFile = origFile.Replace("Resources", "Outputs");
            CreateFolderOf(newFile);
            XmlHelper.WriteFile(newFile, origDoc);
            XmlHelper.Errors = null;

            var xmlDiff = CompareXml(origFile, newFile, p13);
            var (a, b) = LoadXNode(origFile, newFile);
            var debugA = Path.GetFullPath($"{name}_a.xml");
            var debugB = Path.GetFullPath($"{name}_b.xml");
            WriteLines(a, debugA, b, debugB);
            var d = string.Format("{0}{1}{2}{1}{1}", debugA, Environment.NewLine, debugB);
            Assert.True(xmlDiff == null, d + xmlDiff);

            Assert.Empty(errors);
        }
    }
}