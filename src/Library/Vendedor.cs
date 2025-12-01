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
        /// Constructor del vendedor.
        /// </summary>
        /// <param name="activo">Estado inicial del vendedor.</param>
        /// <param name="fechaCreacion">Fecha de creación.</param>
        public Vendedor(bool activo, DateTime fechaCreacion)
            : base(activo, fechaCreacion) { }

        /// <summary>
        /// Obtiene la lista de clientes asignados al vendedor.
        /// </summary>
        /// <returns>Lista de clientes asignados.</returns>
        public List<Cliente> getClientesAsignados()
        {
            return new List<Cliente>();
        }
    }
}