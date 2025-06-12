using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{ 
    public abstract class Usuario : IValidable
    {
        
        string mail;
        string password;

        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
        public Usuario()
        {

        }
         public Usuario(string mail, string password)
        {
            Mail = mail;
            Password = password;
        }


        public void Validar()
        {
            if (string.IsNullOrEmpty(Mail)) throw new Exception("El mail es obligatorio");
            if (string.IsNullOrEmpty(Password)) throw new Exception("La contraseña es obligatoria");
            if (Password.Length <= 7)  throw new Exception("La contraseña debe tener minimo 8 caracteres");

        }

        public override bool Equals(object? obj)
        {
            return obj is Usuario unUser && unUser.Mail == Mail;
        }


    }
}
