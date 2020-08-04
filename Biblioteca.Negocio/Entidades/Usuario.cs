 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace Biblioteca.Negocio.Entidades
{
    public abstract class Usuario 
    {
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string Correo { get; set; }
        public string Telefono{ get; set; } 
        
        protected string Saludo()
        {
            return $"Bienvenido al sistema {this.PrimerNombre} {this.PrimerApellido}.";
        }

        protected string Despedida()
        {
            return $"Vuelve pronto {this.PrimerNombre} {this.PrimerApellido}.";
        }


    }

}
