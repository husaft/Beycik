namespace Beycik.Model.API
{
    public interface IStyleable
    {
        bool? Bold { get; }

        string FontFace { get; }

        float? FontSize { get; }

        bool? Italic { get; }

        bool? Underline { get; }
    }
}