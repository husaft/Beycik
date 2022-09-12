using System.Threading.Tasks;
using Beycik.Draw;
using Beycik.Draw.Fonts.API;

namespace Beycik.Demo
{
    internal static class Patches
    {
        public static async Task<IFontExManager> LoadForWeb()
        {
            var manager = (IFontExManager)Graphics.FontManager;
            var assembly = typeof(Program).Assembly;
            foreach (var name in assembly.GetManifestResourceNames())
            {
                if (!name.EndsWith(".ttf"))
                    continue;
                await using var stream = assembly.GetManifestResourceStream(name);
                manager.Fonts.Add(stream!);
            }
            return manager;
        }
    }
}