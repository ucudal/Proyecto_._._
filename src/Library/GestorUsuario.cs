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
                // Crea la instancia si no existe
                return instancia ?? (instancia = new GestorUsuarios());
            }
        }

        // Constructor privado (impide instanciación externa)
        private GestorUsuarios() { }

        // Lista que actúa como "base de datos"
        private readonly List<Usuario> usuarios = new List<Usuario>();

        private int proximoId = 1;

        // Agregar un nuevo usuario
        public int AgregarUsuario(bool activo, DateTime fechaCreacion)
        {
            Usuario nuevo = new Usuario(activo, fechaCreacion)
            {
                Id = proximoId
            };

            usuarios.Add(nuevo);
            proximoId++;
            return nuevo.Id;
        }

        // Obtener usuario por ID
        public Usuario ObtenerUsuario(int id)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.Id == id)
                    return usuario;
            }
            return null;
        }

        // Mostrar todos los usuarios
        public void MostrarTodosUsuarios()
        {
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.Id}, Activo: {(usuario.Activo ? "Sí" : "No")}, FechaCreacion: {usuario.FechaCreacion.ToShortDateString()}");
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
            Usuario usuario = ObtenerUsuario(id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
                return true;
            }
            return false;
        }
    }
}
