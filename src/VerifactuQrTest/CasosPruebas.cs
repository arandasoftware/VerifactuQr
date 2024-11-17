using System.Drawing;
using System.Drawing.Imaging;
using VerifactuQr;
using VerifactuQr.Extensions;

namespace VerifactuQrTest
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validar la compatibilidad de la plataforma", Justification = "Solo para plataformas Windows")]
    public class CasosPruebas
    {
        [Fact]
        public void Valida_OpcionesQr_PorDefecto()
        {
            OpcionesQr opciones = new();

            Assert.False(opciones.Test);
            Assert.True(opciones.EmiteFacturaVerificable);
            Assert.Equal(TamanioQr.Pequeno, opciones.Tamanio);
        }

        [Fact]
        public void ExtensionConfigurarQr_EstableceOpciones()
        {
            Qr qr = new();

            qr.ConfigurarQr(QrVerificablePruebas);

            Assert.True(qr.OpcionesQr.Test);
            Assert.True(qr.OpcionesQr.EmiteFacturaVerificable);
            Assert.Equal(TamanioQr.Pequeno, qr.OpcionesQr.Tamanio);
        }

        [Fact]
        public void Generar_UrlValida_QrVerificable_EntornoTest()
        {
            Qr qr = new();
            qr.ConfigurarQr(QrVerificablePruebas);
            qr.DatosQr = ObtenerDatosQr();
            string urlTest = qr.ObtenerUrl();

            Assert.Equal("https://prewww2.aeat.es:443/wlpl/TIKE-CONT/ValidarQR?nif=89890001K&numserie=12345678%26G33&fecha=01-01-2024&importe=241.40", urlTest);
        }

        [Fact]
        public void Generar_UrlValida_QrVerificable_EntornoProduccion()
        {
            Qr qr = new();
            qr.ConfigurarQr(QrVerificable);
            qr.DatosQr = ObtenerDatosQr();
            string urlTest = qr.ObtenerUrl();

            Assert.Equal("https://www2.agenciatributaria.gob.es:443/wlpl/TIKE-CONT/ValidarQR?nif=89890001K&numserie=12345678%26G33&fecha=01-01-2024&importe=241.40", urlTest);
        }

        [Fact]
        public void Generar_UrlValida_QrNoVerificable_EntornoTest()
        {
            Qr qr = new();
            qr.ConfigurarQr(QrNoVerificablePruebas);
            qr.DatosQr = ObtenerDatosQr();
            string urlTest = qr.ObtenerUrl();

            Assert.Equal("https://prewww2.aeat.es:443/wlpl/TIKE-CONT/ValidarQRNoVerifactu?nif=89890001K&numserie=12345678%26G33&fecha=01-01-2024&importe=241.40", urlTest);
        }

        [Fact]
        public void Generar_UrlValida_QrNoVerificable_EntornoProduccion()
        {
            Qr qr = new();
            qr.ConfigurarQr(QrNoVerificable);
            qr.DatosQr = ObtenerDatosQr();
            string urlTest = qr.ObtenerUrl();

            Assert.Equal("https://www2.agenciatributaria.gob.es:443/wlpl/TIKE-CONT/ValidarQRNoVerifactu?nif=89890001K&numserie=12345678%26G33&fecha=01-01-2024&importe=241.40", urlTest);
        }

        [Fact]
        public void ObtenerQrBitmap_RetornoBitmapValido_ParaBmp()
        {
            Qr qr = new();
            qr.ConfigurarQr(QrNoVerificable);
            qr.DatosQr = ObtenerDatosQr();

            Bitmap qrBitmap = qr.ObtenerQrBitmap(QrExtension.QrFormato.Bitmap);

            Assert.NotNull(qrBitmap);
            Assert.IsType<Bitmap>(qrBitmap);
            Assert.True(qrBitmap.RawFormat.Equals(ImageFormat.Bmp), "RawFormat incorrecto");

            // Validar propiedades del Bitmap
            Assert.True(PixelFormat.Format24bppRgb == qrBitmap.PixelFormat, "PixelFormat incorrecto");
            Assert.True(qrBitmap.Width > 0 && qrBitmap.Height > 0, "La imagen generada debe tener dimensiones válidas.");

            int expectedSize = 20 * 57;
            Assert.True(qrBitmap.Width == expectedSize && qrBitmap.Height == expectedSize, "El tamaño del Bitmap no es el esperado para el QR generado.");
        }

        [Fact]
        public void ObtenerQrBitmap_RetornoBitmapValido_ParaPng()
        {
            Qr qr = new();

            qr.ConfigurarQr(QrNoVerificable);

            qr.DatosQr = ObtenerDatosQr();

            Bitmap qrBitmap = qr.ObtenerQrBitmap(QrExtension.QrFormato.Png);

            Assert.NotNull(qrBitmap);
            Assert.IsType<Bitmap>(qrBitmap);
            Assert.True(qrBitmap.RawFormat.Equals(ImageFormat.Png), "RawFormat incorrecto");

            // Validar propiedades del Png
            Assert.True(PixelFormat.Format1bppIndexed == qrBitmap.PixelFormat, "PixelFormat incorrecto");
            Assert.True(qrBitmap.Width > 0 && qrBitmap.Height > 0, "La imagen generada debe tener dimensiones válidas.");

            int expectedSize = 20 * 57;
            Assert.True(qrBitmap.Width == expectedSize && qrBitmap.Height == expectedSize, "El tamaño del Bitmap no es el esperado para el QR generado.");

        }

        private static OpcionesQr QrNoVerificable => new() { EmiteFacturaVerificable = false };
        private static OpcionesQr QrNoVerificablePruebas => new() { EmiteFacturaVerificable = false, Test = true };
        private static OpcionesQr QrVerificable => new();
        private static OpcionesQr QrVerificablePruebas => new() { Test = true };

        private static DatosQr ObtenerDatosQr() => new()
        {
            Nif = "89890001K",
            NumeroSerie = "G33",
            NumeroFactura = "12345678",
            FechaFactura = new DateTime(2024, 1, 1, 5, 10, 20, DateTimeKind.Local),
            Importe = 241.4M
        };
    }
}