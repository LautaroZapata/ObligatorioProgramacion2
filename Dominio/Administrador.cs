using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Administrador : Usuario , IValidable
    {
        string apodo;
        string mail;
        string password;

        public string Apodo { get => apodo; set => apodo = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }

        public Administrador()
        {
        }

        public Administrador(string apodo, string mail, string password) : base ( mail,  password)
        {
            Apodo = apodo;
            Mail = mail;
            Password = password;
        }

        public void Validar()
        {
            base.Validar();
            if (string.IsNullOrEmpty(Apodo)) throw new Exception("El apodo no puede ser vacio");
        }

        
    }
}
