using System;

namespace Beycik.Draw.Images.API
{
    public interface IImage : IDisposable
    {
        int Width { get; }

        int Height { get; }
    }
}