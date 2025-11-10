using System;
using System.Collections.Generic;

namespace Library
{
    // Clase que representa un registro de ventas
    public class RegistroVenta
    {
        // Lista que almacena todas las ventas registradas
        private List<Venta> ventas;

        // Constructor: recibe una lista de ventas o crea una nueva si es null
        public RegistroVenta(List<Venta> ventas)
        {
            this.ventas = ventas ?? new List<Venta>();
        }

        // Método que devuelve una lista de ventas entre dos fechas dadas (inclusive)
        public List<Venta> getVentasEntre(DateTime desde, DateTime hasta)
        {
            List<Venta> resultado = new List<Venta>();

            // Recorre todas las ventas registradas
            foreach (var v in ventas)
            {
                // Agrega la venta si su fecha está dentro del rango indicado
                if (v.Fecha >= desde && v.Fecha <= hasta)
                {
                    resultado.Add(v);
                }
            }

            // Devuelve la lista de ventas filtradas
            return resultado;
        }
    }
}