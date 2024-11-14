using QRCoder;
using VerifactuQr.Interfaces;

namespace VerifactuQr.Factory
{
    public class BitmapByteQRCodeFactory : IQrGenerador
    {
        public byte[] GetGraphicBytes(QRCodeData qrCodeData, int pixelsPerModule)
        {
            using (var qrCode = new BitmapByteQRCode(qrCodeData))
            {
                return qrCode.GetGraphic(pixelsPerModule);
            }
        }
    }

}
