using System.Text;

namespace Beycik.PDF.Config
{
    public interface IConfig
    {
        Encoding Enc { get; }

        string Title { get; set; }
        string Author { get; set; }
        string CreatorName { get; }
        string CreatorVersion { get; }
        string ProducerName { get; }
        string ProducerWeb { get; }

        Quirks Quirks { get; }
    }
}