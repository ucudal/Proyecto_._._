using System;

namespace Library
{
    public class Administrador : IUsuario
    {
        // Implementación de IUsuario
        public int Id { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Constructor
        public Administrador(bool activo, DateTime fechaCreacion)
        {
            Activo = activo;
            FechaCreacion = fechaCreacion;
            Id = 0; // se puede asignar luego desde GestorUsuarios si se desea
        }

        // Crea un nuevo usuario y lo agrega al GestorUsuarios
        public Usuario CrearUsuario(string nombre, string apellido, string email)
        {
            // Por ahora, ignoramos nombre/apellido/email (como en tu comentario)
            int nuevoId = GestorUsuarios.Instancia.AgregarUsuario(true, DateTime.Now);
            Usuario nuevo = GestorUsuarios.Instancia.ObtenerUsuario(nuevoId);

            Console.WriteLine($"Usuario creado con ID {nuevo.Id}.");
            return nuevo;
        }

        // Suspende un usuario existente (usa GestorUsuarios)
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

        // Elimina un usuario del sistema (usa GestorUsuarios)
        public void EliminarUsuario(int idUsuario)
        {
            bool eliminado = GestorUsuarios.Instancia.EliminarUsuario(idUsuario);

            if (eliminado)
                Console.WriteLine($"Usuario {idUsuario} eliminado correctamente.");
            else
                Console.WriteLine($"No se pudo eliminar: usuario {idUsuario} no encontrado.");
        }

        // Mostrar todos los usuarios (solo para control)
        public void MostrarUsuarios()
        {
            GestorUsuarios.Instancia.MostrarTodosUsuarios();
        }
    }
}
