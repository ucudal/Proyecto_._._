namespace Library
{
    /// <summary>
    /// Representa una etiqueta del sistema.
    /// </summary>
    public class Etiqueta
    {
        /// <summary>
        /// Nombre de la etiqueta.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Constructor sin parámetros requerido por la fachada.
        /// </summary>
        public Etiqueta() { }

        /// <summary>
        /// Constructor que inicializa la etiqueta con un nombre dado.
        /// </summary>
        /// <param name="nombre">Nombre de la etiqueta.</param>
        public Etiqueta(string nombre)
        {
            Nombre = nombre;
        }
    }
}