using System;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace QR
{
    public class QRUtils
    {

        public Boolean OverlayImage { get; set; }

        public string ImagePath { get; set; }

        public string Text { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }


        public String readValueFromQR(String path)
        {
            var QrCode = (Bitmap)Bitmap.FromFile(path);
            var reader = new BarcodeReader();
            var result = reader.Decode(QrCode);
            if (result == null)
                return null;

            return result.ToString();
        }


        private void saveQR(String path, Bitmap image)
        {
            image.Save(path, ImageFormat.Jpeg);
        }

        public void GenerateQR(string path)
        {

            var bw = new ZXing.BarcodeWriter();

            var encOptions = new ZXing.Common.EncodingOptions
            {
                Width = this.Width,
                Height = this.Height,
                Margin = 0,
                PureBarcode = false
            };

            encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

            bw.Renderer = new BitmapRenderer();
            bw.Options = encOptions;
            bw.Format = ZXing.BarcodeFormat.QR_CODE;
            Bitmap bm = bw.Write(this.Text);
            if (this.OverlayImage)
            {
                Bitmap overlay = new Bitmap(ImagePath);
                Bitmap resizedOverlay = ResizeBitmap(overlay, 100, 100);
                int deltaHeigth = bm.Height - resizedOverlay.Height;
                int deltaWidth = bm.Width - resizedOverlay.Width;
                Graphics g = Graphics.FromImage(bm);
                g.DrawImage(resizedOverlay, new Point(deltaWidth / 2, deltaHeigth / 2));
            }
            else
            {
                int deltaHeigth = bm.Height;
                int deltaWidth = bm.Width;
                Graphics g = Graphics.FromImage(bm);
                g.DrawImage(bm, new Point(deltaWidth / 2, deltaHeigth / 2));
            }

            saveQR(path, bm);
        }

        public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

    }
}


