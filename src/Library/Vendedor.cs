using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Representa un vendedor del sistema, implementando la interfaz <see cref="IUsuario"/>.
    /// Contiene información sobre el estado del vendedor y la fecha de creación.
    /// </summary>
    public class Vendedor : IUsuario
    {
        /// <summary>
        /// Indica si el vendedor está activo o inactivo.
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Fecha en la que el vendedor fue creado o registrado en el sistema.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Constructor de la clase <see cref="Vendedor"/> que inicializa el estado y la fecha de creación.
        /// </summary>
        /// <param name="activo">Estado inicial del vendedor.</param>
        /// <param name="fechaCreacion">Fecha de creación del vendedor.</param>
        public Vendedor(bool activo, DateTime fechaCreacion)
        {
            Activo = activo;
            FechaCreacion = fechaCreacion;
        }

        /// <summary>
        /// Obtiene la lista de clientes asignados al vendedor.
        /// </summary>
        /// <returns>Una lista de clientes asignados. Actualmente retorna una lista vacía.</returns>
        public List<Cliente> getClientesAsignados()
        {
            return new List<Cliente>();
        }
    }
}