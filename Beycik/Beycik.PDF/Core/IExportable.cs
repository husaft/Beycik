namespace Beycik.PDF.Core
{
    public interface IExportable
    {
        byte[] ExportToArray();

        int ExportToFile(string filename);
    }
}