using Biblioteca.Interface;
using Biblioteca.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Negocio.Entidades
{
    public class Bibliotecario : Usuario, IBibliotecario, IPersona
    {
        public Bibliotecario(string nombre, string apellido, string email, string telefono, string tipoLector, string preferencia)
        {
            base.PrimerNombre = nombre;
            base.PrimerApellido = apellido;
            base.Correo = email;
            base.Telefono = telefono;
        }
        public Bibliotecario()
        {

        }

        public new int Id { get; set; }

        public void AñadirPrestamo(Prestamo prestamo, Bibliotec biblioteca)
        {
            biblioteca.Prestamos.Add(prestamo);
        }
        public void AñadirDevolucion(Prestamo prestamo, Devolucion devolucion,Bibliotec biblioteca)
        {
            
            biblioteca.Prestamos.Remove(prestamo);
            biblioteca.Devoluciones.Add(devolucion);
        }

        public override string Saludo()
        {
            return $"Hola mi nombre es: {base.PrimerNombre} {base.PrimerApellido} estoy a tu disposición";
        }
        public override string Despedida()
        {
            return $"Vuelve pronto {base.PrimerNombre} {base.PrimerApellido}.";
        }
    }
}
