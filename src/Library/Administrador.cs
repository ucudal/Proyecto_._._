using System;
using System.Collections.Generic;

namespace Library
{
   
    public class Administrador : IUsuario
    {
        // Indica si el administrador está activo o no
        public bool Activo { get; set; }

        // Fecha en la que se creó 
        public DateTime FechaCreacion { get; set; }

        // Constructor: inicializa un Administrador con el estado y la fecha de creación dados
        public Administrador(bool activo, DateTime fechaCreacion)
        {
            Activo = activo;
            FechaCreacion = fechaCreacion;
        }
        
        // Crea un nuevo usuario con los datos dados.
        // Por ahora ignora nombre, apellido y email, y devuelve un Usuario activo con la fecha actual.
        public Usuario crearUsuario(string nombre, string apellido, string email)
        {
            return new Usuario(true, DateTime.Now);
        }
        
        // Suspende un usuario (cambia su propiedad Activo a false)
        // Solo lo hace si el usuario no es nulo.
        public void suspenderUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                usuario.Activo = false;
            }
        }
        
        // Elimina un usuario del sistema (a implementar)
        public void eliminarUsuario(Usuario usuario)
        {

        }
    }
}