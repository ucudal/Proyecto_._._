using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Constructor del vendedor
        /// </summary>
        /// <param name="activo">Estado inicial del vendedor.</param>
        /// <param name="fechaCreacion">Fecha de creación.</param>
        public Vendedor(bool activo, DateTime fechaCreacion)
            : base(activo, fechaCreacion) { }

        public Vendedor(bool BASE) : base(BASE)
        {
            throw new NotImplementedException();   //solicita el sistema para solucionar errores...
        }

        public Vendedor() : base()
        {
            throw new NotImplementedException();   //solicita el sistema para solucionar errores...
        }

        public string Nombre { get; set; }

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
    }
}
