using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Aeropuerto
    {
        string codigoIata;
        string ciudad;
        decimal costoOperacion;
        decimal costoTasas;

        public string CodigoIata { get => codigoIata; set => codigoIata = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public decimal CostoOperacion { get => costoOperacion; set => costoOperacion = value; }
        public decimal CostoTasas { get => costoTasas; set => costoTasas = value; }

        public Aeropuerto(string codigoIata, string ciudad, decimal costoOperacion, decimal costoTasas)
        {
            CodigoIata = codigoIata;
            Ciudad = ciudad;
            CostoOperacion = costoOperacion;
            CostoTasas = costoTasas;
        }

        public Aeropuerto()
        {
        }

        public void Validar()
        {
            ValidarCodigoIata(CodigoIata);
            ValidarCiudad();
        }

        private void ValidarCodigoIata(string codigoIata)
        {
            if (string.IsNullOrEmpty(codigoIata)) throw new Exception("El codigo IATA no puede ser vacio");
            if (codigoIata.Length != 3) throw new Exception("El codigo IATA debe ser de 3 letras");
            foreach (char letra in codigoIata)
            {
                if (!char.IsLetter(letra))
                    throw new Exception("El código IATA solo puede contener letras");
            }
        }
        private void ValidarCiudad()
        {
            if (string.IsNullOrEmpty(Ciudad)) throw new Exception("La ciudad no puede ser vacia");
        }
        public override bool Equals(object? obj)
        {
            return obj is Aeropuerto aeropuerto && this.ciudad == aeropuerto.Ciudad;
        }

        public override string ToString()
        {
            return $"{CodigoIata}";
            ;
        }
    }
}
