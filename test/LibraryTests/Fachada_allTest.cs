using System;
using System.Collections.Generic;
using NUnit.Framework;
using Library;
using ProyectoCRM;

namespace ProyectoCRM.Tests
{
    [TestFixture]
    public class FachadaCompletaTests
    {
        private Fachada fachada;

        [SetUp]
        public void SetUp()
        {
            // Cada test empieza con una fachada "limpia"
            fachada = new Fachada();

            // Limpiamos usuarios y clientes del singleton
            typeof(GestorUsuarios).GetField("instancia", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).SetValue(null, null);
            typeof(GestorClientes).GetField("instancia", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).SetValue(null, null);
            typeof(GestorInteracciones).GetField("instancia", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).SetValue(null, null);
        }

        // =============================
        // === TESTS DE USUARIOS ===
        // =============================

        [Test]
        public void AgregarYObtenerUsuario_Test()
        {
            // Agregamos un vendedor y un admin
            int idVendedor = fachada.RegistrarVendedor(true, DateTime.Now);
            int idAdmin = fachada.RegistrarAdministrador(true, DateTime.Now);

            List<Usuario> usuarios = fachada.ObtenerUsuarios();

            Assert.AreEqual(2, usuarios.Count, "Debería haber 2 usuarios registrados");
            Assert.IsTrue(usuarios.Exists(u => u.Id == idVendedor), "No se encontró al vendedor agregado");
            Assert.IsTrue(usuarios.Exists(u => u.Id == idAdmin), "No se encontró al administrador agregado");
        }

        [Test]
        public void EliminarUsuario_Test()
        {
            int id = fachada.RegistrarVendedor(true, DateTime.Now);
            GestorUsuarios.Instancia.EliminarUsuario(id);

            Usuario u = GestorUsuarios.Instancia.ObtenerUsuario(id);
            Assert.IsNull(u, "El usuario debería haber sido eliminado");
        }

        [Test]
        public void ActualizarActivoUsuario_Test()
        {
            int id = fachada.RegistrarAdministrador(false, DateTime.Now);
            bool actualizado = GestorUsuarios.Instancia.ActualizarActivo(id, true);
            Usuario u = GestorUsuarios.Instancia.ObtenerUsuario(id);

            Assert.IsTrue(actualizado, "Debería actualizar correctamente");
            Assert.IsTrue(u.Activo, "El usuario debería estar activo");
        }

        // =============================
        // === TESTS DE CLIENTES ===
        // =============================

        [Test]
        public void AgregarYObtenerCliente_Test()
        {
            int id = GestorClientes.Instancia.AgregarCliente("Juan", "Perez", "juan@mail.com", "12345");
            Cliente c = GestorClientes.Instancia.ObtenerCliente(id);

            Assert.IsNotNull(c, "El cliente debería existir");
            Assert.AreEqual("Juan", c.Nombre);
            Assert.AreEqual("Perez", c.Apellido);
        }

        [Test]
        public void ActualizarEmailCliente_Test()
        {
            int id = GestorClientes.Instancia.AgregarCliente("Ana", "Gomez", "ana@mail.com", "54321");
            bool actualizado = GestorClientes.Instancia.ActualizarEmail(id, "nuevo@mail.com");

            Cliente c = GestorClientes.Instancia.ObtenerCliente(id);
            Assert.IsTrue(actualizado, "El email debería actualizarse correctamente");
            Assert.AreEqual("nuevo@mail.com", c.Email);
        }

        [Test]
        public void EliminarCliente_Test()
        {
            int id = GestorClientes.Instancia.AgregarCliente("Luis", "Martinez", "luis@mail.com", "99999");
            bool eliminado = GestorClientes.Instancia.EliminarCliente(id);

            Cliente c = GestorClientes.Instancia.ObtenerCliente(id);
            Assert.IsTrue(eliminado, "El cliente debería eliminarse correctamente");
            Assert.IsNull(c, "El cliente ya no debería existir");
        }

        [Test]
        public void ObtenerTodosClientes_Test()
        {
            GestorClientes.Instancia.AgregarCliente("C1", "A", "c1@mail.com", "111");
            GestorClientes.Instancia.AgregarCliente("C2", "B", "c2@mail.com", "222");

            List<Cliente> clientes = GestorClientes.Instancia.ObtenerTodosClientes();
            Assert.AreEqual(2, clientes.Count, "Debería devolver todos los clientes");
        }

        // =============================
        // === TESTS DE VENTAS ===
        // =============================

        [Test]
        public void RegistrarYObtenerVentas_Test()
        {
            Venta v1 = new Venta(100, DateTime.Today, "Venta 1", "", false, "");
            Venta v2 = new Venta(200, DateTime.Today.AddDays(1), "Venta 2", "", false, "");

            fachada.RegistrarVenta(v1);
            fachada.RegistrarVenta(v2);

            List<Venta> ventas = fachada.ObtenerVentasEntre(DateTime.Today, DateTime.Today.AddDays(1));
            Assert.AreEqual(2, ventas.Count, "Debería obtener las 2 ventas registradas");
        }

        [Test]
        public void GetTotalesVenta_Test()
        {
            Venta v = new Venta(150, DateTime.Today, "Venta test", "", false, "");
            double total = v.GetTotales("", "");
            Assert.AreEqual(150, total, "El total de la venta debería ser correcto");
        }

        // =============================
        // === TESTS DE INTERACCIONES ===
        // =============================

        [Test]
        public void AgregarYObtenerInteraccion_Test()
        {
            Cliente c = new Cliente("Marta", "Lopez", "123", "marta@mail.com", "", "F", DateTime.Now.AddYears(-30), DateTime.Now);
            Interaccion i = new Venta(50, DateTime.Today, "Prueba interacción", "", false, "");

            c.AgregarInteraccion(i);

            List<Interaccion> interacciones = c.GetInteracciones();
            Assert.AreEqual(1, interacciones.Count, "Debería registrar 1 interacción");
            Assert.AreEqual("Prueba interacción", interacciones[0].Descripcion);
        }

        [Test]
        public void InteraccionSinDescripcion_Test()
        {
            Assert.Throws<InteraccionSinDescripcionException>(() =>
            {
                new Venta(0, DateTime.Now, "", "", false, "");
            }, "Debería lanzar excepción al crear interacción sin descripción");
        }

        [Test]
        public void TieneInteraccionesSinRespuesta_Test()
        {
            Cliente c = new Cliente();
            c.AgregarInteraccion(new Venta(0, DateTime.Now, "X", "", false, ""));
            Assert.IsTrue(c.tieneInteraccionesSinRespuesta(), "Debería detectar interacciones sin respuesta");

            c.AgregarInteraccion(new Venta(0, DateTime.Now, "Y", "", true, ""));
            Assert.IsTrue(c.tieneInteraccionesSinRespuesta(), "Sigue habiendo interacciones sin respuesta");
        }

        [Test]
        public void EsInactivo_Test()
        {
            Cliente c = new Cliente();
            c.FechaUltimaInteraccion = DateTime.Now.AddDays(-10);
            Assert.IsTrue(c.esInactivo("5"), "Cliente debería estar inactivo");
            Assert.IsFalse(c.esInactivo("20"), "Cliente no debería estar inactivo");
        }

        [Test]
        public void AgregarEtiquetasYGet_Test()
        {
            Cliente c = new Cliente();
            c.agregarEtiqueta(new Etiqueta("VIP"));
            c.agregarEtiqueta(new Etiqueta("Premium"));

            List<Etiqueta> etiquetas = c.GetEtiquetas();
            Assert.AreEqual(2, etiquetas.Count, "Cliente debería tener 2 etiquetas");
        }

        // =============================
        // === TESTS DE FACHADA INTEGRADOS ===
        // =============================

        [Test]
        public void FlujoCompleto_Test()
        {
            // Usuario
            int idUsuario = fachada.RegistrarVendedor(true, DateTime.Now);
            Assert.IsTrue(fachada.ObtenerUsuarios().Exists(u => u.Id == idUsuario));

            // Cliente
            Cliente c = new Cliente("Lucia", "Rojas", "1111", "lucia@mail.com", "", "F", DateTime.Now.AddYears(-25), DateTime.Now);
            int idCliente = GestorClientes.Instancia.AgregarCliente(c.Nombre, c.Apellido, c.Email, c.Telefono);
            Assert.IsNotNull(GestorClientes.Instancia.ObtenerCliente(idCliente));

            // Interacción
            Interaccion inter = new Correo(DateTime.Now, "Correo prueba", "", false, "lucia@mail.com");
            c.AgregarInteraccion(inter);
            Assert.AreEqual(1, c.GetInteracciones().Count);

            // Etiqueta
            c.agregarEtiqueta(new Etiqueta("Importante"));
            Assert.AreEqual(1, c.GetEtiquetas().Count);

            // Venta
            Venta venta = new Venta(500, DateTime.Today, "Venta Flujo", "", false, "");
            fachada.RegistrarVenta(venta);
            List<Venta> ventas = fachada.ObtenerVentasEntre(DateTime.Today, DateTime.Today);
            Assert.AreEqual(1, ventas.Count);
        }
        
        
        
    }
     [TestFixture]
    public class HistoriasUsuarioTests
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {
            // Crear una nueva instancia de fachada antes de cada test
            fachada = new Fachada();
        }

        [Test]
        public void CrearNuevoCliente_Basico()
        {
            // Historia: Como usuario quiero crear un nuevo cliente con información básica
            int id = fachada.RegistrarCliente("Juan", "Perez", "juan@mail.com", "12345", "", "M", DateTime.Now.AddYears(-30));
            Cliente c = fachada.ObtenerCliente(id);
            Assert.IsNotNull(c, "El cliente debería haberse creado correctamente");
            Assert.AreEqual("Juan", c.Nombre);
            Assert.AreEqual("Perez", c.Apellido);
            Assert.AreEqual("12345", c.Telefono);
            Assert.AreEqual("juan@mail.com", c.Email);
        }

        [Test]
        public void ModificarInformacionCliente()
        {
            // Historia: Modificar información de un cliente existente
            int id = fachada.RegistrarCliente("Ana", "Lopez", "ana@mail.com", "54321", "", "F", DateTime.Now.AddYears(-25));
            bool actualizado = fachada.ActualizarClienteEmail(id, "ana.nuevo@mail.com");
            Cliente c = fachada.ObtenerCliente(id);
            Assert.IsTrue(actualizado, "El cliente debería haberse actualizado correctamente");
            Assert.AreEqual("ana.nuevo@mail.com", c.Email);
        }

        [Test]
        public void EliminarCliente()
        {
            // Historia: Eliminar un cliente
            int id = fachada.RegistrarCliente("Pedro", "Gomez", "pedro@mail.com", "98765", "", "M", DateTime.Now.AddYears(-40));
            bool eliminado = fachada.EliminarCliente(id);
            Cliente c = fachada.ObtenerCliente(id);
            Assert.IsTrue(eliminado, "El cliente debería haberse eliminado");
            Assert.IsNull(c, "El cliente ya no debería existir");
        }

        [Test]
        public void BuscarClientes_PorNombreApellidoTelefonoEmail()
        {
            // Historia: Buscar clientes por varios criterios
            int id1 = fachada.RegistrarCliente("Laura", "Martinez", "laura@mail.com", "11111", "", "F", DateTime.Now.AddYears(-28));
            int id2 = fachada.RegistrarCliente("Lucas", "Martinez", "lucas@mail.com", "22222", "", "M", DateTime.Now.AddYears(-32));
            
            List<Cliente> encontrados = fachada.BuscarClientesPorNombre("Laura");
            Assert.AreEqual(1, encontrados.Count, "Debería encontrar a Laura");
            
            encontrados = fachada.BuscarClientesPorApellido("Martinez");
            Assert.AreEqual(2, encontrados.Count, "Debería encontrar a los dos con apellido Martinez");
            
            encontrados = fachada.BuscarClientesPorTelefono("22222");
            Assert.AreEqual(1, encontrados.Count, "Debería encontrar a Lucas por teléfono");
            
            encontrados = fachada.BuscarClientesPorEmail("laura@mail.com");
            Assert.AreEqual(1, encontrados.Count, "Debería encontrar a Laura por email");
        }

        [Test]
        public void VerTodosLosClientes()
        {
            // Historia: Ver todos los clientes
            fachada.RegistrarCliente("Cliente1", "A", "c1@mail.com", "100", "", "M", DateTime.Now.AddYears(-20));
            fachada.RegistrarCliente("Cliente2", "B", "c2@mail.com", "200", "", "F", DateTime.Now.AddYears(-25));
            
            List<Cliente> clientes = fachada.ObtenerTodosClientes();
            Assert.AreEqual(2, clientes.Count, "Debería haber dos clientes en total");
        }

        [Test]
        public void RegistrarLlamadasReunionesMensajesCorreos()
        {
            // Historia: Registrar interacciones
            int idCliente = fachada.RegistrarCliente("Marcelo", "Diaz", "marcelo@mail.com", "33333", "", "M", DateTime.Now.AddYears(-35));

            int idLlamada = fachada.RegistrarInteraccion("llamada", DateTime.Now, "Tema Llamada", "Notas Llamada", true, "33333");
            int idReunion = fachada.RegistrarInteraccion("reunion", DateTime.Now, "Tema Reunion", "Notas Reunion", true, "Oficina");
            int idMensaje = fachada.RegistrarInteraccion("mensaje", DateTime.Now, "Tema Mensaje", "Notas Mensaje", false, "marcelo@mail.com");
            int idCorreo = fachada.RegistrarInteraccion("correo", DateTime.Now, "Tema Correo", "Notas Correo", false, "marcelo@mail.com");

            Assert.IsTrue(idLlamada > 0);
            Assert.IsTrue(idReunion > 0);
            Assert.IsTrue(idMensaje > 0);
            Assert.IsTrue(idCorreo > 0);
        }

        [Test]
        public void AgregarNotasInteracciones()
        {
            // Historia: Agregar notas a interacciones
            int id = fachada.RegistrarInteraccion("llamada", DateTime.Now, "Tema", "", false, "111");
            bool actualizado = fachada.AgregarNotasInteraccion(id, "Notas importantes");
            Interaccion inter = fachada.ObtenerInteraccion(id);
            Assert.IsTrue(actualizado, "Las notas deberían haberse agregado");
            Assert.AreEqual("Notas importantes", inter.Notas);
        }

        [Test]
        public void RegistrarDatosAdicionalesClientes()
        {
            // Historia: Registrar género y fecha de nacimiento
            int id = fachada.RegistrarCliente("Sofia", "Perez", "sofia@mail.com", "55555", "", "F", new DateTime(1990, 5, 1));
            Cliente c = fachada.ObtenerCliente(id);
            Assert.AreEqual("F", c.Genero);
            Assert.AreEqual(new DateTime(1990, 5, 1), c.FechaNacimiento);
        }

        [Test]
        public void DefinirYAgregarEtiquetasClientes()
        {
            // Historia: Etiquetas para clientes
            fachada.DefinirEtiqueta("VIP");
            int id = fachada.RegistrarCliente("Martin", "Lopez", "martin@mail.com", "77777", "", "M", DateTime.Now.AddYears(-27));
            bool agregado = fachada.AgregarEtiquetaCliente(id, "VIP");
            Cliente c = fachada.ObtenerCliente(id);
            Assert.IsTrue(agregado, "La etiqueta debería haberse agregado al cliente");
            Assert.Contains("VIP", c.Etiquetas);
        }

        [Test]
        public void RegistrarVentaYCotizacion()
        {
            // Historia: Registrar venta y cotización
            int idCliente = fachada.RegistrarCliente("Carlos", "Ramirez", "carlos@mail.com", "88888", "", "M", DateTime.Now.AddYears(-30));
            int idVenta = fachada.RegistrarVenta(idCliente, 500, DateTime.Now, "Venta producto A");
            int idCotizacion = fachada.RegistrarCotizacion(idCliente, 1000, DateTime.Now, "Cotizacion producto B");

            List<Venta> ventas = fachada.ObtenerVentasCliente(idCliente);
            List<Cotizacion> cotizaciones = fachada.ObtenerCotizacionesCliente(idCliente);

            Assert.AreEqual(1, ventas.Count);
            Assert.AreEqual(1, cotizaciones.Count);
        }

        [Test]
        public void VerInteraccionesClienteConFiltros()
        {
            // Historia: Ver interacciones de un cliente
            int idCliente = fachada.RegistrarCliente("Laura", "Fernandez", "laura@mail.com", "99999", "", "F", DateTime.Now.AddYears(-29));
            int id1 = fachada.RegistrarInteraccion("llamada", DateTime.Now.AddDays(-5), "Tema1", "", true, "99999");
            int id2 = fachada.RegistrarInteraccion("correo", DateTime.Now.AddDays(-1), "Tema2", "", false, "laura@mail.com");

            List<Interaccion> todas = fachada.ObtenerInteraccionesCliente(idCliente);
            List<Interaccion> filtradas = fachada.ObtenerInteraccionesCliente(idCliente, "correo");

            Assert.AreEqual(2, todas.Count, "Debería haber 2 interacciones");
            Assert.AreEqual(1, filtradas.Count, "Debería filtrar solo correos");
        }

        [Test]
        public void ClientesSinInteraccionesYNoRespondidos()
        {
            // Historia: clientes sin interacción y no respondidos
            int idCliente1 = fachada.RegistrarCliente("Cliente1", "A", "c1@mail.com", "11111", "", "M", DateTime.Now.AddYears(-30));
            int idCliente2 = fachada.RegistrarCliente("Cliente2", "B", "c2@mail.com", "22222", "", "F", DateTime.Now.AddYears(-25));

            // Agregamos una interacción solo a cliente2
            fachada.RegistrarInteraccion("llamada", DateTime.Now.AddDays(-10), "Tema", "", false, "22222");

            List<Cliente> sinInteracciones = fachada.ClientesSinInteracciones(7); // últimos 7 días
            List<Cliente> noRespondidos = fachada.ClientesNoRespondidos(7); // últimos 7 días

            Assert.Contains(fachada.ObtenerCliente(idCliente1), sinInteracciones);
            Assert.Contains(fachada.ObtenerCliente(idCliente2), noRespondidos);
        }

        [Test]
        public void AdministrarUsuarios()
        {
            // Historia: administrador crea, suspende y elimina usuarios
            int idUsuario = fachada.RegistrarAdministrador(true, DateTime.Now);
            bool actualizado = fachada.ActualizarUsuarioActivo(idUsuario, false);
            bool eliminado = fachada.EliminarUsuario(idUsuario);

            Assert.IsTrue(actualizado, "El usuario debería haberse suspendido");
            Assert.IsTrue(eliminado, "El usuario debería haberse eliminado");
        }

        [Test]
        public void AsignarClienteAVendedor()
        {
            // Historia: asignar un cliente a otro vendedor
            int idCliente = fachada.RegistrarCliente("ClienteX", "Y", "x@mail.com", "1234", "", "M", DateTime.Now.AddYears(-30));
            int idVendedor1 = fachada.RegistrarAdministrador(true, DateTime.Now);
            int idVendedor2 = fachada.RegistrarAdministrador(true, DateTime.Now);

            bool asignado = fachada.AsignarClienteAVendedor(idCliente, idVendedor2);
            Assert.IsTrue(asignado, "El cliente debería haber sido asignado al nuevo vendedor");
        }

        [Test]
        public void TotalVentasPeriodo()
        {
            // Historia: total de ventas en un periodo
            int idCliente = fachada.RegistrarCliente("ClienteVentas", "V", "ventas@mail.com", "55555", "", "F", DateTime.Now.AddYears(-28));
            fachada.RegistrarVenta(idCliente, 100, DateTime.Today.AddDays(-1), "Venta 1");
            fachada.RegistrarVenta(idCliente, 200, DateTime.Today, "Venta 2");

            decimal total = fachada.TotalVentasEntre(DateTime.Today.AddDays(-2), DateTime.Today);
            Assert.AreEqual(300, total, "El total de ventas debería ser 300");
        }

        [Test]
        public void PanelResumen()
        {
            // Historia: panel resumen
            int idCliente = fachada.RegistrarCliente("ClientePanel", "R", "panel@mail.com", "66666", "", "M", DateTime.Now.AddYears(-35));
            fachada.RegistrarInteraccion("llamada", DateTime.Now, "Tema Panel", "", true, "66666");

            var panel = fachada.ObtenerPanelResumen();
            Assert.IsTrue(panel.TotalClientes > 0, "Debería mostrar total de clientes");
            Assert.IsTrue(panel.InteraccionesRecientes.Count > 0, "Debería mostrar interacciones recientes");
        }
    }
}