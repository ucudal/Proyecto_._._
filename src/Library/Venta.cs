using System;

namespace Library
{
    /// <summary>
    /// Representa una venta realizada dentro del sistema.
    /// Hereda de Interaccion porque comparte algunos datos (fecha, descripcion, notas).
    /// </summary>
    public class Venta : Interaccion
    {
        /// <summary>
        /// Monto total de la venta.
        /// </summary>
        public double Total { get; private set; }

        /// <summary>
        /// Cotización desde la cual se originó la venta.
        /// </summary>
        public Cotizacion CotizacionOrigen { get; private set; }

        /// <summary>
        /// Constructor que recibe todos los datos necesarios para crear la venta.
        /// </summary>
        public Venta(double total, DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            this.Total = total;
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Venta() : base()
        {
            // Este constructor existe solo por si se necesita crear una venta vacía.
        }

        /// <summary>
        /// Asigna una cotización como origen de la venta.
        /// </summary>
        /// <param name="cotizacion">Cotización desde la cual se generó la venta.</param>
        public void AsignarCotizacion(Cotizacion cotizacion)
        {
            this.CotizacionOrigen = cotizacion;
        }

        /// <summary>
        /// Devuelve el total de la venta.
        /// </summary>
        public double GetTotales(string criterio1, string criterio2)
        {
            return this.Total;
        }
    }
}