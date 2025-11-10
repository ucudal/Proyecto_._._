using System;
using System.Collections.Generic;

namespace Library
{
    // Esta clase gestiona la lista de clientes del sistema
    // Permite agregar, obtener, mostrar, actualizar y eliminar clientes
    public class GestorClientes
    {
        // Lista que actúa como nuestra "base de datos"
        
        public List<Cliente> clientes = new List<Cliente>();

        // Contador interno para asignar IDs automáticos a los clientes nuevos
        private int proximoId = 1;

        // Singleton para asegurar una sola instancia de GestorClientes
        private static GestorClientes instancia;

        public static GestorClientes Instancia
        {
            get
            {
                return instancia ?? (instancia = new GestorClientes());
            }
        }

        // Constructor privado, esto evita la creación de instancias externas.
        private GestorClientes() { }

        // Método para agregar un nuevo cliente
        // Recibe los datos principales del cliente
        public int AgregarCliente(string nombre, string apellido, string email, string telefono)
        {
            Cliente nuevo = new Cliente();

            // Asigna los valores básicos
            nuevo.Id = proximoId;
            nuevo.Nombre = nombre;
            nuevo.Apellido = apellido;
            nuevo.Email = email;
            nuevo.Telefono = telefono;
            nuevo.FechaUltimaInteraccion = DateTime.Now;

            // Agrega a la lista general
            clientes.Add(nuevo);

            // Incrementa el contador para el siguiente cliente
            proximoId++;

            // Devuelve el ID asignado
            return nuevo.Id;
        }

        // Método para obtener un cliente por su ID
        public Cliente ObtenerCliente(int id)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Id == id)
                {
                    return clientes[i];
                }
            }
            return null;
        }

        // Método para mostrar todos los clientes por consola
        public void MostrarTodosClientes()
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine("ID: " + clientes[i].Id +
                                  ", Nombre: " + clientes[i].Nombre +
                                  ", Apellido: " + clientes[i].Apellido +
                                  ", Email: " + clientes[i].Email +
                                  ", Teléfono: " + clientes[i].Telefono);
            }
        }

        // Método para actualizar el email de un cliente
        public bool ActualizarEmail(int id, string nuevoEmail)
        {
            Cliente cliente = ObtenerCliente(id);
            if (cliente != null)
            {
                cliente.Email = nuevoEmail;
                return true;
            }
            return false;
        }

        // Método para eliminar un cliente por su ID
        public bool EliminarCliente(int id)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Id == id)
                {
                    clientes.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
