using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Negocio.Entidades
{
    public abstract class Persona
    {

        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public virtual string Saludo()
        {
            return $"Bienvenido al sistema {this.PrimerNombre} {this.PrimerApellido}.";
        }

        public virtual string Despedida(string nombre, string apellido)
        {
            return $"Vuelve pronto {nombre} {apellido}.";
        }

        public virtual string Despedida()
        {
            return $"Vuelve pronto te esperamos";
        }


    }
}
