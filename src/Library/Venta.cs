using System;

namespace Library
{
    /// <summary>
    /// Representa una venta realizada, heredando de la clase <see cref="Interaccion"/>.
    /// Contiene información sobre el total de la venta, fecha, descripción, notas, estado de respuesta y dirección.
    /// </summary>
    public class Venta : Interaccion
    {
        /// <summary>
        /// Monto total de la venta.
        /// </summary>
        public double Total { get; private set; }

        /// <summary>
        /// Cotización origen que generó esta venta (si aplica).
        /// </summary>
        public Cotizacion CotizacionOrigen { get; private set; }

        /// <summary>
        /// Constructor principal de una Venta.
        /// </summary>
        public Venta(
            double total,
            DateTime fecha,
            string descripcion,
            string notas,
            bool respondida,
            string direccion,
            Cotizacion cotizacionOrigen = null
        ) : base(fecha, descripcion, notas, respondida, direccion)
        {
            Total = total;
            CotizacionOrigen = cotizacionOrigen;

            // Si viene de una cotización, registramos relación bidireccional
            cotizacionOrigen?.RegistrarVentaAsociada(this);
        }

        /// <summary>
        /// Asocia una cotización a esta venta (si se creó sin una).
        /// </summary>
        public void AsociarCotizacion(Cotizacion cotizacion)
        {
            CotizacionOrigen = cotizacion;

            cotizacion?.RegistrarVentaAsociada(this);
        }

        /// <summary>
        /// Obtiene el total de la venta.
        /// </summary>
        public double GetTotales(string criterio1, string criterio2)
        {
            return Total;
        }
    }
}