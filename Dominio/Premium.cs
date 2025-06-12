using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Premium : Cliente, IValidable
    {
        int puntos;

        public int Puntos { get => puntos; set => puntos = value; }

        public Premium()
        {
        }

        public Premium(int puntos, string documento, string nombre, string mail, string password, string nacionalidad ): base(documento, nombre, nacionalidad, mail, password )
        {
            Puntos = puntos;
        }

        public  void Validar()
        {
            base.Validar();
            if (Puntos < 0) throw new Exception("Los puntos no pueden ser menor a 0");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {Puntos} Tipo de cliente: Premium \n";
        }

        public override decimal CalcularPrecioPasaje(Equipaje equipaje, Vuelo vuelo)
        {
            decimal precio = vuelo.CalcularMargenGanancia();
            if (equipaje == Equipaje.BODEGA)
            {
                precio *= 1.05m;
            }
            return precio;
        }
    }
}
