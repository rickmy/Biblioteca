
using Biblioteca.Negocio.Entidades;
using System;

namespace Biblioteca.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Bibliotec biblioteca = new Bibliotec {
                Nombre ="Biblioteca '23 de mayo'",
                Direccion = "Av Ernesto Alban"
            };

            Console.WriteLine(biblioteca.Saludo());

            Libro libroUno = new Libro { Codigo = 2020, Titulo = "HP", Editorial = "Salambra", Autor = "JKR" };

            Bibliotecario biblio = new Bibliotecario { PrimerNombre = "Fercho", PrimerApellido = "Perez", Correo = "fp@.copm", Telefono = "0992563584" };

            Lector lector = new Lector { PrimerNombre = "Ricardo", PrimerApellido = "Yaguachi", Correo = "r@r.com", Telefono = "0992563584", TipoLector = "Fanatico", Preferencias = "Aventura" };

            Console.WriteLine(biblioteca.MostrarSaludo(biblio));

            Prestamo prestamo = new Prestamo {
                Codigo = "Pres-001",
                Fecha = new DateTime(2020,08,04),
                Lector = lector,
                BibliotecarioId = biblio.BibliotecarioId,
                BibliotecId = biblioteca.Id
            };

            string avisoPrestamo = prestamo.Prestar(prestamo,libroUno);

            Console.WriteLine($"{avisoPrestamo} fue prestado a {lector.PrimerNombre} {lector.PrimerApellido}. atendido por : {biblio.PrimerNombre} {biblio.PrimerApellido}");
            Console.WriteLine($"Hay {Prestamo.PrestamosHechos} prestamos hechos");
            //Console.WriteLine($"Detalle del prestamo: {prestamo.BibliotecId}");

            Devolucion devolucion = new Devolucion {
                Codigo = "Devo-001",
                Fecha = new DateTime(2020, 08, 04),
                BibliotecarioId = biblio.BibliotecarioId ,
                BibliotecId = biblioteca.Id
            };

            string avisoDevolucion = devolucion.Devolver(prestamo, libroUno);
            Console.WriteLine($"{avisoDevolucion} fue prestado a {lector.PrimerNombre} {lector.PrimerApellido}. atendido por : {biblio.PrimerNombre} {biblio.PrimerApellido}");
            Console.WriteLine($"Hay {Devolucion.DevolucionesHechas} devoluciones realizadas");


        }
    }
}
