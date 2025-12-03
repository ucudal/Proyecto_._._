using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<Cliente> clientes;

        /// <summary>
        /// Constructor: inicializa los gestores y listas internas.
        /// </summary>
        public Fachada()
        {
            // Usamos el singleton de GestorUsuarios
            gestorUsuarios = GestorUsuarios.Instancia;
            registroVenta = new RegistroVenta(new List<Venta>());
            etiquetas = new List<Etiqueta>();
            clientes = new List<Cliente>();
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
            // Más adelante podríamos diferenciar tipos de usuario (vendedor/administrador)
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
            // Idem comentario en RegistrarVendedor
            return gestorUsuarios.AgregarUsuario(activo, fechaCreacion);
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados en el sistema.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            // Este esquema asume IDs consecutivos comenzando en 1
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

            // Por ahora lo almacenamos en la lista interna de la fachada.
            // Más adelante se puede delegar a un GestorClientes.
            clientes.Add(nuevo);
        }

        /// <summary>
        /// Obtiene la lista de clientes registrados.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        public List<Cliente> ObtenerClientes()
        {
            // Devolvemos una copia para no exponer la lista interna.
            return new List<Cliente>(clientes);
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
            {
                throw new ArgumentNullException(nameof(venta));
            }

            // La responsabilidad de almacenar la venta es de RegistroVenta.
            registroVenta.AgregarVenta(venta);
        }

        /// <summary>
        /// Registra una nueva venta a partir de una cotización.
        /// De esta forma se mantiene la relación entre Venta y Cotizacion.
        /// </summary>
        /// <param name="cotizacion">Cotización desde la cual se genera la venta.</param>
        /// <param name="total">Total de la venta.</param>
        public void RegistrarVentaDesdeCotizacion(Cotizacion cotizacion, double total)
        {
            if (cotizacion == null)
            {
                throw new ArgumentNullException(nameof(cotizacion));
            }

            // Creamos la venta a partir de la cotización
            Venta venta = new Venta(
                total,
                DateTime.Now,
                "Venta desde cotización",
                "",
                false,
                ""
            );

            // Relacionamos la venta con la cotización de origen
            venta.AsignarCotizacion(cotizacion);

            // Registramos la venta en el registro de ventas
            registroVenta.AgregarVenta(venta);
        }

        /// <summary>
        /// Obtiene las ventas registradas entre dos fechas.
        /// </summary>
        /// <param name="desde">Fecha inicial del rango.</param>
        /// <param name="hasta">Fecha final del rango.</param>
        /// <returns>Lista de ventas filtradas por fecha.</returns>
        public List<Venta> ObtenerVentasEntre(DateTime desde, DateTime hasta)
        {
            // Este método delega en RegistroVenta.
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
        /// Registra una interacción asociada a un cliente.
        /// La interacción concreta (llamada, mensaje, reunión, etc.) se construye fuera de la fachada.
        /// </summary>
        /// <param name="cliente">Cliente al que se le asocia la interacción.</param>
        /// <param name="interaccion">Interacción ya construida.</param>
        public void RegistrarInteraccion(Cliente cliente, Interaccion interaccion)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            if (interaccion == null)
            {
                throw new ArgumentNullException(nameof(interaccion));
            }

            cliente.AgregarInteraccion(interaccion);
        }

        /// <summary>
        /// Obtiene todas las interacciones asociadas a un cliente.
        /// </summary>
        /// <param name="cliente">Cliente cuyo historial se desea obtener.</param>
        /// <returns>Lista de interacciones del cliente.</returns>
        public List<Interaccion> ObtenerInteraccionesDeCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            return cliente.GetInteracciones();
        }
    }
}
// Devuelve un diccionario: VendedorId -> CantidadDeVentas
namespace ObtenerVentasPorVendedor{}
Dictionary<string, int> ObtenerVentasPorVendedor()
{
    var ventas = Venta.GetAll();
    var vendedores = Vendedor.GetAll();

    // Inicio el diccionario con todos los vendedores en 0
    var resultado = new Dictionary<string, int>();

    foreach (var vendedor in vendedores)
        resultado[vendedor.Id] = 0;

    // Cuento las ventas por vendedor
    foreach (var venta in ventas)
    {
        string vendedor;
        if (resultado.ContainsKey(vendedor))
            resultado[vendedor]++;
    }

    return resultado;
}
 
//Devuelve el vendedor con más ventas + mas bono

(Vendedor vendedor, int cantidadVentas, int bono) ObtenerTopVendedorConBono()
{
    var dict = ObtenerVentasPorVendedor();

    // Obtengo el ID del vendedor con más ventas
    var top = dict.OrderByDescending(x => x.Value).First();

    Vendedor MaxVendedor;
    var vendedor = MaxVendedor;
    int cantidad = top.Value;
    int bono = cantidad + 100;

    return (MaxVendedor, cantidad, bono);
}


