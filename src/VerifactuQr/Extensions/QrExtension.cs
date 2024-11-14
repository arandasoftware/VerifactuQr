using System.Drawing;
using System.IO;
using QRCoder;
using VerifactuQr.Factory;
using VerifactuQr.Interfaces;

namespace VerifactuQr.Extensions
{
    public static class QrExtension
    {
        public enum QrFormato { Bitmap, Png }

        public static Bitmap ObtenerQrBitmap(this Qr qr, QrFormato format)
        {
            byte[] qrBytes = format == QrFormato.Bitmap
                ? qr.GenerateQrCodeBytes(new BitmapByteQRCodeFactory())
                : qr.GenerateQrCodeBytes(new PngByteQRCodeFactory());

            return ConvertBytesToBitmap(qrBytes);
        }

        private static byte[] GenerateQrCodeBytes(this Qr qr, IQrGenerador qrCodeGenerator)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                using (var qrCodeData = qrGenerator.CreateQrCode(qr.ObtenerUrl(), QRCodeGenerator.ECCLevel.M))
                {
                    int size = qr.OpcionesQr.Tamanio == TamanioQr.Pequeno
                        ? 20
                        : 30;

                    return qrCodeGenerator.GetGraphicBytes(qrCodeData, size);
                }
            }
        }

        private static Bitmap ConvertBytesToBitmap(byte[] qrBytes)
        {
            using (var ms = new MemoryStream(qrBytes))
            {
                return new Bitmap(ms);
            }
        }

        public static void ConfigurarQr(this Qr qr, OpcionesQr opciones) => qr.OpcionesQr = opciones;

    }

}
