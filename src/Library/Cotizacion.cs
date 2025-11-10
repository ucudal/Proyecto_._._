using System;

namespace Library
{
    public class Cotizacion : Interaccion
    {
        public string Estado { get; private set; }
        public DateTime FechaEnvio { get; private set; }
        public double ImporteTotal { get; private set; }

        public Cotizacion(
            string estado,
            DateTime fechaEnvio,
            double importeTotal,
            DateTime fecha,
            string descripcion,
            string notas,
            bool respondida,
            string direccion
        ) : base(fecha, descripcion, notas, respondida, direccion)
        {
            Estado = estado;
            FechaEnvio = fechaEnvio;
            ImporteTotal = importeTotal;
        }

        public Cotizacion() : base() { }
    }
}