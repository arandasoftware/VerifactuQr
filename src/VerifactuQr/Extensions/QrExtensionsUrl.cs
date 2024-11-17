using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Web;

namespace VerifactuQr.Extensions
{
    public static class QrExtensionsUrl
    {
        private const string RAIZ_HTTP_PRODUCCION = "https://www2.agenciatributaria.gob.es";
        private const string RAIZ_HTTP_PRUEBAS = "https://prewww2.aeat.es";
        private const string QR_NO_VERIFATU = "ValidarQRNoVerifactu?";
        private const string QR_VERIFATU = "ValidarQR?";

        public static string ObtenerUrl(this Qr qr)
        {
            string urlBase = ConstruirUrlBase(qr.OpcionesQr.Test, qr.OpcionesQr.EmiteFacturaVerificable);
            var uriBuilder = new UriBuilder(urlBase);

            // Crear la colección de parámetros
            var query = ConstruirParametros(qr);
            uriBuilder.Query = query.ToString();

            return uriBuilder.ToString();
        }

        private static string ConstruirUrlBase(bool isTest, bool emiteFacturaVerificable)
        {
            string raizHttp = isTest ? RAIZ_HTTP_PRUEBAS : RAIZ_HTTP_PRODUCCION;
            string endpoint = emiteFacturaVerificable ? QR_VERIFATU : QR_NO_VERIFATU;

            return $"{raizHttp}/wlpl/TIKE-CONT/{endpoint}";
        }

        private static NameValueCollection ConstruirParametros(Qr qr)
        {
            var query = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
            query["nif"] = qr.DatosQr.Nif;
            query["numserie"] = $"{qr.DatosQr.NumeroFactura}&{qr.DatosQr.NumeroSerie}";
            query["fecha"] = qr.DatosQr.FechaFactura.ToString("dd-MM-yyyy");
            query["importe"] = qr.DatosQr.Importe.ToString("N2", CultureInfo.InvariantCulture);

            return query;
        }
    }

}
