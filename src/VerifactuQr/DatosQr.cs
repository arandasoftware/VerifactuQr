using System;

namespace VerifactuQr
{
    public class DatosQr
    {
        /// <summary>
        /// NIF del obligado a expedir la factura
        /// </summary>
        public string Nif { get; set; }

        /// <summary>
        /// Nº Serie que identifica a la factura
        /// </summary>
        public string NumeroSerie { get; set; }

        /// <summary>
        /// Nº Factura que identifica a la factura
        /// </summary>
        public string NumeroFactura { get; set; }

        /// <summary>
        /// Fecha de expedición de la factura
        /// </summary>
        public DateTime FechaFactura { get; set; }

        /// <summary>
        /// Importe total de la factura
        /// </summary>
        public decimal Importe { get; set; }
    }

}
