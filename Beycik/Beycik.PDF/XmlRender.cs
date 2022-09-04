using System;
using Beycik.Draw;
using Beycik.Draw.Fonts.API;
using Beycik.Model.Objects;
using Beycik.Model.Objects.Scraps;
using Beycik.PDF.Core;
using Beycik.PDF.Text;
using Beycik.PDF.Visuals;
using static Beycik.PDF.Text.TextRender;
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
            PdfPage page, PdfDocument pdf, PdfRect r, FontHandle font,
            IEncodingPatcher ec, TextMetrics metrics)
        {
            var txt = text.Content;
            var angle = text.Angle ?? 0.0;
            var align = text.Align ?? Direction.Left;
            var lineHeight = text.LineHeight ?? 1.0;

            if (angle == 0.0)
            {
                RenderSimple(pdf, page, r, font, txt, align, lineHeight, fonts, ec, metrics);
                return;
            }

            page.Stream.PushGraphicsState();
            page.Stream.SetMatrix(0.0, 1.0, -1.0, 0.0, r.Right + r.Bottom, -r.Left + r.Bottom);
            var top = r.Top - r.Height + r.Width;
            var tr = r with
            {
                Top = top,
                Bottom = top + r.Width,
                Right = r.Left + r.Height,
            };
            RenderSimple(pdf, page, tr, font, txt, align, lineHeight, fonts, ec, metrics);
            page.Stream.PopGraphicsState();
        }

        public static void Handle(TextCluster tc)
        {
            // TODO throw new NotImplementedException();
        }

        public static void Handle(Line li)
        {
            // TODO throw new NotImplementedException();
        }

        public static void Handle(Rectangle re)
        {
            // TODO throw new NotImplementedException();
        }
    }
}