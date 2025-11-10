using System;

namespace Library
{
    public class Cotizacion : Interaccion
    {
        private string estado;
        private DateTime fechaEnvio;
        private double importeTotal;

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
            this.estado = estado;
            this.fechaEnvio = fechaEnvio;
            this.importeTotal = importeTotal;
        }
    }
}