using System.IO;
using System.Text;

namespace Beycik.Model.Tests
{
    internal sealed class Utf8StrWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}