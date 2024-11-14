using QRCoder;

namespace VerifactuQr.Interfaces
{
    // Interfaces y clases para generar QR en diferentes formatos
    public interface IQrGenerador
    {
        byte[] GetGraphicBytes(QRCodeData qrCodeData, int pixelsPerModule);
    }

}
