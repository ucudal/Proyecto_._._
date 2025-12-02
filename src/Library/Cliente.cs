using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Representa un cliente dentro del sistema CRM.
    /// Contiene información personal, etiquetas, interacciones y un vendedor asignado.
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Identificador único del cliente.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del cliente.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Apellido del cliente.
        /// </summary>
        public string Apellido { get; set; } = string.Empty;

        /// <summary>
        /// Teléfono de contacto del cliente.
        /// </summary>
        public string Telefono { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico del cliente.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Observaciones adicionales sobre el cliente.
        /// </summary>
        public string Observaciones { get; set; } = string.Empty;

        /// <summary>
        /// Género del cliente.
        /// </summary>
        public string Genero { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de nacimiento del cliente.
        /// </summary>
        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Fecha de la última interacción registrada con el cliente.
        /// </summary>
        public DateTime FechaUltimaInteraccion { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Lista interna de etiquetas asociadas al cliente.
        /// </summary>
        private readonly List<Etiqueta> etiquetas = new List<Etiqueta>();

        /// <summary>
        /// Lista interna de interacciones asociadas al cliente.
        /// </summary>
        private readonly List<Interaccion> interacciones = new List<Interaccion>();

        /// <summary>
        /// Vendedor asignado al cliente. Puede ser nulo si no hay uno asignado.
        /// </summary>
        private IUsuario vendedorAsignado = null;

        /// <summary>
        /// Constructor por defecto.
        /// Inicializa la fecha de última interacción con la fecha actual.
        /// </summary>
        public Cliente()
        {
            FechaUltimaInteraccion = DateTime.Now;
        }

        /// <summary>
        /// Constructor completo del cliente.
        /// </summary>
        /// <param name="nombre">Nombre del cliente.</param>
        /// <param name="apellido">Apellido del cliente.</param>
        /// <param name="telefono">Teléfono de contacto.</param>
        /// <param name="email">Correo electrónico.</param>
        /// <param name="observaciones">Observaciones adicionales.</param>
        /// <param name="genero">Género del cliente.</param>
        /// <param name="fechaNacimiento">Fecha de nacimiento.</param>
        /// <param name="fechaUltimaInteraccion">Fecha de última interacción.</param>
        public Cliente(string nombre, string apellido, string telefono, string email,
                       string observaciones, string genero, DateTime fechaNacimiento, DateTime fechaUltimaInteraccion)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            Observaciones = observaciones;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            FechaUltimaInteraccion = fechaUltimaInteraccion;

            etiquetas = new List<Etiqueta>();
            interacciones = new List<Interaccion>();
        }

        /// <summary>
        /// Devuelve una copia de la lista de etiquetas del cliente.
        /// </summary>
        /// <returns>Lista de etiquetas.</returns>
        public List<Etiqueta> GetEtiquetas() => new List<Etiqueta>(etiquetas);

        /// <summary>
        /// Devuelve una copia de la lista de interacciones del cliente.
        /// </summary>
        /// <returns>Lista de interacciones.</returns>
        public List<Interaccion> GetInteracciones() => new List<Interaccion>(interacciones);

        /// <summary>
        /// Agrega una etiqueta al cliente.
        /// </summary>
        /// <param name="etiqueta">Etiqueta a agregar.</param>
        public void agregarEtiqueta(Etiqueta etiqueta)
        {
            if (etiqueta != null)
            {
                etiquetas.Add(etiqueta);
            }
        }

        /// <summary>
        /// Asigna un vendedor al cliente.
        /// </summary>
        /// <param name="usuario">Usuario vendedor a asignar.</param>
        public void asignarAVendedor(IUsuario usuario)
        {
            vendedorAsignado = usuario;
        }

        /// <summary>
        /// Devuelve una lista filtrada de interacciones según los parámetros dados.
        /// (Actualmente devuelve todas las interacciones sin filtrar.)
        /// </summary>
        /// <param name="filtro1">Primer criterio de filtro.</param>
        /// <param name="filtro2">Segundo criterio de filtro.</param>
        /// <param name="filtro3">Tercer criterio de filtro.</param>
        /// <returns>Lista filtrada de interacciones.</returns>
        public List<Interaccion> getInteraccionesFiltradas(string filtro1, string filtro2, string filtro3)
        {
            return new List<Interaccion>(interacciones);
        }

        /// <summary>
        /// Verifica si el cliente tiene alguna interacción pendiente de respuesta.
        /// </summary>
        /// <returns>True si existen interacciones sin respuesta, False en caso contrario.</returns>
        public bool tieneInteraccionesSinRespuesta()
        {
            foreach (var i in interacciones)
            {
                if (i != null && !i.Respondida)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determina si el cliente se considera inactivo según la cantidad de días especificada.
        /// </summary>
        /// <param name="dias">Cantidad de días de inactividad.</param>
        /// <returns>True si supera el umbral, False en caso contrario.</returns>
        public bool esInactivo(string dias)
        {
            int d;
            if (!int.TryParse(dias, out d))
                return false;

            return (DateTime.Now - FechaUltimaInteraccion).TotalDays >= d;
        }

        /// <summary>
        /// Agrega una nueva interacción al cliente y actualiza la fecha de última interacción.
        /// </summary>
        /// <param name="interaccion">Interacción a agregar.</param>
        public void AgregarInteraccion(Interaccion interaccion)
        {
            if (interaccion != null)
            {
                interacciones.Add(interaccion);
                FechaUltimaInteraccion = interaccion.Fecha;
            }
        }
    }
}
