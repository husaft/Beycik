namespace Beycik.PDF.Core
{
    public interface IExportable
    {
        (int len, byte[] mem) ExportToArray();

        int ExportToFile(string filename);
    }
}