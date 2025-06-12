using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Avion
    {
        string fabricante;
        string modelo;
        int cantAsientos;
        int alcance;
        decimal costoOperacionKm;

        public string Fabricante { get => fabricante; set => fabricante = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int CantAsientos { get => cantAsientos; set => cantAsientos = value; }
        public int Alcance { get => alcance; set => alcance = value; }
        public decimal CostoOperacionKm { get => costoOperacionKm; set => costoOperacionKm = value; }

        public Avion()
        {
        }

        public Avion(string fabricante, string modelo, int cantAsientos, int alcance, decimal costoOperacionKm)
        {
            Fabricante = fabricante;
            Modelo = modelo;
            CantAsientos = cantAsientos;
            Alcance = alcance;
            CostoOperacionKm = costoOperacionKm;
        }

        public void Validar()
        {
            ValidarFabricante();
            ValidarModelo();
            ValidarAsientos();
            ValidarAlcance();
            //CostoOperacionKm; Se realiza en la segunda entrega.
        }

        private void ValidarFabricante()
        {
            if (string.IsNullOrEmpty(Fabricante)) throw new Exception("El fabricante no puede ser vacio");
        }

        private void ValidarModelo()
        {
            if (string.IsNullOrEmpty(Modelo)) throw new Exception("El modelo no puede ser vacio");
        }

        private void ValidarAsientos()
        {
            if (CantAsientos < 1 ) throw new Exception("La cantidad de asientos no puede ser menor a 1");
        }
        private void ValidarAlcance()
        {
            if (Alcance < 1) throw new Exception("El alcance del avion no puede ser menor a 1KM");
        }

        public override string ToString()
        {
            return $"{Modelo}";
        }
        public decimal DevolverCostoOperacion()
        {
            return costoOperacionKm;
        } 
        public int DevolverCantAsientos()
        {
            return cantAsientos;
        }
    }
}
