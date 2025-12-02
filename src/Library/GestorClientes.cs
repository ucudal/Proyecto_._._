using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    /// <summary>
    /// Repositorio central de clientes del sistema.
    /// Permite agregar, modificar, eliminar y buscar clientes.
    /// </summary>
    public class GestorClientes
    {
        private readonly List<Cliente> clientes = new List<Cliente>();
        private int proximoId = 1;

        /// <summary>
        /// Agrega un nuevo cliente al sistema.
        /// </summary>
        /// <param name="cliente">Cliente a agregar.</param>
        /// <returns>ID asignado al cliente.</returns>
        public int AgregarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            cliente.Id = proximoId++;
            clientes.Add(cliente);
            return cliente.Id;
        }

        /// <summary>
        /// Elimina un cliente del sistema según su ID.
        /// </summary>
        /// <param name="id">ID del cliente.</param>
        /// <returns>True si se eliminó, False si no se encontró.</returns>
        public bool EliminarCliente(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Modifica la información de un cliente existente.
        /// </summary>
        /// <param name="cliente">Cliente con los nuevos datos.</param>
        /// <returns>True si se actualizó, False si no se encontró.</returns>
        public bool ModificarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            var existente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (existente != null)
            {
                existente.Nombre = cliente.Nombre;
                existente.Apellido = cliente.Apellido;
                existente.Telefono = cliente.Telefono;
                existente.Email = cliente.Email;
                existente.Genero = cliente.Genero;
                existente.FechaNacimiento = cliente.FechaNacimiento;
                existente.Observaciones = cliente.Observaciones;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Busca clientes por nombre, apellido, teléfono o correo electrónico.
        /// </summary>
        /// <param name="filtro">Texto de búsqueda.</param>
        /// <returns>Lista de clientes coincidentes.</returns>
        public List<Cliente> BuscarClientes(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
                return new List<Cliente>(clientes);

            filtro = filtro.ToLower();
            return clientes.Where(c =>
                (c.Nombre?.ToLower().Contains(filtro) ?? false) ||
                (c.Apellido?.ToLower().Contains(filtro) ?? false) ||
                (c.Telefono?.ToLower().Contains(filtro) ?? false) ||
                (c.Email?.ToLower().Contains(filtro) ?? false)
            ).ToList();
        }

        /// <summary>
        /// Obtiene todos los clientes registrados.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        public List<Cliente> ObtenerTodos()
        {
            return new List<Cliente>(clientes);
        }
    }
}
