using System;
using System.Linq;
using Beycik.Draw;
using Beycik.Draw.Fonts.API;
using Beycik.Model.Objects;
using Beycik.Model.Objects.Scraps;
using Beycik.PDF.Config;
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

        public static void Handle(TextCluster tc, PdfPage page, PdfDocument pdf,
            IFontManager fonts, PdfRect r, IEncodingPatcher texts, TextMetrics metrics)
        {
            var angle = tc.Angle ?? 0.0;
            var lineHeight = tc.LineHeight ?? 1.0;
            var align = tc.Align ?? Direction.Left;

            if (angle == 0.0)
            {
                RenderClustered(pdf, page, r, tc, align, lineHeight, fonts, texts, metrics);
                return;
            }

            page.Stream.PushGraphicsState();
            page.Stream.SetMatrix(0.0, 1.0, -1.0, 0.0, r.Right + r.Bottom, -r.Left + r.Bottom);
            var left = r.Left;
            var top = r.Top - r.Height + r.Width;
            var right = left + r.Height;
            var bottom = top + r.Width;
            var tcRect = new PdfRect(left, top, right, bottom);
            RenderClustered(pdf, page, tcRect, tc, align, lineHeight, fonts, texts, metrics);
            page.Stream.PopGraphicsState();
        }

        public static void Handle(Line line, PdfPage page, double pageHeight)
        {
            page.Stream.SetLineMode(line.LineSize ?? 1.0, 0.0, 0.0);
            page.Stream.SetColor(Colors.Black);
            var lineRed = line.Red ?? 0;
            var lineGreen = line.Green ?? 0;
            var lineBlue = line.Blue ?? 0;
            var color = new Color(lineRed, lineGreen, lineBlue);
            page.Stream.SetColor(color);
            var rect = new PdfRect(Left: line.X ?? 0.0, Top: line.Y ?? 0.0,
                    Right: line.X2 ?? 0.0, Bottom: line.Y2 ?? 0.0)
                .Convert(pageHeight);
            page.Stream.AddLine(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        public static void Handle(Rectangle myRect, PdfPage page, PdfRect rect)
        {
            var red = myRect.Red ?? 0;
            var green = myRect.Green ?? 0;
            var blue = myRect.Blue ?? 0;
            var shape = myRect.Shape ?? Shape.Rect;
            var type = myRect.DrawType ?? DrawType.None;
            var color = new Color(red, green, blue);
            page.Stream.SetColor(color);

            if (shape == Shape.Rect)
            {
                if (type == DrawType.Solid)
                {
                    var lineSize = myRect.LineSize ?? 0.0;
                    page.Stream.SetLineMode(lineSize, 0.0, 0.0);
                    page.Stream.AddSolidRect(rect);
                    if (Math.Abs(0.0 - lineSize) > 0.001)
                        page.Stream.AddRect(rect);
                    return;
                }
                page.Stream.SetLineMode(myRect.LineSize ?? 1.0, 0.0, 0.0);
                page.Stream.AddRect(rect);
                return;
            }

            if (shape == Shape.Triangle)
            {
                var orient = myRect.Orientation ?? 'r';
                if (type == DrawType.Solid)
                {
                    var lineSize = myRect.LineSize ?? 0.0;
                    page.Stream.SetLineMode(lineSize, 0.0, 0.0);
                    page.Stream.AddSolidTriangle(rect, orient);
                    if (lineSize != 0.0)
                        page.Stream.AddTriangle(rect, orient);
                    return;
                }
                page.Stream.SetLineMode(myRect.LineSize ?? 1.0, 0.0, 0.0);
                page.Stream.AddTriangle(rect, orient);
                return;
            }

            if (shape == Shape.Circle)
            {
                if (type == DrawType.Solid)
                {
                    var lineSize = myRect.LineSize ?? 0.0;
                    page.Stream.SetLineMode(lineSize, 0.0, 0.0);
                    page.Stream.AddSolidCircle(rect);
                    if (lineSize != 0.0)
                        page.Stream.AddCircle(rect);
                    return;
                }
                page.Stream.SetLineMode(myRect.LineSize ?? 1.0, 0.0, 0.0);
                page.Stream.AddCircle(rect);
            }
        }

        public static void Handle(CheckBox cb, PdfOptions options, PdfPage page, PdfRect r)
        {
            var cbShape = !options.AllCheckBoxRect ? cb.Shape ?? Shape.Rect : Shape.Rect;
            page.Stream.SetLineMode(1.0, 0.0, 0.0);
            page.Stream.SetColor(Colors.Black);
            if (cb.PrintBorder ?? true)
            {
                if (cbShape == Shape.Circle)
                    page.Stream.AddCircle(r);
                else
                    page.Stream.AddRect(r);
            }
            if (cb.Content != "0")
            {
                page.Stream.SetLineMode(2.0, 0.0, 0.0);
                page.Stream.AddLine(r.Left + 2.0, r.Top - 2.0, r.Right - 2.0, r.Bottom + 2.0);
                page.Stream.AddLine(r.Left + 2.0, r.Bottom + 2.0, r.Right - 2.0, r.Top - 2.0);
            }
        }

        public static void Handle(DropDown dd, PdfPage page, PdfRect rect, PdfDocument pdf,
            FontHandle font, IEncodingPatcher ec, TextMetrics metrics, IFontManager fonts)
        {
            const Direction mode = Direction.Left;
            var text = $"{dd.Options.First().Map ?? dd.Value} ";
            const double height = 1.0;
            RenderSimple(pdf, page, rect, font, text, mode, height, fonts, ec, metrics);
        }

        public static void Handle(Frame _)
        {
            // NO-OP
        }

        public static void Handle(TextField _)
        {
            // NO-OP
        }

        public static void Handle(Info _)
        {
            // NO-OP
        }

        public static void Handle(TextArea _)
        {
            // NO-OP
        }

        public static void Handle(Container _)
        {
            // NO-OP
        }

        public static void Handle(HotSpot _)
        {
            // NO-OP
        }
    }
}