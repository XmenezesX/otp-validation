using QRCoder;

namespace OTPValidation.Core.Shared.Domain.Services.QrCodeGenerator
{
    public sealed class QrCodeGeneratorService : IQrCodeGeneratorService
    {
        public byte[] Generate(string information)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(information, QRCodeGenerator.ECCLevel.Q);
            var pngByteQrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = pngByteQrCode.GetGraphic(5);
            return qrCodeBytes;
        }
    }
}
