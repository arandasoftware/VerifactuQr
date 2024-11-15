using QRCoder;
using VerifactuQr.Interfaces;

namespace VerifactuQr.Factory
{
    public class PngByteQRCodeFactory : IQrGenerador
    {
        public byte[] GetGraphicBytes(QRCodeData qrCodeData, int pixelsPerModule)
        {
            using (var qrCode = new PngByteQRCode(qrCodeData))
            {
                return qrCode.GetGraphic(pixelsPerModule);
            }
        }
    }

}
