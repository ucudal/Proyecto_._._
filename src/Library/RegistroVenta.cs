using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace ProyectoCRM
{
    /// <summary>
    /// Servicio para filtrar y consultar ventas.
    /// Puede operar sobre una lista externa (proporcionada) o mantener una lista interna.
    /// </summary>
    public class RegistroVenta
    {
        /// <summary>
        /// Lista interna opcional para almacenamiento temporal. Puede ser null si se desea solo operar con listas externas.
        /// </summary>
        private readonly List<Venta> ventas;

        /// <summary>
        /// Crea una instancia de RegistroVenta sin almacenamiento interno.
        /// </summary>
        public RegistroVenta()
        {
            this.ventas = new List<Venta>();
        }

        /// <summary>
        /// Crea una instancia de RegistroVenta con una lista inicial opcional.
        /// </summary>
        /// <param name="ventasIniciales">Lista inicial de ventas (puede ser null).</param>
        public RegistroVenta(IEnumerable<Venta> ventasIniciales)
        {
            this.ventas = ventasIniciales != null ? new List<Venta>(ventasIniciales) : new List<Venta>();
        }

        /// <summary>
        /// Registra una venta en la lista interna.
        /// </summary>
        /// <param name="venta">Venta a registrar.</param>
        public void RegistrarVentaInterna(Venta venta)
        {
            if (venta == null) throw new ArgumentNullException(nameof(venta));
            if (!ventas.Contains(venta))
            {
                ventas.Add(venta);
            }
        }

        /// <summary>
        /// Busca ventas dentro de una lista proporcionada entre dos fechas (inclusive).
        /// </summary>
        /// <param name="listaVentas">Lista de ventas donde buscar. No puede ser null.</param>
        /// <param name="desde">Fecha desde (inclusive).</param>
        /// <param name="hasta">Fecha hasta (inclusive).</param>
        /// <returns>Lista de ventas que cumplen el criterio.</returns>
        public List<Venta> BuscarPorRango(IEnumerable<Venta> listaVentas, DateTime desde, DateTime hasta)
        {
            if (listaVentas == null) throw new ArgumentNullException(nameof(listaVentas));
            if (desde > hasta) throw new ArgumentException("La fecha 'desde' no puede ser posterior a 'hasta'.");

            return listaVentas
                .Where(v => v != null && v.Fecha >= desde && v.Fecha <= hasta)
                .ToList();
        }

        /// <summary>
        /// Busca ventas en la lista interna entre dos fechas (inclusive).
        /// </summary>
        /// <param name="desde">Fecha desde (inclusive).</param>
        /// <param name="hasta">Fecha hasta (inclusive).</param>
        /// <returns>Lista de ventas internas que cumplen el criterio.</returns>
        public List<Venta> BuscarEnInternasPorRango(DateTime desde, DateTime hasta)
        {
            return BuscarPorRango(this.ventas, desde, hasta);
        }

        /// <summary>
        /// Obtiene todas las ventas registradas en la lista interna.
        /// </summary>
        /// <returns>Lista de ventas internas (copia).</returns>
        public List<Venta> ObtenerTodas()
        {
            return new List<Venta>(ventas);
        }
    }
}
