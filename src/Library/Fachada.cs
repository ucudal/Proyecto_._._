using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace ProyectoCRM
{
    /// <summary>
    /// Fachada principal del CRM.
    /// </summary>
    public class Fachada
    {
        private readonly GestorUsuarios gestorUsuarios;
        private readonly GestorClientes gestorClientes;
        private readonly GestorInteracciones gestorInteracciones;
        private readonly RegistroVenta registroVenta;

        private readonly List<Etiqueta> etiquetas = new List<Etiqueta>();
        private List<Vendedor> vendedorestotales = new List<Vendedor>();
        private List<int> listaventasdevendedores = new List<int>();
        private int CantidadMayor { get; set; }
        private int CantidadActual { get; set; }
        /// <summary>
        /// Constructor de la Fachada.
        /// </summary>
        public Fachada()
        {
            gestorUsuarios = GestorUsuarios.Instancia;
            gestorClientes = new GestorClientes();
            gestorInteracciones = GestorInteracciones.Instancia;
            registroVenta = new RegistroVenta();
        }

        // ---------------------------------------------------------------------
        // Clientes
        // ---------------------------------------------------------------------

        /// <summary>Registra un nuevo cliente con información básica.</summary>
        public void RegistrarCliente(string nombre, string apellido, string telefono, string email,
                                     string observaciones = null, string genero = null, DateTime? nacimiento = null)
        {
            var cliente = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                Email = email,
                Observaciones = observaciones ?? string.Empty,
                Genero = genero ?? string.Empty,
                FechaNacimiento = nacimiento ?? DateTime.MinValue,
                FechaUltimaInteraccion = DateTime.MinValue
            };

            gestorClientes.AgregarCliente(cliente);
        }

        /// <summary>Modifica la información de un cliente existente.</summary>
        public void ModificarCliente(Cliente cliente, string nombre, string apellido, string telefono, string email,
                                     string observaciones = null, string genero = null, DateTime? nacimiento = null)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));

            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.Telefono = telefono;
            cliente.Email = email;
            cliente.Observaciones = observaciones ?? string.Empty;
            cliente.Genero = genero ?? string.Empty;
            cliente.FechaNacimiento = nacimiento ?? DateTime.MinValue;

            gestorClientes.ModificarCliente(cliente);
        }

        /// <summary>Elimina un cliente del sistema.</summary>
        public bool EliminarCliente(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            return gestorClientes.EliminarCliente(cliente.Id);
        }

        /// <summary>Busca clientes por texto.</summary>
        public List<Cliente> BuscarClientes(string criterio)
        {
            return gestorClientes.BuscarClientes(criterio);
        }

        /// <summary>Obtiene todos los clientes.</summary>
        public List<Cliente> ObtenerClientes()
        {
            return gestorClientes.ObtenerTodos();
        }

        // ---------------------------------------------------------------------
        // Interacciones
        // ---------------------------------------------------------------------

        /// <summary>
        /// Registra una interacción al cliente y al gestor global.
        /// </summary>
        public void RegistrarInteraccion(Cliente cliente, Interaccion interaccion)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            if (interaccion == null) throw new ArgumentNullException(nameof(interaccion));

            int nuevoId = gestorInteracciones.interacciones.Any()
                ? gestorInteracciones.interacciones.Max(i => i.Id) + 1
                : 1;

            interaccion.Id = nuevoId;

            gestorInteracciones.interacciones.Add(interaccion);
            cliente.AgregarInteraccion(interaccion);
        }

        // ---------------------------------------------------------------------
        // Ventas y Cotizaciones
        // ---------------------------------------------------------------------

        public void RegistrarVenta(Cliente cliente, Venta venta, Vendedor vendedor)
        {
            if (cliente == null || venta == null) throw new ArgumentNullException();

            cliente.AgregarInteraccion(venta);
            vendedor.AgregarVenta(venta);
            registroVenta.RegistrarVentaInterna(venta);
        }

        public void RegistrarCotizacion(Cliente cliente, Cotizacion cotizacion)
        {
            if (cliente == null || cotizacion == null) throw new ArgumentNullException();
            cliente.AgregarInteraccion(cotizacion);
        }

        // ---------------------------------------------------------------------
        // Etiquetas
        // ---------------------------------------------------------------------

        public void CrearEtiqueta(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return;

            if (!etiquetas.Any(t => t.Nombre.Equals(nombre, StringComparison.InvariantCultureIgnoreCase)))
            {
                etiquetas.Add(new Etiqueta { Nombre = nombre });
            }
        }

        public List<Etiqueta> ObtenerEtiquetas()
        {
            return new List<Etiqueta>(etiquetas);
        }

        public void AgregarEtiquetaACliente(Cliente cliente, Etiqueta etiqueta)
        {
            if (cliente == null || etiqueta == null) throw new ArgumentNullException();
            cliente.agregarEtiqueta(etiqueta);
        }

        // ---------------------------------------------------------------------
        // Usuarios
        // ---------------------------------------------------------------------

        public int CrearAdministrador(bool activo, DateTime fechaCreacion)
        {
            var adm = gestorUsuarios.CrearAdministrador(activo, fechaCreacion);
            return (adm as UsuarioBase)?.Id ?? 0;
        }

        public int CrearVendedor(bool activo, DateTime fechaCreacion)
        {
            var v = gestorUsuarios.CrearVendedor(activo, fechaCreacion);
            return (v as UsuarioBase)?.Id ?? 0;
        }

        public List<IUsuario> ObtenerUsuarios()
        {
            return gestorUsuarios.ObtenerTodos();
        }
        
        
        // ---------------------------------------------------------------------
        // DEFENSA PROYECTO
        // ---------------------------------------------------------------------
        
        /// <summary>
        /// Método de la fachada que retorna la lista de vendedores 
        /// </summary>
        /// <returns></returns>
        public List<Vendedor> ObtenerVendedores()
        {
            return gestorUsuarios.RecibirVendedores();
        }
        /// <summary>
        /// Método de la fachada que entrega el bono al vendedor con mayor cantidad de ventas
        /// Primero recibe la lista de vendedores por parte de GestorUsuario
        /// Con un foreach recorre cada vendedor de la lista y con el metodo GetVentasInt recibe el numero de ventas de cada vendedor y las almacena en una lista de tipo int
        /// Luego de eso, recorre esta lista de tipo int y almacena en CantidadMayor la variable (la cual representa cada cantidad de ventas por vendedor) mas alta
        /// Por ultimo recorre nuevamente la lista de vendedores y revisa nuevamente la cantidad de ventas de cada uno
        /// Si la cantidad de ventas es igual a la cantidad que recibe del vendedor entonces le da el bono
        /// De esta manera, si varios vendedores tienen la misma cantidad de ventas, se les puede dar a cada uno el bono
        /// </summary>
        /// <param name="vendedor"></param>
        public void DarBono(Vendedor vendedor)
        {
            CantidadMayor = 0;
            CantidadActual = 0;
            vendedorestotales = gestorUsuarios.RecibirVendedores();
            foreach (var VARIABLE in vendedorestotales)
            {
                new List<int>().Add(vendedor.GetVentasInt());   
            }

            foreach (var VARIABLE in listaventasdevendedores)
            {
                if (VARIABLE > CantidadMayor)
                {
                    CantidadMayor = VARIABLE;
                    vendedor.RecibirBono();
                }
            }

            foreach (var VARIABLE in vendedorestotales)
            {
                CantidadActual = vendedor.GetVentasInt();
                if (CantidadActual == CantidadMayor)
                {
                    vendedor.RecibirBono();
                }
            }
        }
    }
}
