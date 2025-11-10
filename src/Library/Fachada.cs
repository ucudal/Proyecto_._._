using System;
using System.Collections.Generic;
using Library;

namespace ProyectoCRM
{
    public class Fachada
    {
        private GestorUsuarios gestorUsuarios;
        private RegistroVenta registroVenta;
        private List<Etiqueta> etiquetas;

        public Fachada()
        {
            // Usamos el singleton de GestorUsuarios
            gestorUsuarios = GestorUsuarios.Instancia;
            registroVenta = new RegistroVenta(new List<Venta>());
            etiquetas = new List<Etiqueta>();
        }

        // -----------------------------
        // === USUARIOS ===
        // -----------------------------
        public int RegistrarVendedor(bool activo, DateTime fechaCreacion)
        {
            // Como GestorUsuarios no acepta Vendedor directamente,
            // usamos AgregarUsuario que devuelve un ID
            return gestorUsuarios.AgregarUsuario(activo, fechaCreacion);
        }

        public int RegistrarAdministrador(bool activo, DateTime fechaCreacion)
        {
            return gestorUsuarios.AgregarUsuario(activo, fechaCreacion);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            // Devuelve todos los usuarios existentes
            List<Usuario> lista = new List<Usuario>();
            for (int id = 1; ; id++)
            {
                Usuario u = gestorUsuarios.ObtenerUsuario(id);
                if (u == null) break;
                lista.Add(u);
            }
            return lista;
        }

        // -----------------------------
        // === CLIENTES ===
        // -----------------------------
        public void RegistrarCliente(string nombre, string apellido, string telefono, string correo,
                                     string descripcion, string genero, DateTime nacimiento)
        {
            // Cliente usa constructor por defecto + asignaciones
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
            // Podés implementar un GestorClientes si querés guardar en algún lado
        }

        public List<Cliente> ObtenerClientes()
        {
            // Para simplificar, retornamos una lista vacía
            // O integrar un GestorClientes si querés manejo real
            return new List<Cliente>();
        }

        // -----------------------------
        // === VENTAS ===
        // -----------------------------
        public void RegistrarVenta(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            // Agregamos la venta a la lista interna
            registroVenta.getVentasEntre(venta.Fecha, venta.Fecha); // simbólico
            // Si querés, podés agregar un método AddVenta en RegistroVenta
        }

        public List<Venta> ObtenerVentasEntre(DateTime desde, DateTime hasta)
        {
            return registroVenta.getVentasEntre(desde, hasta);
        }

        // -----------------------------
        // === ETIQUETAS ===
        // -----------------------------
        public void CrearEtiqueta(string nombre)
        {
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                etiquetas.Add(new Etiqueta(nombre));
            }
        }

        public List<Etiqueta> ObtenerEtiquetas()
        {
            return new List<Etiqueta>(etiquetas);
        }

        // -----------------------------
        // === INTERACCIONES ===
        // -----------------------------
        public void RegistrarInteraccion(Cliente cliente, string descripcion)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new Exception("La descripción no puede estar vacía.");

            // Como Interaccion es abstracta, usamos Venta como ejemplo de interacción
            Interaccion nueva = new Venta(0, DateTime.Now, descripcion, "", false, "");
            cliente.AgregarInteraccion(nueva);
        }

        public List<Interaccion> ObtenerInteraccionesDeCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            return cliente.GetInteracciones();
        }
    }
}
