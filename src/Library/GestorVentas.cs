//Agrege un Gestor de Ventas. La verdad que me facilito la vida para estar mas organizado al tener un
//propio gestor, ademas que no fue tan dificil de implementar. Es mi centro logico para contar las ventas ya que es responsabilidad de "Ventas".

// El metodo ObtenerVendedorConMasVentas devuelve un tuple (Vendedor, int cantidad) para ser los testing

using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace ProyectoCRM
{
    public class GestorVentas
    {
        //coleccion/lista de ventas.
        private readonly List<Venta> ventas;

        public GestorVentas(List<Venta> ventas = null)
        {
            this.ventas = ventas ?? new List<Venta>();
        }

        public void AgregarVenta(Venta v) => ventas.Add(v);

        public IReadOnlyList<Venta> ObtenerTodasLasVentas() => ventas.AsReadOnly();

        // Retorna diccionario vendedorId----cantidadVentas
        public Dictionary<object, int> ObtenerCantidadVentasPorVendedor()
        {
            // Si Venta almacena VendedorId:
            return ventas
                .GroupBy(v => v.Vendedorid)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // Retorna id del vendedor con mas ventas y la cantidad. Si no hay ventas, retorna (0,0) o null.
        public (int VendedorId, int Cantidad) ObtenerVendedorConMasVentas()
        {
            var dict = ObtenerCantidadVentasPorVendedor();
            if (dict.Count == 0) return (0, 0);
            
            // En caso donde se de un empate, se devuelve el primero por orden de aparición. Osea el primero...
            
            var max = dict.OrderByDescending(kv => kv.Value).First();
            return ((int VendedorId, int Cantidad))(max.Key, max.Value);//Devuelve el primero 
        }
    }
}