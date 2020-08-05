using Biblioteca.Negocio.Entidades;

namespace Biblioteca.Negocio.Entidades
{
    public class PrestamoLibros
    {
        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
    }
}
