using System;
using Beycik.Draw;
using Beycik.Draw.Fonts.API;
using Beycik.Model.Objects;
using Beycik.Model.Objects.Scraps;
using Beycik.PDF.Core;
using Beycik.PDF.Text;
using Beycik.PDF.Visuals;
using TextO = Beycik.Model.Objects.Text;

namespace Beycik.PDF
{
    internal static class XmlRender
    {
        public static void Handle(PdfRect rect, Image image, PdfPage page)
        {
            var imageData = image.Encoded;
            var loader = Graphics.ImageLoader;
            var handle = loader.Load(imageData, image.MimeType);
            var imRect = PdfRect.CopyFrom(rect);
            var type = image.SizeType ?? SizeType.Proportional;
            if (type == SizeType.Proportional)
            {
                var iconWidth = handle.Width;
                var iconHeight = handle.Height;
                var frameWidth = rect.Width / iconWidth;
                var frameHeight = rect.Height / iconHeight;
                if (frameHeight * iconWidth <= rect.Width)
                {
                    var hFactor = frameHeight * iconWidth;
                    var hWidth = rect.Width - hFactor;
                    var left = rect.Left + Math.Floor(hWidth * 0.5);
                    var right = left + hFactor;
                    imRect = imRect with { Left = left, Right = right };
                }
                else
                {
                    var wFactor = frameWidth * iconHeight;
                    var wHeight = rect.Height - wFactor;
                    var top = rect.Top - Math.Floor(wHeight * 0.5);
                    var bottom = top - wFactor;
                    imRect = imRect with { Top = top, Bottom = bottom };
                }
            }
            var gray = image.GrayScale ?? false;
            page.Stream.AddImage(imageData, imRect, handle.Width, handle.Height, gray);
        }

        public static void Handle(IFontManager fonts, TextO text,
            PdfPage page, PdfDocument pdf, PdfRect rect, FontHandle font)
        {
            throw new System.NotImplementedException();
        }
    }
}