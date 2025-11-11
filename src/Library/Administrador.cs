using System;

namespace Library
{
    /// <summary>
    /// Representa un administrador dentro del sistema.
    /// Implementa la interfaz <see cref="IUsuario"/> y permite gestionar usuarios
    /// (crearlos, suspenderlos, eliminarlos y mostrarlos) mediante el <see cref="GestorUsuarios"/>.
    /// </summary>
    public class Administrador : IUsuario
    {
        /// <summary>
        /// Identificador único del administrador.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Indica si el administrador está activo.
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Fecha en que se creó el administrador.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Constructor de la clase <see cref="Administrador"/>.
        /// </summary>
        /// <param name="activo">Estado de actividad del administrador.</param>
        /// <param name="fechaCreacion">Fecha de creación del administrador.</param>
        public Administrador(bool activo, DateTime fechaCreacion)
        {
            Activo = activo;
            FechaCreacion = fechaCreacion;
            Id = 0; // se puede asignar luego desde GestorUsuarios si se desea
        }

        /// <summary>
        /// Crea un nuevo usuario activo y lo agrega al <see cref="GestorUsuarios"/>.
        /// </summary>
        /// <param name="nombre">Nombre del nuevo usuario.</param>
        /// <param name="apellido">Apellido del nuevo usuario.</param>
        /// <param name="email">Correo electrónico del nuevo usuario.</param>
        /// <returns>El usuario recién creado.</returns>
        public Usuario CrearUsuario(string nombre, string apellido, string email)
        {
            // Por ahora, ignoramos nombre/apellido/email (como en tu comentario)
            int nuevoId = GestorUsuarios.Instancia.AgregarUsuario(true, DateTime.Now);
            Usuario nuevo = GestorUsuarios.Instancia.ObtenerUsuario(nuevoId);

            Console.WriteLine($"Usuario creado con ID {nuevo.Id}.");
            return nuevo;
        }

        /// <summary>
        /// Suspende un usuario existente estableciendo su estado como inactivo.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a suspender.</param>
        public void SuspenderUsuario(int idUsuario)
        {
            Usuario usuario = GestorUsuarios.Instancia.ObtenerUsuario(idUsuario);

            if (usuario != null)
            {
                usuario.Activo = false;
                Console.WriteLine($"Usuario {idUsuario} suspendido.");
            }
            else
            {
                Console.WriteLine($"No se encontró el usuario con ID {idUsuario}.");
            }
        }

        /// <summary>
        /// Elimina un usuario del sistema utilizando el <see cref="GestorUsuarios"/>.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a eliminar.</param>
        public void EliminarUsuario(int idUsuario)
        {
            bool eliminado = GestorUsuarios.Instancia.EliminarUsuario(idUsuario);

            if (eliminado)
                Console.WriteLine($"Usuario {idUsuario} eliminado correctamente.");
            else
                Console.WriteLine($"No se pudo eliminar: usuario {idUsuario} no encontrado.");
        }

        /// <summary>
        /// Muestra en consola todos los usuarios gestionados por el <see cref="GestorUsuarios"/>.
        /// </summary>
        public void MostrarUsuarios()
        {
            GestorUsuarios.Instancia.MostrarTodosUsuarios();
        }
    }
}
