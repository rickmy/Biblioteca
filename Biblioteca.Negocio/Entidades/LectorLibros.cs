using Biblioteca.Negocio.Entidades;

namespace Biblioteca.Negocio.Entidades
{
    public class LectorLibros
    {

        public int LectorId { get; set; }
        public Lector Lector { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
    }
}
