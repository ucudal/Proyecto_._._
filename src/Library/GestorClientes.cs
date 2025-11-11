// GestorClientes.cs
using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que gestiona la lista de clientes del sistema.
    /// Implementa el patrón Singleton para asegurar una sola instancia.
    /// Permite agregar, obtener, mostrar, actualizar y eliminar clientes.
    /// </summary>
    public class GestorClientes
    {
        /// <summary>
        /// Lista que actúa como "base de datos" de clientes.
        /// </summary>
        private readonly List<Cliente> clientes = new List<Cliente>();

        /// <summary>
        /// Contador interno para asignar IDs automáticos a los clientes nuevos.
        /// </summary>
        private int proximoId = 1;

        /// <summary>
        /// Instancia única del gestor (Singleton).
        /// </summary>
        private static GestorClientes instancia;

        /// <summary>
        /// Propiedad para acceder al Singleton de GestorClientes.
        /// </summary>
        public static GestorClientes Instancia
        {
            get
            {
                return instancia ?? (instancia = new GestorClientes());
            }
        }

        /// <summary>
        /// Constructor privado para evitar instanciación externa.
        /// </summary>
        private GestorClientes() { }

        /// <summary>
        /// Agrega un nuevo cliente al sistema.
        /// </summary>
        /// <param name="nombre">Nombre del cliente.</param>
        /// <param name="apellido">Apellido del cliente.</param>
        /// <param name="email">Correo electrónico del cliente.</param>
        /// <param name="telefono">Teléfono del cliente.</param>
        /// <returns>ID asignado al nuevo cliente.</returns>
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

        /// <summary>
        /// Obtiene un cliente por su ID.
        /// </summary>
        /// <param name="id">ID del cliente a buscar.</param>
        /// <returns>Cliente encontrado o null si no existe.</returns>
        public Cliente ObtenerCliente(int id)
        {
            foreach (var c in clientes)
            {
                if (c.Id == id)
                    return c;
            }
            return null;
        }

        /// <summary>
        /// Muestra todos los clientes registrados en la consola.
        /// </summary>
        public void MostrarTodosClientes()
        {
            foreach (var c in clientes)
            {
                Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, Apellido: {c.Apellido}, Email: {c.Email}, Teléfono: {c.Telefono}");
            }
        }

        /// <summary>
        /// Actualiza el correo electrónico de un cliente.
        /// </summary>
        /// <param name="id">ID del cliente a actualizar.</param>
        /// <param name="nuevoEmail">Nuevo correo electrónico.</param>
        /// <returns>True si se actualizó correctamente, false si no se encontró el cliente.</returns>
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

        /// <summary>
        /// Elimina un cliente por su ID.
        /// </summary>
        /// <param name="id">ID del cliente a eliminar.</param>
        /// <returns>True si se eliminó correctamente, false si no se encontró.</returns>
        public bool EliminarCliente(int id)
        {
            var cliente = ObtenerCliente(id);
            if (cliente != null)
            {
                return clientes.Remove(cliente);
            }
            return false;
        }

        /// <summary>
        /// Obtiene una copia de todos los clientes registrados.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        public List<Cliente> ObtenerTodosClientes()
        {
            return new List<Cliente>(clientes);
        }
    }
}
