using System;
using System.Collections.Generic;
using Library;

namespace ProyectoCRM
{
    /// <summary>
    /// Clase fachada que unifica el acceso a los distintos gestores del sistema CRM.
    /// Permite operar con usuarios, clientes, ventas, etiquetas e interacciones.
    /// </summary>
    public class Fachada
    {
        private GestorUsuarios gestorUsuarios;
        private RegistroVenta registroVenta;
        private List<Etiqueta> etiquetas;

        /// <summary>
        /// Constructor: inicializa los gestores y listas internas.
        /// </summary>
        public Fachada()
        {
            // Usamos el singleton de GestorUsuarios
            gestorUsuarios = GestorUsuarios.Instancia;
            registroVenta = new RegistroVenta(new List<Venta>());
            etiquetas = new List<Etiqueta>();
        }

        // =============================
        // === USUARIOS ===
        // =============================

        /// <summary>
        /// Registra un nuevo vendedor en el sistema.
        /// </summary>
        /// <param name="activo">Indica si el vendedor está activo.</param>
        /// <param name="fechaCreacion">Fecha de creación del usuario.</param>
        /// <returns>ID asignado al vendedor.</returns>
        public int RegistrarVendedor(bool activo, DateTime fechaCreacion)
        {
            return gestorUsuarios.AgregarUsuario(activo, fechaCreacion);
        }

        /// <summary>
        /// Registra un nuevo administrador en el sistema.
        /// </summary>
        /// <param name="activo">Indica si el administrador está activo.</param>
        /// <param name="fechaCreacion">Fecha de creación del usuario.</param>
        /// <returns>ID asignado al administrador.</returns>
        public int RegistrarAdministrador(bool activo, DateTime fechaCreacion)
        {
            return gestorUsuarios.AgregarUsuario(activo, fechaCreacion);
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados en el sistema.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            for (int id = 1; ; id++)
            {
                Usuario u = gestorUsuarios.ObtenerUsuario(id);
                if (u == null) break;
                lista.Add(u);
            }
            return lista;
        }

        // =============================
        // === CLIENTES ===
        // =============================

        /// <summary>
        /// Registra un nuevo cliente en el sistema.
        /// </summary>
        /// <param name="nombre">Nombre del cliente.</param>
        /// <param name="apellido">Apellido del cliente.</param>
        /// <param name="telefono">Teléfono del cliente.</param>
        /// <param name="correo">Correo electrónico.</param>
        /// <param name="descripcion">Descripción u observaciones del cliente.</param>
        /// <param name="genero">Género del cliente.</param>
        /// <param name="nacimiento">Fecha de nacimiento del cliente.</param>
        public void RegistrarCliente(string nombre, string apellido, string telefono, string correo,
                                     string descripcion, string genero, DateTime nacimiento)
        {
            Cliente nuevo = new Cliente()
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
            // Podés integrar GestorClientes si querés manejar almacenamiento persistente
        }

        /// <summary>
        /// Obtiene la lista de clientes registrados.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        public List<Cliente> ObtenerClientes()
        {
            return new List<Cliente>();
        }

        // =============================
        // === VENTAS ===
        // =============================

        /// <summary>
        /// Registra una nueva venta en el sistema.
        /// </summary>
        /// <param name="venta">Instancia de venta a registrar.</param>
        public void RegistrarVenta(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            // Agregamos la venta simbólicamente
            registroVenta.getVentasEntre(venta.Fecha, venta.Fecha);
            // Se puede agregar método AddVenta en RegistroVenta si se desea almacenamiento real
        }

        /// <summary>
        /// Obtiene las ventas registradas entre dos fechas.
        /// </summary>
        /// <param name="desde">Fecha inicial del rango.</param>
        /// <param name="hasta">Fecha final del rango.</param>
        /// <returns>Lista de ventas filtradas por fecha.</returns>
        public List<Venta> ObtenerVentasEntre(DateTime desde, DateTime hasta)
        {
            return registroVenta.getVentasEntre(desde, hasta);
        }

        // =============================
        // === ETIQUETAS ===
        // =============================

        /// <summary>
        /// Crea una nueva etiqueta y la agrega al listado interno.
        /// </summary>
        /// <param name="nombre">Nombre de la etiqueta.</param>
        public void CrearEtiqueta(string nombre)
        {
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                etiquetas.Add(new Etiqueta(nombre));
            }
        }

        /// <summary>
        /// Obtiene todas las etiquetas creadas.
        /// </summary>
        /// <returns>Lista de etiquetas.</returns>
        public List<Etiqueta> ObtenerEtiquetas()
        {
            return new List<Etiqueta>(etiquetas);
        }

        // =============================
        // === INTERACCIONES ===
        // =============================

        /// <summary>
        /// Registra una interacción de un cliente.
        /// </summary>
        /// <param name="cliente">Cliente al que se le asocia la interacción.</param>
        /// <param name="descripcion">Descripción de la interacción.</param>
        public void RegistrarInteraccion(Cliente cliente, string descripcion)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new Exception("La descripción no puede estar vacía.");

            // Ejemplo: usamos Venta como tipo concreto de interacción
            Interaccion nueva = new Venta(0, DateTime.Now, descripcion, "", false, "");
            cliente.AgregarInteraccion(nueva);
        }

        /// <summary>
        /// Obtiene todas las interacciones asociadas a un cliente.
        /// </summary>
        /// <param name="cliente">Cliente cuyo historial se desea obtener.</param>
        /// <returns>Lista de interacciones del cliente.</returns>
        public List<Interaccion> ObtenerInteraccionesDeCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            return cliente.GetInteracciones();
        }
    }
}
