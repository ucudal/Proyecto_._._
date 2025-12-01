using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace ProyectoCRM
{
    /// <summary>
    /// Servicio para filtrar y consultar ventas.
    /// No almacena ventas internamente; recibe la lista desde afuera.
    /// </summary>
    public class RegistroVenta
    {
        /// <summary>
        /// Lista interna opcional para almacenamiento temporal.
        /// </summary>
        private readonly List<Venta> ventas;

        /// <summary>
        /// Constructor opcional: inicializa la lista interna vacía.
        /// </summary>
        public RegistroVenta()
        {
            ventas = new List<Venta>();
        }

        /// <summary>
        /// Agrega una venta a la lista interna (si se desea mantener un historial local).
        /// </summary>
        /// <param name="venta">Venta a agregar.</param>
        public void AgregarVenta(Venta venta)
        {
            if (venta == null) throw new ArgumentNullException(nameof(venta));
            ventas.Add(venta);
        }

        /// <summary>
        /// Obtiene las ventas dentro de un rango de fechas a partir de una lista dada.
        /// </summary>
        /// <param name="listaVentas">Lista de ventas a filtrar.</param>
        /// <param name="desde">Fecha de inicio.</param>
        /// <param name="hasta">Fecha de fin.</param>
        /// <returns>Lista de ventas filtradas.</returns>
        public List<Venta> GetVentasEntre(IEnumerable<Venta> listaVentas, DateTime desde, DateTime hasta)
        {
            if (listaVentas == null) throw new ArgumentNullException(nameof(listaVentas));

            return listaVentas
                .Where(v => v.Fecha >= desde && v.Fecha <= hasta)
                .ToList();
        }

        /// <summary>
        /// Obtiene todas las ventas registradas en la lista interna.
        /// </summary>
        /// <returns>Lista de ventas internas.</returns>
        public List<Venta> ObtenerTodas() => new List<Venta>(ventas);
    }
}
