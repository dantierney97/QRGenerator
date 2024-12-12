using ZXing;
using ZXing.Common;
using SkiaSharp;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace QRGenerator.Services
{
    public class QrEncoder
    {
        // Use a static readonly field for error correction level
        private static readonly ErrorCorrectionLevel errorCorrectionLevel = ErrorCorrectionLevel.H;

        public string GenerateQRCode(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Input cannot be null or whitespace", nameof(content));
            }

            // Create QRCodeWriter instance from ZXing
            var qrCodeWriter = new QRCodeWriter();

            // Set encoding options and apply the error correction level via Hints
            var encodingOptions = new QrCodeEncodingOptions()
            {
                Width = 177,  // Set the width of the QR Code
                Height = 177, // Set the height of the QR Code
                Margin = 10,  // Set margin around the QR code
                ErrorCorrection = errorCorrectionLevel,
            };

            // Generate the QR code as a BitMatrix (2D array)
            var bitMatrix = qrCodeWriter.encode(content, BarcodeFormat.QR_CODE, encodingOptions.Width,
                encodingOptions.Height, encodingOptions.Hints);

            // Convert BitMatrix to Base64 string
            return BitmapToBase64(bitMatrix);
        }

        // Helper method to convert BitMatrix to Base64 string using SkiaSharp
        private static string BitmapToBase64(BitMatrix bitMatrix)
        {
            int width = bitMatrix.Width;
            int height = bitMatrix.Height;

            using (var bitmap = new SKBitmap(width, height))
            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White); // Set background to white

                var paint = new SKPaint
                {
                    Color = SKColors.Black // Set the paint color to black for drawing modules
                };

                // Draw each module (square) in the matrix
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (bitMatrix[x, y]) // If the matrix value is true (black module)
                        {
                            canvas.DrawRect(x, y, 1, 1, paint); // Draw black square
                        }
                    }
                }

                // Convert the bitmap to Base64 string
                using (var ms = new System.IO.MemoryStream())
                {
                    // Save the image to the memory stream as PNG
                    bitmap.Encode(ms, SKEncodedImageFormat.Png, 100);
                    byte[] imageBytes = ms.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }
            }
        }
    }
}