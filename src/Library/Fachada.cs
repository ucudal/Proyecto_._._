using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace ProyectoCRM
{
    /// <summary>
    /// Fachada principal del CRM.
    /// Unifica el acceso a clientes, ventas, cotizaciones, interacciones, etiquetas y usuarios.
    /// </summary>
    public class Fachada
    {
        private readonly GestorUsuarios gestorUsuarios;
        private readonly RegistroVenta registroVenta;
        private readonly List<Cliente> clientes;
        private readonly List<Etiqueta> etiquetas;

        /// <summary>
        /// Inicializa la fachada.
        /// </summary>
        public Fachada()
        {
            gestorUsuarios = GestorUsuarios.Instancia;
            registroVenta = new RegistroVenta();
            clientes = new List<Cliente>();
            etiquetas = new List<Etiqueta>();
        }

        /// <summary>Obtiene todos los usuarios registrados.</summary>
        /// <returns>Lista de usuarios.</returns>
        public List<IUsuario> ObtenerUsuarios() => gestorUsuarios.ObtenerTodos();

        /// <summary>Registra un nuevo cliente.</summary>
        public void RegistrarCliente(string nombre, string apellido, string telefono, string correo,
                                     string descripcion, string genero, DateTime nacimiento)
        {
            Cliente nuevo = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                Email = correo,
                Observaciones = descripcion,
                Genero = genero,
                FechaNacimiento = nacimiento,
                FechaUltimaInteraccion = DateTime.Now
            };
            clientes.Add(nuevo);
        }

        /// <summary>Modifica un cliente existente.</summary>
        public void ModificarCliente(Cliente cliente, string nombre, string apellido, string telefono, string correo,
                                     string descripcion, string genero, DateTime nacimiento)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));

            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.Telefono = telefono;
            cliente.Email = correo;
            cliente.Observaciones = descripcion;
            cliente.Genero = genero;
            cliente.FechaNacimiento = nacimiento;
        }

        /// <summary>Elimina un cliente del sistema.</summary>
        public bool EliminarCliente(Cliente cliente) => cliente != null && clientes.Remove(cliente);

        /// <summary>Busca clientes por nombre, apellido, teléfono o correo.</summary>
        public List<Cliente> BuscarClientes(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio)) return new List<Cliente>(clientes);

            return clientes
                .Where(c => c.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase)
                         || c.Apellido.Contains(criterio, StringComparison.OrdinalIgnoreCase)
                         || c.Telefono.Contains(criterio)
                         || c.Email.Contains(criterio, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>Obtiene todos los clientes.</summary>
        public List<Cliente> ObtenerClientes() => new List<Cliente>(clientes);

        /// <summary>Registra una interacción de un cliente.</summary>
        public void RegistrarInteraccion(Cliente cliente, Interaccion interaccion)
        {
            if (cliente == null || interaccion == null) throw new ArgumentNullException();

            cliente.AgregarInteraccion(interaccion);
        }

        /// <summary>Registra una venta de un cliente.</summary>
        public void RegistrarVenta(Cliente cliente, Venta venta)
        {
            if (cliente == null || venta == null) throw new ArgumentNullException();

            cliente.AgregarInteraccion(venta);
            registroVenta.AgregarVenta(venta);
        }

        /// <summary>Registra una cotización de un cliente.</summary>
        public void RegistrarCotizacion(Cliente cliente, Cotizacion cotizacion)
        {
            if (cliente == null || cotizacion == null) throw new ArgumentNullException();

            cliente.AgregarInteraccion(cotizacion);
        }

        /// <summary>Crea una nueva etiqueta.</summary>
        public void CrearEtiqueta(string nombre)
        {
            if (!string.IsNullOrWhiteSpace(nombre)) etiquetas.Add(new Etiqueta(nombre));
        }

        /// <summary>Obtiene todas las etiquetas.</summary>
        public List<Etiqueta> ObtenerEtiquetas() => new List<Etiqueta>(etiquetas);

        /// <summary>Agrega una etiqueta a un cliente.</summary>
        public void AgregarEtiquetaACliente(Cliente cliente, Etiqueta etiqueta)
        {
            if (cliente == null || etiqueta == null) throw new ArgumentNullException();
            cliente.agregarEtiqueta(etiqueta);
        }
    }
}
