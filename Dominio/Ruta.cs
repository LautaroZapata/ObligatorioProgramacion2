using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ruta
    {
        int id;
        static int ultimoId;
        Aeropuerto aeropuertoSalida;
        Aeropuerto aeropuertoLlegada;
        int distancia;

        public int Id { get => id; set => id = value; }
        public static int UltimoId { get => ultimoId; set => ultimoId = value; }
        public Aeropuerto AeropuertoSalida { get => aeropuertoSalida; set => aeropuertoSalida = value; }
        public Aeropuerto AeropuertoLlegada { get => aeropuertoLlegada; set => aeropuertoLlegada = value; }
        public int Distancia { get => distancia; set => distancia = value; }

        public Ruta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada, int distancia)
        {
            Id = ++ultimoId;
            AeropuertoSalida = aeropuertoSalida;
            AeropuertoLlegada = aeropuertoLlegada;
            Distancia = distancia;
        }

        public Ruta()
        {
            Id = ++ultimoId;
        }

        public void Validar()
        {
            ValidarDistancia();
            ValidarAeropuertos();
        }


        private void ValidarDistancia()
        {
            if (Distancia < 1) throw new Exception("La distancia de la ruta debe ser mayor a 1KM");
        }
        private void ValidarAeropuertos()
        {
            if (AeropuertoSalida.Equals(AeropuertoLlegada)) throw new Exception("El aeropuerto de salida no puede ser igual al de llegada");
        }

        public override string ToString()
        {
            return $"{AeropuertoSalida} - {AeropuertoLlegada}";
        }

        public int DevolverDistancia()
        {
            return distancia;
        }

        public decimal DevolverCostoOperacionAeropuertos()
        {
            return AeropuertoSalida.CostoOperacion + AeropuertoLlegada.CostoOperacion;
        }

    }
}
