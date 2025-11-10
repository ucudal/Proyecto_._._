// GestorClientes.cs
using System;
using System.Collections.Generic;

namespace Library
{
    // Esta clase gestiona la lista de clientes del sistema
    // Permite agregar, obtener, mostrar, actualizar y eliminar clientes
    public class GestorClientes
    {
        // Lista que actúa como nuestra "base de datos"
        private readonly List<Cliente> clientes = new List<Cliente>();

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
            Cliente nuevo = new Cliente
            {
                Id = proximoId,
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                Telefono = telefono,
                FechaUltimaInteraccion = DateTime.Now
            };

            clientes.Add(nuevo);
            proximoId++;
            return nuevo.Id;
        }

        // Método para obtener un cliente por su ID
        public Cliente ObtenerCliente(int id)
        {
            foreach (var c in clientes)
            {
                if (c.Id == id)
                    return c;
            }
            return null;
        }

        // Método para mostrar todos los clientes por consola
        public void MostrarTodosClientes()
        {
            foreach (var c in clientes)
            {
                Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, Apellido: {c.Apellido}, Email: {c.Email}, Teléfono: {c.Telefono}");
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
            var cliente = ObtenerCliente(id);
            if (cliente != null)
            {
                return clientes.Remove(cliente);
            }
            return false;
        }

        // Opcional: exponer una copia de la lista de clientes (si se necesita fuera)
        public List<Cliente> ObtenerTodosClientes()
        {
            return new List<Cliente>(clientes);
        }
    }
}
