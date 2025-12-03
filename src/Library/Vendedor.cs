using System;
using System.Collections.Generic;
using Library;

namespace Library
{
    /// <summary>
    /// Representa un vendedor del sistema.
    /// Los vendedores pueden tener clientes asignados.
    /// </summary>
    public class Vendedor : UsuarioBase
    {
        /// <summary>
        /// Lista de clientes asignados a este vendedor.
        /// </summary>
        private readonly List<Cliente> clientesAsignados = new List<Cliente>();
        
        private readonly List<Venta> cantidadVentas = new List<Venta>();

        public int NumVentas { get; set; }

        public int Bono { get; set;}
        
        /// <summary>
        /// Constructor del vendedor.
        /// </summary>
        /// <param name="activo">Estado inicial del vendedor.</param>
        /// <param name="fechaCreacion">Fecha de creación.</param>
        public Vendedor(bool activo, DateTime fechaCreacion)
            : base(activo, fechaCreacion) { }

        /// <summary>
        /// Obtiene la lista de clientes asignados al vendedor.
        /// Devuelve una copia de la lista para preservar encapsulación.
        /// </summary>
        /// <returns>Lista de clientes asignados.</returns>
        public List<Cliente> GetClientesAsignados()
        {
            return new List<Cliente>(clientesAsignados);
        }

        /// <summary>
        /// Asigna un cliente a este vendedor.
        /// </summary>
        /// <param name="cliente">Cliente a asignar.</param>
        /// <returns>True si se asignó; false si ya estaba asignado.</returns>
        public bool AsignarCliente(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            if (clientesAsignados.Contains(cliente)) return false;
            clientesAsignados.Add(cliente);
            return true;
        }

        /// <summary>
        /// Desasigna un cliente de este vendedor.
        /// </summary>
        /// <param name="cliente">Cliente a desasignar.</param>
        /// <returns>True si se desasignó; false si no estaba asignado.</returns>
        public bool DesasignarCliente(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            return clientesAsignados.Remove(cliente);
        }
        public void AgregarVenta(Venta venta)
        {
            if (venta != null)
            {
                cantidadVentas.Add(venta);
            }
        }
        
        // ---------------------------------------------------------------------
        // DEFENSA PROYECTO
        // ---------------------------------------------------------------------

        /// <summary>
        ///  Método creado para recibir la lista de ventas de cada vendedor en caso de necesitarla
        /// </summary>
        /// <returns></returns>
        public List<Venta> GetVentas()
        {
            return new List<Venta>(cantidadVentas);
        }

        /// <summary>
        /// Método que entrega la cantidad de ventas en tipo int para facilitar los métodos de la fachada
        /// </summary>
        /// <returns></returns>
        public int GetVentasInt()
        {
            foreach (var VARIABLE in cantidadVentas)
            {
                NumVentas += 1;
            }

            return NumVentas;
        }

        /// <summary>
        /// Método que permite a la Fachada entregarle el bono al vendedor con mayor cantidad de ventas, recorre la lista de ventas y por cada una de ellas le entrega el bono de 100
        /// </summary>
        public void RecibirBono()
        {
            foreach (var VARIABLE in cantidadVentas)
            {
                Bono += 100;
            }
        }
        
        /// <summary>
        /// Metodo que retorna el valor del Bono del vendedor
        /// </summary>
        /// <returns></returns>

        public int GetBono()
        {
            return Bono;
        }
    }
}
