using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vuelo
    {
        string nroVuelo;
        Ruta ruta;
        Avion avion;
        List<DayOfWeek> frecuencia = new List<DayOfWeek>();
        List<Pasaje> pasajes = new List<Pasaje>();


        public string NroVuelo { get => nroVuelo; set => nroVuelo = value; }
        public Ruta Ruta { get => ruta; set => ruta = value; }
        public Avion Avion { get => avion; set => avion = value; }
        public List<DayOfWeek> Frecuencia { get => frecuencia; set => frecuencia = value; }
        public List<Pasaje> Pasajes { get => pasajes; set => pasajes = value; }

        public Vuelo()
        {
        }

        public Vuelo(string nroVuelo, Ruta ruta, Avion avion, List<DayOfWeek> frecuencia)
        {
            NroVuelo = nroVuelo;
            Ruta = ruta;
            Avion = avion;
            Frecuencia = frecuencia;
        }

        public void Validar()
        {
            ValidarNroVuelo();
            ValidarAlcance();
            TieneFrecuencia();
        }

        private void ValidarNroVuelo() 
        {
            if (nroVuelo.Length > 6) throw new Exception("El numero de vuelo no puede ser mayor a 6 caracteres.");
            if (string.IsNullOrEmpty(nroVuelo)) throw new Exception("El numero de vuelo no puede ser vacio");
            int cantLetras = 0;
            int cantNumeros = 0;
            foreach (char c in nroVuelo)
            {
                if (char.IsLetter(c))
                    cantLetras++;
                else if (char.IsNumber(c))
                    cantNumeros++;
                else
                    throw new Exception("El número de vuelo solo puede contener letras y números");
            }
            if (cantLetras != 2) throw new Exception("El numero de vuelo tiene que tener 2 letras");
            if (cantNumeros < 1 || cantNumeros > 4) throw new Exception("La cantidad de numeros del vuelo tiene que ser entre 1 y 4");
        }

        private void ValidarAlcance()
        {
            if (avion.Alcance < ruta.Distancia) throw new Exception("El avion no tiene el suficiente alcance para cubrir la distancia a la ruta");
        }

        private void TieneFrecuencia()
        {
            if (frecuencia.Count == 0) throw new Exception("La frecuencia del vuelo debe ser como minimo 1 vez a la semana.");
        }

        private string MostrarFrecuencia()
        {
            string dias = "";
            foreach (DayOfWeek dia in Frecuencia)
            {
                dias += $"{dia}, ";
            }
            return dias;
        }

        public override string ToString()
        {
            return $"{NroVuelo} , {Avion}, {Ruta}, {MostrarFrecuencia()} \n";
        }

        public decimal CalcularCostoPorAsiento()
        {
            return (this.Avion.DevolverCostoOperacion() * this.Ruta.DevolverDistancia() + this.Ruta.DevolverCostoOperacionAeropuertos()) / this.Avion.DevolverCantAsientos();
        }
        public decimal CalcularMargenGanancia()
        {
            return CalcularCostoPorAsiento() * 1.25m; //Margen de ganancia 25%
        }


    }
}
