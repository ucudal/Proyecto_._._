using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que representa un registro de ventas del sistema.
    /// Permite almacenar y consultar ventas en un rango de fechas.
    /// </summary>
    public class RegistroVenta
    {
        /// <summary>
        /// Lista que almacena todas las ventas registradas.
        /// </summary>
        private List<Venta> ventas;

        /// <summary>
        /// Constructor que inicializa el registro de ventas.
        /// </summary>
        /// <param name="ventas">Lista de ventas existente; si es null se crea una nueva lista vacía.</param>
        public RegistroVenta(List<Venta> ventas)
        {
            this.ventas = ventas ?? new List<Venta>();
        }

        /// <summary>
        /// Agrega una venta al registro.
        /// </summary>
        /// <param name="venta">Venta a registrar.</param>
        public void AgregarVenta(Venta venta)
        {
            if (venta != null)
            {
                this.ventas.Add(venta);
            }
        }

        /// <summary>
        /// Obtiene todas las ventas registradas dentro de un rango de fechas.
        /// </summary>
        /// <param name="desde">Fecha de inicio del rango (inclusive).</param>
        /// <param name="hasta">Fecha de fin del rango (inclusive).</param>
        /// <returns>Lista de ventas cuyo valor de fecha está dentro del rango especificado.</returns>
        public List<Venta> getVentasEntre(DateTime desde, DateTime hasta)
        {
            List<Venta> resultado = new List<Venta>();

            foreach (Venta v in this.ventas)
            {
                if (v.Fecha >= desde && v.Fecha <= hasta)
                {
                    resultado.Add(v);
                }
            }

            return resultado;
        }
    }
}