using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Cliente : Usuario , IValidable
    {
        string documento;
        string nombre;
        string nacionalidad;

        public string Documento { get => documento; set => documento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public Cliente()
        {
        }

        public Cliente(string documento, string nombre, string nacionalidad, string mail, string password) : base(mail,password)
        {
            Documento = documento;
            Nombre = nombre;
            Nacionalidad = nacionalidad;
        }

        public void Validar()
        {
            base.Validar();
            if (string.IsNullOrEmpty(Documento)) throw new Exception("El documento no puede ser vacio");
            if(string.IsNullOrEmpty(Nombre)) throw new Exception("El nombre no puede ser vacio");
            if (string.IsNullOrEmpty(Nacionalidad)) throw new Exception("La nacionalidad no puede ser vacia");
            if (Documento.Length != 8) throw new Exception("El documento debe tener 8 numeros");

        }
        public override string ToString()
        {
            return $"{Nombre} , {Mail} , {Password} , {Documento} , {Nacionalidad}";
        }

        public virtual decimal CalcularPrecioPasaje(Equipaje equipaje, Vuelo vuelo)
        {
            return vuelo.CalcularMargenGanancia();
        }

        
    }
}
