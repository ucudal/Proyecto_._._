using System;
using System.Collections.Generic;
namespace Library {
public class GestorUsuarios
{
    // Lista que actúa como nuestra "base de datos" 
    // Guarda todos los objetos de tipo Usuario
    public List<Usuario> usuarios = new List<Usuario>();

    // Contador interno para asignar IDs automáticos a los usuarios nuevos
    private int proximoId = 1;

    // Método para agregar un nuevo usuario
    // Recibe si está activo y la fecha de creación
    public int AgregarUsuario(bool activo, DateTime fechaCreacion)
    {
        // Crea un nuevo objeto Usuario usando su constructor
        Usuario nuevo = new Usuario(activo, fechaCreacion);

        // Asigna un ID único usando el contador interno
        nuevo.Id = proximoId;

        // Agrega el nuevo usuario a la lista
        usuarios.Add(nuevo);

        // Incrementa el contador para el próximo usuario
        proximoId++;

        // Devuelve el ID asignado al nuevo usuario
        return nuevo.Id;
    }

    // Método para obtener un usuario por su ID
    public Usuario ObtenerUsuario(int id)
    {
        // Recorre la lista buscando el usuario con ese ID
        for (int i = 0; i < usuarios.Count; i++)
        {
            if (usuarios[i].Id == id)
            {
                // Devuelve el usuario encontrado
                return usuarios[i];
            }
        }

        // Si no se encuentra, devuelve null
        return null;
    }

    // Método para mostrar todos los usuarios por consola
    public void MostrarTodosUsuarios()
    {
        // Recorre la lista y muestra los datos de cada usuario
        for (int i = 0; i < usuarios.Count; i++)
        {
            Console.WriteLine("ID: " + usuarios[i].Id + 
                              ", Activo: " + (usuarios[i].Activo ? "Sí" : "No") + 
                              ", FechaCreacion: " + usuarios[i].FechaCreacion.ToShortDateString());
        }
    }

    // Método para actualizar el estado "Activo" de un usuario
    public bool ActualizarActivo(int id, bool nuevoActivo)
    {
        // Busca el usuario por ID
        Usuario usuario = ObtenerUsuario(id);

        // Si lo encuentra, actualiza su valor y devuelve true
        if (usuario != null)
        {
            usuario.Activo = nuevoActivo;
            return true;
        }

        // Si no se encontró el usuario, devuelve false
        return false;
    }

    // Método para eliminar un usuario por su ID
    public bool EliminarUsuario(int id)
    {
        // Recorre la lista buscando el usuario con ese ID
        for (int i = 0; i < usuarios.Count; i++)
        {
            if (usuarios[i].Id == id)
            {
                // Si lo encuentra, lo elimina de la lista
                usuarios.RemoveAt(i);
                return true;
            }
        }

        // Si no se encontró el usuario, devuelve false
        return false;
    }
}
}
