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
        /// Constructor principal de <see cref="Venta"/> que inicializa todos los campos.
        /// </summary>
        /// <param name="total">Monto total de la venta.</param>
        /// <param name="fecha">Fecha de la venta.</param>
        /// <param name="descripcion">Descripción de la venta.</param>
        /// <param name="notas">Notas adicionales sobre la venta.</param>
        /// <param name="respondida">Indica si la venta fue respondida/confirmada.</param>
        /// <param name="direccion">Dirección asociada a la venta (ej. sucursal o cliente).</param>
        public Venta(double total, DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            Total = total;
        }

        /// <summary>
        /// Constructor por defecto de <see cref="Venta"/>.
        /// </summary>
        public Venta() : base() { }

        /// <summary>
        /// Obtiene el total de la venta.
        /// </summary>
        /// <param name="criterio1">Criterio opcional para filtrar (no implementado actualmente).</param>
        /// <param name="criterio2">Criterio opcional para filtrar (no implementado actualmente).</param>
        /// <returns>Devuelve el total de la venta.</returns>
        public double GetTotales(string criterio1, string criterio2)
        {
            // Por ahora, solo devuelve el total. 
            // Podés agregar lógica filtrando por criterio si lo necesitás más adelante.
            return Total;
        }
    }
    
}
