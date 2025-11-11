using System;

namespace Library
{
    /// <summary>
    /// Representa una cotización asociada a un cliente o interacción.
    /// Hereda de Interaccion.
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
        /// Constructor que inicializa todos los campos de la cotización.
        /// </summary>
        /// <param name="estado">Estado de la cotización.</param>
        /// <param name="fechaEnvio">Fecha de envío de la cotización.</param>
        /// <param name="importeTotal">Importe total de la cotización.</param>
        /// <param name="fecha">Fecha de la interacción.</param>
        /// <param name="descripcion">Descripción de la interacción.</param>
        /// <param name="notas">Notas adicionales de la interacción.</param>
        /// <param name="respondida">Indica si la interacción fue respondida.</param>
        /// <param name="direccion">Dirección asociada a la interacción.</param>
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

        /// <summary>
        /// Constructor vacío para crear una cotización sin inicializar valores.
        /// </summary>
        public Cotizacion() : base() { }
    }
}
