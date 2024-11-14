using VerifactuQr.Interfaces;

namespace VerifactuQr
{

    public class Qr : IVerifactuQr
    {
        public Qr()
        {
            OpcionesQr = new OpcionesQr();
        }

        public OpcionesQr OpcionesQr { get; set; }

        public DatosQr DatosQr { get; set; }
    }

}
