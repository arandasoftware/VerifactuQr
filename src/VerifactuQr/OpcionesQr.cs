namespace VerifactuQr
{
    public class OpcionesQr
    {
        public OpcionesQr()
        {
            Tamanio = TamanioQr.Pequeno;
            EmiteFacturaVerificable = true;
            Test = false;
        }

        public TamanioQr Tamanio { get; set; }
        public bool Test { get; set; }
        public bool EmiteFacturaVerificable { get; set; }
    }

}
