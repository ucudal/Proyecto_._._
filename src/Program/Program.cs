using System;
using System.Collections.Generic;
using Library;

namespace ProyectoCRM
{
    /// <summary>
    /// Programa de demostración del CRM utilizando la clase Fachada.
    /// 
    /// Este programa muestra cómo crear usuarios (vendedores y administradores), 
    /// registrar clientes, agregar diferentes tipos de interacciones 
    /// (Llamada, Correo, Reunión, Mensaje), registrar ventas y crear etiquetas.
    /// Sirve como ejemplo de uso completo del sistema.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Punto de entrada de la demostración.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMOSTRACIÓN DEL CRM USANDO FACHADA ===\n");

            // =====================================
            // INICIALIZACIÓN DE FACHADA
            // =====================================
            Fachada fachada = new Fachada();
            Console.WriteLine("Fachada inicializada.\n");

            // =====================================
            // REGISTRO DE USUARIOS
            // =====================================
            Console.WriteLine("-> Registrando usuarios...");

            int idVendedor = fachada.RegistrarVendedor(true, DateTime.Now);
            int idAdministrador = fachada.RegistrarAdministrador(true, DateTime.Now);

            Console.WriteLine($"Vendedor registrado con ID: {idVendedor}");
            Console.WriteLine($"Administrador registrado con ID: {idAdministrador}");

            List<Usuario> usuarios = fachada.ObtenerUsuarios();
            Console.WriteLine("Usuarios registrados:");
            foreach (var u in usuarios)
            {
                Console.WriteLine($"Activo: {u.Activo}, FechaCreacion: {u.FechaCreacion}");
            }

            // =====================================
            // REGISTRO DE CLIENTES
            // =====================================
            Console.WriteLine("\n-> Registrando clientes...");

            fachada.RegistrarCliente("Juan", "Pérez", "099123456", "juan@example.com", "Cliente VIP", "Masculino", DateTime.Now.AddYears(-30));
            fachada.RegistrarCliente("Ana", "Gómez", "099654321", "ana@example.com", "Cliente Regular", "Femenino", DateTime.Now.AddYears(-25));

            List<Cliente> clientes = fachada.ObtenerClientes();
            Console.WriteLine("Clientes registrados:");
            foreach (var c in clientes)
            {
                Console.WriteLine($"Nombre: {c.Nombre} {c.Apellido}, Email: {c.Email}, Telefono: {c.Telefono}");
            }

            // =====================================
            // REGISTRO DE INTERACCIONES (UN EJEMPLO DE CADA TIPO)
            // =====================================
            Console.WriteLine("\n-> Registrando interacciones...");

            foreach (var cliente in clientes)
            {
                // Llamada
                Interaccion llamada = new Llamada(DateTime.Now, "Llamada inicial", "Notas de la llamada", true, "099123456", "5 min");
                cliente.AgregarInteraccion(llamada);

                // Correo
                Interaccion correo = new Correo(DateTime.Now, "Correo de bienvenida", "Adjunto información", true, "cliente@correo.com");
                cliente.AgregarInteraccion(correo);

                // Reunión
                Interaccion reunion = new Reunion(DateTime.Now.AddDays(1), "Reunión de seguimiento", "Se discuten objetivos", false, "Oficina central", "Sala 101");
                cliente.AgregarInteraccion(reunion);

                // Mensaje
                Interaccion mensaje = new Mensaje(DateTime.Now, "Mensaje de recordatorio", "Recordatorio de cita", true, "099123456", "WhatsApp");
                cliente.AgregarInteraccion(mensaje);
            }

            foreach (var cliente in clientes)
            {
                List<Interaccion> interacciones = fachada.ObtenerInteraccionesDeCliente(cliente);
                Console.WriteLine($"\nInteracciones del cliente {cliente.Nombre}:");
                foreach (var i in interacciones)
                {
                    Console.WriteLine($" - Tipo: {i.GetType().Name}, Descripcion: {i.Descripcion}, Fecha: {i.Fecha}");
                }
            }

            // =====================================
            // REGISTRO DE VENTAS
            // =====================================
            Console.WriteLine("\n-> Registrando ventas...");

            Venta venta1 = new Venta(1500.50, DateTime.Now, "Venta Producto A", "Pago recibido", true, "juan@example.com");
            Venta venta2 = new Venta(2500, DateTime.Now, "Venta Producto B", "Pago pendiente", false, "ana@example.com");

            fachada.RegistrarVenta(venta1);
            fachada.RegistrarVenta(venta2);

            List<Venta> ventasHoy = fachada.ObtenerVentasEntre(DateTime.Now.AddDays(-1), DateTime.Now);
            Console.WriteLine("Ventas registradas:");
            foreach (var v in ventasHoy)
            {
                Console.WriteLine($"Venta: {v.Descripcion}, Total: {v.Total}, Fecha: {v.Fecha}");
            }

            // =====================================
            // CREACIÓN DE ETIQUETAS
            // =====================================
            Console.WriteLine("\n-> Creando etiquetas...");

            fachada.CrearEtiqueta("VIP");
            fachada.CrearEtiqueta("Regular");

            List<Etiqueta> etiquetas = fachada.ObtenerEtiquetas();
            Console.WriteLine("Etiquetas creadas:");
            foreach (var e in etiquetas)
            {
                Console.WriteLine($" - {e.ObtenerNombre()}");
            }

            Console.WriteLine("\n=== DEMOSTRACIÓN COMPLETA ===");
            Console.WriteLine("Usuarios, clientes, interacciones, ventas y etiquetas han sido registrados correctamente.");

            Console.WriteLine("\nPulse cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
