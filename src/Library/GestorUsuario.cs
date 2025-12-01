using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase encargada de gestionar las operaciones relacionadas con los usuarios del sistema.
    /// Implementa el patrón Singleton para asegurar que solo exista una instancia.
    /// </summary>
    public class GestorUsuarios
    {
        /// <summary>
        /// Instancia única del gestor (patrón Singleton).
        /// </summary>
        private static GestorUsuarios instancia;

        /// <summary>
        /// Propiedad pública para acceder a la instancia única del gestor.
        /// Si no existe, la crea automáticamente.
        /// </summary>
        public static GestorUsuarios Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GestorUsuarios();
                }
                return instancia;
            }
        }

        /// <summary>
        /// Constructor privado para evitar la creación de instancias fuera de la clase.
        /// </summary>
        private GestorUsuarios()
        {
        }

        /// <summary>
        /// Lista interna que actúa como base de datos de usuarios.
        /// </summary>
        private readonly List<Usuario> usuarios = new List<Usuario>();

        /// <summary>
        /// Contador utilizado para asignar IDs automáticos a los usuarios nuevos.
        /// </summary>
        private int proximoId = 1;

        /// <summary>
        /// Agrega un nuevo usuario al sistema.
        /// </summary>
        /// <param name="activo">Indica si el usuario está activo.</param>
        /// <param name="fechaCreacion">Fecha en la que se crea el usuario.</param>
        /// <returns>El ID asignado al nuevo usuario.</returns>
        public int AgregarUsuario(bool activo, DateTime fechaCreacion)
        {
            Usuario nuevo = new Usuario(activo, fechaCreacion)
            {
                Id = this.proximoId
            };

            this.usuarios.Add(nuevo);
            this.proximoId++;
            return nuevo.Id;
        }

        /// <summary>
        /// Obtiene un usuario a partir de su ID.
        /// </summary>
        /// <param name="id">Identificador único del usuario.</param>
        /// <returns>El objeto Usuario si se encuentra; de lo contrario, null.</returns>
        public Usuario ObtenerUsuario(int id)
        {
            foreach (Usuario usuario in this.usuarios)
            {
                if (usuario.Id == id)
                {
                    return usuario;
                }
            }
            return null;
        }

        /// <summary>
        /// Muestra todos los usuarios registrados en la consola.
        /// Este método se puede usar para pruebas simples en la capa de presentación.
        /// </summary>
        public void MostrarTodosUsuarios()
        {
            foreach (Usuario usuario in this.usuarios)
            {
                Console.WriteLine(
                    $"ID: {usuario.Id}, Activo: {(usuario.Activo ? "Sí" : "No")}, FechaCreacion: {usuario.FechaCreacion.ToShortDateString()}"
                );
            }
        }

        /// <summary>
        /// Actualiza el estado de actividad de un usuario.
        /// </summary>
        /// <param name="id">Identificador del usuario.</param>
        /// <param name="nuevoActivo">Nuevo valor de estado (activo/inactivo).</param>
        /// <returns>True si se actualizó correctamente; false si no se encontró el usuario.</returns>
        public bool ActualizarActivo(int id, bool nuevoActivo)
        {
            Usuario usuario = this.ObtenerUsuario(id);
            if (usuario != null)
            {
                usuario.Activo = nuevoActivo;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Elimina un usuario de la lista a partir de su ID.
        /// </summary>
        /// <param name="id">Identificador del usuario a eliminar.</param>
        /// <returns>True si se eliminó correctamente; false si no se encontró el usuario.</returns>
        public bool EliminarUsuario(int id)
        {
            Usuario usuario = this.ObtenerUsuario(id);
            if (usuario != null)
            {
                this.usuarios.Remove(usuario);
                return true;
            }
            return false;
        }
    }
}
