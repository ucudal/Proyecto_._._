using System;
using System.Collections.Generic;
namespace Library
{
    public class Vendedor : IUsuario
    {
        // Propiedad que indica si el vendedor está activo o no
        public bool Activo { get; set; }

        // Fecha en la que se creó o registró el vendedor
        public DateTime FechaCreacion { get; set; }

        // Constructor que inicializa los valores de activo y fecha de creación
        public Vendedor(bool activo, DateTime fechaCreacion)
        {
            Activo = activo;
            FechaCreacion = fechaCreacion;
        }

        // Método que devuelve la lista de clientes asignados al vendedor
        // Por ahora devuelve una lista vacía
        public List<Cliente> getClientesAsignados()
        {
            return new List<Cliente>();
        }
    }

}
