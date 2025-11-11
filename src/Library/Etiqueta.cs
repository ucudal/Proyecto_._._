namespace Library
{
    /// <summary>
    /// Representa una etiqueta que puede asociarse a clientes u otros elementos del sistema.
    /// </summary>
    public class Etiqueta
    {
        /// <summary>
        /// Nombre de la etiqueta.
        /// </summary>
        private string nombre;

        /// <summary>
        /// Constructor que inicializa la etiqueta con un nombre.
        /// </summary>
        /// <param name="nombre">Nombre de la etiqueta.</param>
        public Etiqueta(string nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Devuelve el nombre de la etiqueta.
        /// </summary>
        /// <returns>Nombre de la etiqueta.</returns>
        public string ObtenerNombre()
        {
            return nombre;
        }
    }
}