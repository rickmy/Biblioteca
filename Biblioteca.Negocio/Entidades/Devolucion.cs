using System;

namespace Biblioteca.Negocio.Entidades
{
    public class Devolucion
    {
        public int DevolucionId { get; set; }
        public string Codigo { get; set; }
        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; }
        public DateTime Fecha { get; set; }
        public int BibliotecId { get; set; }
        public Bibliotec Bibliotec { get; set; }
        public int BibliotecarioId { get; set; }
        public Bibliotecario Bibliotecario { get; set; }
        public static int DevolucionesHechas { get; set; }

        public string Devolver(Prestamo prestamo, Libro libro)

        {
            

            prestamo.PrestamoLibros.Remove(new PrestamoLibros
            {
                Prestamo = prestamo,
                Libro = libro
            });

            DevolucionesHechas++;

            return $"La devoluvión con codigo {this.Codigo} el libro {libro.Titulo}";
        }
    }
}