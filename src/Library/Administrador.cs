using System;

namespace Library
{
    /// <summary>
    /// Representa un administrador del sistema.
    /// Puede crear y administrar usuarios.
    /// </summary>
    public class Administrador : UsuarioBase
    {
        public Administrador(bool activo, DateTime fechaCreacion)
            : base(activo, fechaCreacion) { }

        /// <summary>
        /// Solicita crear un nuevo vendedor.
        /// </summary>
        public Vendedor CrearVendedor()
        {
            return GestorUsuarios.Instancia.CrearVendedor(true, DateTime.Now);
        }

        /// <summary>
        /// Solicita crear otro administrador.
        /// </summary>
        public Administrador CrearAdministrador()
        {
            return GestorUsuarios.Instancia.CrearAdministrador(true, DateTime.Now);
        }

        /// <summary>
        /// Suspende a un usuario (Activa = false).
        /// </summary>
        /// <returns>true si la operación tuvo éxito.</returns>
        public bool SuspenderUsuario(int idUsuario)
        {
            return GestorUsuarios.Instancia.ActualizarActivo(idUsuario, false);
        }

        /// <summary>
        /// Elimina a un usuario del sistema.
        /// </summary>
        public bool EliminarUsuario(int idUsuario)
        {
            return GestorUsuarios.Instancia.EliminarUsuario(idUsuario);
        }

        /// <summary>
        /// Devuelve la lista de usuarios registrados en el sistema.
        /// </summary>
        public System.Collections.Generic.List<IUsuario> ObtenerUsuarios()
        {
            return GestorUsuarios.Instancia.ObtenerTodos();
        }
    }
}