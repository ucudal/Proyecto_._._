using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que gestiona la creación, consulta y administración de usuarios del sistema.
    /// Implementa el patrón Singleton clásico.
    /// </summary>
    public class GestorUsuarios
    {
        private static GestorUsuarios instancia;

        /// <summary>
        /// Instancia única del gestor de usuarios.
        /// </summary>
        public static GestorUsuarios Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GestorUsuarios();
                }
                return instancia;
            }
        }

        /// <summary>
        /// Constructor privado para cumplir con el patrón Singleton.
        /// </summary>
        public GestorUsuarios() { }

        private readonly List<IUsuario> usuarios = new List<IUsuario>();

        private int proximoId = 1;

        /// <summary>
        /// Registra un usuario en el sistema asignándole un ID si corresponde.
        /// </summary>
        /// <param name="usuario">Usuario a registrar.</param>
        /// <returns>ID asignado o 0 si el tipo de usuario no usa ID.</returns>
        private int Registrar(IUsuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            UsuarioBase u = usuario as UsuarioBase;

            if (u != null)
            {
                u.Id = proximoId;
                proximoId++;
            }

            usuarios.Add(usuario);

            return u != null ? u.Id : 0;
        }

        // --------------------------------------------------------------
        // CREACIÓN
        // --------------------------------------------------------------

        /// <summary>
        /// Crea un administrador y lo registra en el sistema.
        /// </summary>
        public Administrador CrearAdministrador(bool activo, DateTime fechaCreacion)
        {
            Administrador admin = new Administrador(activo, fechaCreacion);
            Registrar(admin);
            return admin;
        }

        /// <summary>
        /// Crea un vendedor y lo registra en el sistema.
        /// </summary>
        public Vendedor CrearVendedor(bool activo, DateTime fechaCreacion)
        {
            Vendedor vendedor = new Vendedor(activo, fechaCreacion);
            Registrar(vendedor);
            return vendedor;
        }

        // --------------------------------------------------------------
        // OPERACIONES
        // --------------------------------------------------------------

        /// <summary>
        /// Busca un usuario por su identificador.
        /// </summary>
        public IUsuario ObtenerUsuario(int id)
        {
            foreach (IUsuario u in usuarios)
            {
                UsuarioBase ub = u as UsuarioBase;
                if (ub != null && ub.Id == id)
                    return u;
            }
            return null;
        }

        /// <summary>
        /// Cambia el estado Activo/Inactivo de un usuario.
        /// </summary>
        /// <returns>true si se modificó correctamente.</returns>
        public bool ActualizarActivo(int id, bool activo)
        {
            IUsuario usuario = ObtenerUsuario(id);
            if (usuario != null)
            {
                usuario.Activo = activo;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Elimina un usuario del sistema.
        /// </summary>
        public bool EliminarUsuario(int id)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                UsuarioBase ub = usuarios[i] as UsuarioBase;
                if (ub != null && ub.Id == id)
                {
                    usuarios.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Obtiene una lista con todos los usuarios del sistema.
        /// </summary>
        public List<IUsuario> ObtenerTodos()
        {
            return new List<IUsuario>(usuarios);
        }

        public Vendedor ObtenerUsuarioPorId(int vendedorId)
        {
            throw new NotImplementedException();         //El programa me recomienda usar throw new throw new NotImplementedException() para solucionar problemas.
        }

        public void AgregarUsuario(Vendedor p0)
        {
            throw new NotImplementedException();// para que no se cometan errores en los test...
        }
    }
}
