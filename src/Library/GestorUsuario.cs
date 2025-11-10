using System;
using System.Collections.Generic;

namespace Library
{
    public class GestorUsuarios
    {
        // Instancia única (Singleton)
        private static GestorUsuarios instancia;

        // Propiedad para acceder al Singleton 
        public static GestorUsuarios Instancia
        {
            get
            {
                // Si 'instancia' es null, se crea una nueva.
                // Si no, se devuelve la que ya existe.
                return instancia ?? (instancia = new GestorUsuarios());  //Singelton, no se pueden crear mas instancias
            }
        }

        // Constructor privado (impide usar "new" desde afuera)
        private GestorUsuarios() { }

        // Lista que actúa como "base de datos"
        public List<Usuario> usuarios = new List<Usuario>();

        private int proximoId = 1;  // Contador interno

        // Agregar un nuevo usuario
        public int AgregarUsuario(bool activo, DateTime fechaCreacion)
        {
            Usuario nuevo = new Usuario(activo, fechaCreacion);
            nuevo.Id = proximoId;
            usuarios.Add(nuevo);
            proximoId++;
            return nuevo.Id;
        }

        // Obtener usuario por ID
        public Usuario ObtenerUsuario(int id)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].Id == id)
                {
                    return usuarios[i];
                }
            }
            return null;
        }

        // Mostrar todos los usuarios
        public void MostrarTodosUsuarios()
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                Console.WriteLine("ID: " + usuarios[i].Id +
                                  ", Activo: " + (usuarios[i].Activo ? "Sí" : "No") +
                                  ", FechaCreacion: " + usuarios[i].FechaCreacion.ToShortDateString());
            }
        }

        // Actualizar estado de usuario
        public bool ActualizarActivo(int id, bool nuevoActivo)
        {
            Usuario usuario = ObtenerUsuario(id);
            if (usuario != null)
            {
                usuario.Activo = nuevoActivo;
                return true;
            }
            return false;
        }

        // Eliminar usuario por ID
        public bool EliminarUsuario(int id)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].Id == id)
                {
                    usuarios.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
