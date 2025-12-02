using NUnit.Framework;
using System;
using System.Linq;
using Library;
using ProyectoCRM;

namespace ProyectoCRM.Tests
{
    /// <summary>
    /// Pruebas unitarias de la fachada validando las historias de usuario posibles.
    /// </summary>
    [TestFixture]
    public class FachadaTests
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {
            fachada = new Fachada();
        }

        // ============================================================
        // CLIENTES
        // ============================================================

        /// <summary>HU: Crear un nuevo cliente.</summary>
        [Test]
        public void CrearCliente_OK()
        {
            fachada.RegistrarCliente("Juan", "Perez", "123", "jp@mail.com");

            var lista = fachada.ObtenerClientes();
            Assert.IsTrue(lista.Any());

            var c = lista.First();
            Assert.AreEqual("Juan", c.Nombre);
            Assert.AreEqual("Perez", c.Apellido);
        }

        /// <summary>HU: Modificar cliente existente.</summary>
        [Test]
        public void ModificarCliente_OK()
        {
            fachada.RegistrarCliente("Ana", "Lopez", "111", "ana@mail.com");
            var cliente = fachada.ObtenerClientes().First();

            fachada.ModificarCliente(cliente, "Ana María", "Lopez", "222", "am@mail.com");

            var actualizado = fachada.ObtenerClientes().First();
            Assert.AreEqual("Ana María", actualizado.Nombre);
            Assert.AreEqual("222", actualizado.Telefono);
        }

        /// <summary>HU: Eliminar cliente.</summary>
        [Test]
        public void EliminarCliente_OK()
        {
            fachada.RegistrarCliente("Luis", "Diaz", "555", "ld@mail.com");
            var cliente = fachada.ObtenerClientes().First();

            bool ok = fachada.EliminarCliente(cliente);

            Assert.IsTrue(ok);
            Assert.IsFalse(fachada.ObtenerClientes().Any());
        }

        /// <summary>HU: Buscar clientes por criterio.</summary>
        [Test]
        public void BuscarClientes_OK()
        {
            fachada.RegistrarCliente("Carlos", "Lopez", "999", "carlos@mail.com");

            Assert.IsTrue(fachada.BuscarClientes("Carlos").Any());
            Assert.IsTrue(fachada.BuscarClientes("999").Any());
        }

        /// <summary>HU: Lista completa de clientes.</summary>
        [Test]
        public void ObtenerClientes_OK()
        {
            fachada.RegistrarCliente("Pedro", "Gomez", "123", "p@mail.com");
            fachada.RegistrarCliente("Maria", "Sosa", "456", "m@mail.com");

            var lista = fachada.ObtenerClientes();
            Assert.AreEqual(2, lista.Count);
        }

        // ============================================================
        // INTERACCIONES (solo las que soporta la fachada)
        // ============================================================

        /// <summary>HU: Registrar llamadas.</summary>
        [Test]
        public void RegistrarLlamada_OK()
        {
            fachada.RegistrarCliente("Laura", "Vega", "444", "lv@mail.com");
            var cliente = fachada.ObtenerClientes().First();

            var llamada = new Llamada
            {
                Fecha = DateTime.Now,
                Descripcion = "Consulta general",
                Respondida = true
            };

            fachada.RegistrarInteraccion(cliente, llamada);

            Assert.IsTrue(cliente.GetInteracciones().Any());
        }

        /// <summary>HU: Registrar venta.</summary>
        [Test]
        public void RegistrarVenta_OK()
        {
            fachada.RegistrarCliente("Raul", "Quiroga", "999", "r@mail.com");
            var cliente = fachada.ObtenerClientes().First();

            var venta = new Venta(1500, DateTime.Today, "Producto A", String.Empty, false, String.Empty, null);
            

            fachada.RegistrarVenta(cliente, venta);

            Assert.IsTrue(cliente.GetInteracciones().Any(i => i is Venta));
        }

        /// <summary>HU: Registrar cotización.</summary>
        [Test]
        public void RegistrarCotizacion_OK()
        {
            fachada.RegistrarCliente("Fede", "Paz", "123", "f@mail.com");
            var cliente = fachada.ObtenerClientes().First();

            var cot = new Cotizacion("Pendiente", DateTime.Today, 1500, DateTime.Today, "Una descripción", String.Empty,
                false, string.Empty);

            fachada.RegistrarCotizacion(cliente, cot);

            Assert.IsTrue(cliente.GetInteracciones().Any(i => i is Cotizacion));
        }

        // ============================================================
        // ETIQUETAS
        // ============================================================

        /// <summary>HU: Crear etiquetas.</summary>
        [Test]
        public void CrearEtiqueta_OK()
        {
            fachada.CrearEtiqueta("VIP");

            Assert.IsTrue(fachada.ObtenerEtiquetas().Any(e => e.Nombre == "VIP"));
        }

        /// <summary>HU: Agregar etiqueta a cliente.</summary>
        [Test]
        public void AgregarEtiquetaACliente_OK()
        {
            fachada.RegistrarCliente("Pedro", "Luna", "777", "p@mail.com");
            fachada.CrearEtiqueta("Importante");

            var cliente = fachada.ObtenerClientes().First();
            var etiqueta = fachada.ObtenerEtiquetas().First();

            fachada.AgregarEtiquetaACliente(cliente, etiqueta);

            Assert.IsTrue(cliente.GetEtiquetas().Any(e => e.Nombre == "Importante"));
        }

        // ============================================================
        // USUARIOS
        // ============================================================

        /// <summary>HU: Crear administrador.</summary>
        [Test]
        public void CrearAdministrador_OK()
        {
            int id = fachada.CrearAdministrador(true, DateTime.Now);
            Assert.IsTrue(fachada.ObtenerUsuarios().Any(u => u.Id == id));
        }

        /// <summary>HU: Crear vendedor.</summary>
        [Test]
        public void CrearVendedor_OK()
        {
            int id = fachada.CrearVendedor(true, DateTime.Now);
            Assert.IsTrue(fachada.ObtenerUsuarios().Any(u => u.Id == id));
        }
    }
}
