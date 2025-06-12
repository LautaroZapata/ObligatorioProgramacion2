using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pasaje : IComparable<Pasaje>
    {
        int id;
        static int ultimoId;
        Vuelo vuelo;
        DateTime fecha;
        Cliente pasajero;
        Equipaje equipaje;
        decimal precio;
        public static int orden = 0;




        public static int Orden { get => orden; set => orden = value; }
        public int Id { get => id; set => id = value; }
        public static int UltimoId { get => ultimoId; set => ultimoId = value; }
        public Vuelo Vuelo { get => vuelo; set => vuelo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Cliente Pasajero { get => pasajero; set => pasajero = value; }
        public Equipaje Equipaje { get => equipaje; set => equipaje = value; }
        public decimal Precio { get => precio; set => precio = value; }

        public Pasaje(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje, decimal precio)
        {
            Id = ++ultimoId;
            Vuelo = vuelo;
            Fecha = fecha;
            Pasajero = pasajero;
            Equipaje = equipaje;
            Precio = precio;
        }

        public Pasaje()
        {
            Id = ++ultimoId;
        }

        public void Validar()
        {
            ValidarFechaConFrecuencia();
            // Son metodos para la segunda entrega.
            //ValidarEquipaje(); 
            //ValidarPrecio();
        }

        private void ValidarFechaConFrecuencia()
        {
             if (!Vuelo.Frecuencia.Contains(Fecha.DayOfWeek)) throw new Exception("La fecha no coincide con el vuelo.");
        }

        public override string ToString()
        {
            return $"Id: {Id} , Nombre: {Pasajero.Nombre} , Precio: {Precio} , Fecha: {Fecha} , NroVuelo {Vuelo.NroVuelo} \n ";
            ;
        }
        /*
         Se compara otro.Precio primero contra this.Precio ya que la lista debe ser retornada en orden Descendente, si fuera al reves iria this.Precio primero
         */
        public int CompareTo(Pasaje otro)
        {
            if (otro == null) return 1;
            if (Orden == 0) // 0 es cliente
            {
                return otro.Precio.CompareTo(this.Precio);
            } else
            {
                return Fecha.CompareTo(otro.Fecha);

            }

        }

       

    }

    /*
    Creamos esta clase especifica para poder realizar el sort con criterios diferentes y poder realizar los ordenamientos 
    correspondientes de la misma clase 
    */
    //public class CompareToPorFecha : IComparer<Pasaje>
    //{
    //    private DateTime fecha;
        
    //    public DateTime Fecha { get => fecha; set => fecha = value; }
        
    //    public int Compare(Pasaje? pasaje1, Pasaje? pasaje2)
    //    {
    //        if (pasaje1 == null || pasaje2 == null ) return 1;
    //        return pasaje1.Fecha.CompareTo(pasaje2.Fecha);
    //    }
    //}
   

}
