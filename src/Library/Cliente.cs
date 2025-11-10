using System;
using System.Collections.Generic;
namespace Library
{
   public class Cliente
    {
        private string nombre;                      
        private string apellido;                    
        private string telefono;                    
        private string email;                       
        private string observaciones;               
        private string genero;                      
        private DateTime fechaNacimiento;           
        private DateTime fechaUltimaInteraccion;    

        private List<Etiqueta> etiquetas = new List<Etiqueta>();
        private List<Interaccion> interacciones = new List<Interaccion>();
        private IUsuario vendedorAsignado = null;

        public Cliente(string nombre, string apellido, string telefono, string email,
                       string observaciones, string genero, DateTime fechaNacimiento, DateTime fechaUltimaInteraccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.email = email;
            this.observaciones = observaciones;
            this.genero = genero;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaUltimaInteraccion = fechaUltimaInteraccion;
        }

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

        public List<Interaccion> getInteraccionesFiltradas(string filtro1, string filtro2, string filtro3)
        {
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

            return (DateTime.Now - fechaUltimaInteraccion).TotalDays >= d;
        }
    }
}