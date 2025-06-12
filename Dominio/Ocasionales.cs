using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ocasionales : Cliente , IValidable
    {
        static Random random = new Random();
        bool elegible;


        public bool Elegible { get => elegible; set => elegible = value; }

        public Ocasionales()
        {
        }

        public Ocasionales(string documento, string nombre, string nacionalidad, string mail, string password) : base(documento, nombre, nacionalidad, mail, password)
        {
            Elegible = random.Next(0, 2) == 1; // Agarra un numero entre 0 y 2  [0,1], si da 1 es true si da 0 es false.
        }

        public  void Validar()
        {
            base.Validar();
        }

        private string EsElegible()
        {
            if (Elegible) return "Si";
            return "No";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Es Elegible: {EsElegible()}, Tipo de cliente: Ocasional \n";
        }

        public override decimal CalcularPrecioPasaje(Equipaje equipaje, Vuelo vuelo)
        {
            decimal precio = vuelo.CalcularMargenGanancia();
            if(equipaje == Equipaje.CABINA)
            {
                precio *= 1.1m;
            }
            if(equipaje == Equipaje.BODEGA)
            {
                precio *= 1.2m;
            }
            return precio;
        }


    }
}
