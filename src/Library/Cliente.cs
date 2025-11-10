// Cliente.cs
using System;
using System.Collections.Generic;

namespace Library
{
    public class Cliente
    {
        // Propiedades públicas (para que GestorClientes pueda asignarlas)
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;
        public DateTime FechaUltimaInteraccion { get; set; } = DateTime.MinValue;

        // Colecciones internas
        private readonly List<Etiqueta> etiquetas = new List<Etiqueta>();
        private readonly List<Interaccion> interacciones = new List<Interaccion>();

        // Vendedor asignado (puede ser null)
        private IUsuario vendedorAsignado = null;

        // Constructor por defecto (necesario para GestorClientes.AgregarCliente)
        public Cliente()
        {
            FechaUltimaInteraccion = DateTime.Now;
        }

        // Constructor completo (ya existente, mantenido)
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

        // Exponer copia de listas para lectura segura desde fuera
        public List<Etiqueta> GetEtiquetas() => new List<Etiqueta>(etiquetas);
        public List<Interaccion> GetInteracciones() => new List<Interaccion>(interacciones);

        public void agregarEtiqueta(Etiqueta etiqueta)
        {
            if (etiqueta != null)
            {
                etiquetas.Add(etiqueta);
            }
        }

        public void asignarAVendedor(IUsuario usuario)
        {
            vendedorAsignado = usuario;
        }

        // Si necesitás filtrar interacciones, implementar la lógica aquí
        public List<Interaccion> getInteraccionesFiltradas(string filtro1, string filtro2, string filtro3)
        {
            // Por ahora devuelve una copia de todas las interacciones (puedes implementar filtros reales)
            return new List<Interaccion>(interacciones);
        }

        public bool tieneInteraccionesSinRespuesta()
        {
            foreach (var i in interacciones)
            {
                if (i != null && !i.Respondida)
                    return true;
            }
            return false;
        }

        public bool esInactivo(string dias)
        {
            int d;
            if (!int.TryParse(dias, out d))
                return false;

            return (DateTime.Now - FechaUltimaInteraccion).TotalDays >= d;
        }

        // Métodos auxiliares para agregar interacciones desde fuera
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
