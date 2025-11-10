using System;

namespace Library
{
    public class Venta : Interaccion
    {
        public double Total { get; private set; }

        public Venta(double total, DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            Total = total;
        }

        public Venta() : base() { }

        public double GetTotales(string criterio1, string criterio2)
        {
            // Por ahora, solo devuelve el total. 
            // Podés agregar lógica filtrando por criterio si lo necesitás más adelante.
            return Total;
        }
    }
}