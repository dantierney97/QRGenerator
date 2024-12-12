using SkiaSharp;
using ZXing;
using ZXing.QrCode.Internal;

namespace QRGenerator.Services;

public class QrEncoder
{
    
    ErrorCorrectionLevel _errorLevel = ErrorCorrectionLevel.H;

    public SKBitmap GenerateQRCode(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentException("Input cannot be null or whitespace", nameof(content));
        }

        // Create a BarcodeWriter instance from ZXing
        var barcodeWriter = new BarcodeWriter<SKBitmap>
        {
            Format = BarcodeFormat.QR_CODE, // QR Code format
            Options = new ZXing.QrCode.QrCodeEncodingOptions
            {
                Width = 600, 
                Height = 600,
                ErrorCorrection = _errorLevel,
                PureBarcode = true
            }
        };

        // Generate the QR Code and return the SKBitmap
        return barcodeWriter.Write(content);
    }
}