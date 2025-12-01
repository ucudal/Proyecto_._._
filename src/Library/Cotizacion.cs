using System;

namespace Library
{
    /// <summary>
    /// Representa una cotización realizada en el sistema.
    /// Hereda de Interaccion porque comparte los datos básicos (fecha, descripcion, notas, etc.).
    /// </summary>
    public class Cotizacion : Interaccion
    {
        /// <summary>
        /// Estado de la cotización (por ejemplo: Pendiente, Aceptada, Rechazada).
        /// </summary>
        public string Estado { get; private set; }

        /// <summary>
        /// Fecha en que se envió la cotización.
        /// </summary>
        public DateTime FechaEnvio { get; private set; }

        /// <summary>
        /// Importe total de la cotización.
        /// </summary>
        public double ImporteTotal { get; private set; }

        /// <summary>
        /// Constructor que permite crear una cotización con todos los datos necesarios.
        /// </summary>
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
            this.Estado = estado;
            this.FechaEnvio = fechaEnvio;
            this.ImporteTotal = importeTotal;
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Cotizacion() : base()
        {
            // Este constructor deja los valores por defecto.
        }
    }
}