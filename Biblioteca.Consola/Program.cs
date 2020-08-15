
using Biblioteca.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            Libro libroDos = new Libro { Codigo = 2021, Titulo = "HP", Editorial = "Salambra", Autor = "JKR" };
            Libro libroTres = new Libro { Codigo = 2022, Titulo = "HP", Editorial = "Salambra", Autor = "JKR" };

            Bibliotecario biblio = new Bibliotecario { PrimerNombre = "Fercho", PrimerApellido = "Perez", Correo = "fp@.copm", Telefono = "0992563584" };
            Bibliotecario biblio1 = new Bibliotecario { PrimerNombre = "Fercho1", PrimerApellido = "Perez", Correo = "fp@.copm", Telefono = "0992563584" };
            Bibliotecario biblio2 = new Bibliotecario { PrimerNombre = "Fercho2", PrimerApellido = "Perez", Correo = "fp@.copm", Telefono = "0992563584" };

            biblioteca.AñadirBibliotecario(biblio);
            biblioteca.AñadirBibliotecario(biblio1);
            biblioteca.AñadirBibliotecario(biblio2);

            //Aplicacion de paralelismo
            Console.WriteLine("Lista de bibliotecarios");

            List<Bibliotecario> bibliotecarios = biblioteca.Bibliotecarios;

            string resultado;

            Parallel.ForEach(bibliotecarios, (biblo) =>
            {
                resultado = biblo.PrimerNombre;
                Console.WriteLine($"Nombre: {resultado}");
            });


            Lector lector = new Lector { PrimerNombre = "Ricardo", PrimerApellido = "Yaguachi", Correo = "r@r.com", Telefono = "0992563584", TipoLector = "Fanatico", Preferencias = "Aventura" };

            Console.WriteLine(biblioteca.MostrarSaludo(biblio));

            Prestamo prestamo = new Prestamo {
                Codigo = "Pres-001",
                Fecha = new DateTime(2020,08,04),
                Lector = lector,
                BibliotecarioId = biblio.BibliotecarioId,
                Bibliotecario = biblio,
                BibliotecId = biblioteca.Id
            };

            string avisoPrestamo = prestamo.Prestar(prestamo,libroUno);

            Console.WriteLine($"{avisoPrestamo} fue prestado a {lector.PrimerNombre} {lector.PrimerApellido}. atendido por : {biblio.PrimerNombre} {biblio.PrimerApellido}");
            Console.WriteLine($"Hay {Prestamo.PrestamosHechos} prestamos hechos");

            Console.Write("");

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
