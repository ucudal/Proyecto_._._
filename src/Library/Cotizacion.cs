using System;
using System.Collections.Generic;

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
        /// Importe total cotizado.
        /// </summary>
        public double ImporteTotal { get; private set; }

        /// <summary>
        /// Ventas generadas a partir de esta cotización.
        /// </summary>
        public List<Venta> VentasGeneradas { get; private set; } = new List<Venta>();

        /// <summary>
        /// Constructor principal de Cotizacion.
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
            Estado = estado;
            FechaEnvio = fechaEnvio;
            ImporteTotal = importeTotal;
        }

        /// <summary>
        /// Constructor vacío para crear una cotización sin inicializar valores.
        /// </summary>
        public Cotizacion() : base() { }

        /// <summary>
        /// Registra una venta asociada a esta cotización.
        /// </summary>
        public void RegistrarVentaAsociada(Venta venta)
        {
            if (venta != null && !VentasGeneradas.Contains(venta))
            {
                VentasGeneradas.Add(venta);
            }
        }
    }
}
