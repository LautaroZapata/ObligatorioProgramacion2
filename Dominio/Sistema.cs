using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private static Sistema instancia;

        List<Avion> listaAviones = new List<Avion>();
        List<Usuario> listaUsuarios = new List<Usuario>();
        List<Aeropuerto> listaAeropuertos = new List<Aeropuerto>();
        List<Ruta> listaRutas = new List<Ruta>();
        List<Vuelo> listaVuelos = new List<Vuelo>();
        List<Pasaje>listaPasajes = new List<Pasaje>();  

        public static Sistema Instancia
        {
            get
            {
                if (instancia == null) instancia = new Sistema();
                return instancia;
            }
        }
        private Sistema() 
        {
            PrecargaDatos();
        }

        public void PrecargaDatos()
        {
            // Puede que existan diferencias a los prompts de la documentación ya que la IA cometía errores en la generación de los datos. Por lo que corregimos manualmente algunas precargas.

            #region PrecargaUsuarios
            AgregarUsuario(new Administrador("admin1","admin1@correo.com", "Admin123"));
            AgregarUsuario(new Administrador("admin2","admin2@correo.com", "Admin1234"));
            AgregarUsuario(new Premium(1000, "50506264", "Lautaro", "oratualzc@gmail.com", "12345678", "Uruguayo"));
            AgregarUsuario(new Premium(200, "60458216", "Valentina", "valen.rios@example.com", "pass1234", "Uruguaya"));
            AgregarUsuario(new Premium(330, "71234907", "Diego", "diegomez@example.com", "abcd5678", "Argentino"));
            AgregarUsuario(new Premium(1200, "83920148", "Camila", "camila.silva@example.com", "qwerty789", "Chilena"));
            AgregarUsuario(new Premium(0, "91563020", "Felipe", "felipe.travels@example.com", "travel2025", "Paraguayo"));

            AgregarUsuario(new Ocasionales("91563027", "Felipe", "Paraguayo", "felipe.travelz@example.com", "travel1025"));
            AgregarUsuario(new Ocasionales("82341074", "Lucía", "Uruguaya", "lucia.mendez@example.com", "lucia321"));
            AgregarUsuario(new Ocasionales("73429812", "Marcos", "Chileno", "marcos.viaja@example.com", "marcos123"));
            AgregarUsuario(new Ocasionales("61827341", "Sofía", "Argentina", "sofia.ruta@example.com", "sofiaviaje"));
            AgregarUsuario(new Ocasionales("70291561", "Joaquín", "Peruano", "joaquin.aventura@example.com", "joaquin456"));




            #endregion
            #region PrecargaAeropuertos
            AgregarAeropuerto("MVD", "Montevideo", 1500.00m, 500.00m);
            AgregarAeropuerto("EZE", "Buenos Aires - Ezeiza", 1800.00m, 600.00m);
            AgregarAeropuerto("AEP", "Buenos Aires - Aeroparque", 1700.00m, 550.00m);
            AgregarAeropuerto("PDP", "Punta del Este", 1200.00m, 400.00m);
            AgregarAeropuerto("GRU", "São Paulo", 2000.00m, 700.00m);
            AgregarAeropuerto("SCL", "Santiago de Chile", 1900.00m, 650.00m);
            AgregarAeropuerto("LIM", "Lima", 2100.00m, 750.00m);
            AgregarAeropuerto("ASU", "Asunción", 1600.00m, 500.00m);
            AgregarAeropuerto("MIA", "Miami", 3000.00m, 1000.00m);
            AgregarAeropuerto("JFK", "Nueva York", 3500.00m, 1200.00m);
            AgregarAeropuerto("MAD", "Madrid", 3200.00m, 1100.00m);
            AgregarAeropuerto("BCN", "Barcelona", 3100.00m, 1050.00m);
            AgregarAeropuerto("LAX", "Los Ángeles", 3600.00m, 1250.00m);
            AgregarAeropuerto("DXB", "Dubái", 4000.00m, 1400.00m);
            AgregarAeropuerto("PEK", "Pekín", 4200.00m, 1500.00m);
            AgregarAeropuerto("COR", "Córdoba", 1550.00m, 480.00m);
            AgregarAeropuerto("MDZ", "Mendoza", 1580.00m, 500.00m);
            AgregarAeropuerto("CYD", "Colonia del Sacramento", 1100.00m, 390.00m);
            AgregarAeropuerto("SJO", "Salto", 1150.00m, 410.00m);
            AgregarAeropuerto("RIO", "Río de Janeiro", 1950.00m, 670.00m);
            #endregion
            #region PrecargaAviones
            AgregarAvion("Boeing", "737 MAX", 189, 6570, 5);
            AgregarAvion("Airbus", "A320neo", 180, 6300, 6);
            AgregarAvion("Embraer", "E195-E2", 132, 4815, 4);
            AgregarAvion("Bombardier", "CS300", 160, 6112, 7);
            #endregion
            #region PrecargaRutas
            AgregarRuta(DevolverAeropuerto("MVD"), DevolverAeropuerto("EZE"), 200);
            AgregarRuta(DevolverAeropuerto("MVD"), DevolverAeropuerto("GRU"), 1570);
            AgregarRuta(DevolverAeropuerto("MVD"), DevolverAeropuerto("SCL"), 1370);
            AgregarRuta(DevolverAeropuerto("EZE"), DevolverAeropuerto("LIM"), 3140);
            AgregarRuta(DevolverAeropuerto("GRU"), DevolverAeropuerto("MIA"), 6540);
            AgregarRuta(DevolverAeropuerto("SCL"), DevolverAeropuerto("MIA"), 6500);
            AgregarRuta(DevolverAeropuerto("PDP"), DevolverAeropuerto("AEP"), 320);
            AgregarRuta(DevolverAeropuerto("ASU"), DevolverAeropuerto("EZE"), 1080);
            AgregarRuta(DevolverAeropuerto("MVD"), DevolverAeropuerto("LAX"), 6000);
            AgregarRuta(DevolverAeropuerto("MVD"), DevolverAeropuerto("JFK"), 6000);
            AgregarRuta(DevolverAeropuerto("JFK"), DevolverAeropuerto("LAX"), 3980);
            AgregarRuta(DevolverAeropuerto("BCN"), DevolverAeropuerto("MAD"), 620);
            AgregarRuta(DevolverAeropuerto("MIA"), DevolverAeropuerto("BCN"), 6000);
            AgregarRuta(DevolverAeropuerto("DXB"), DevolverAeropuerto("PEK"), 5840);
            AgregarRuta(DevolverAeropuerto("COR"), DevolverAeropuerto("MDZ"), 660);
            AgregarRuta(DevolverAeropuerto("MDZ"), DevolverAeropuerto("SCL"), 480);
            AgregarRuta(DevolverAeropuerto("CYD"), DevolverAeropuerto("MVD"), 170);
            AgregarRuta(DevolverAeropuerto("SJO"), DevolverAeropuerto("PDP"), 550);
            AgregarRuta(DevolverAeropuerto("PEK"), DevolverAeropuerto("LAX"), 6000);
            AgregarRuta(DevolverAeropuerto("PEK"), DevolverAeropuerto("JFK"), 6000);
            AgregarRuta(DevolverAeropuerto("DXB"), DevolverAeropuerto("MAD"), 5700);
            AgregarRuta(DevolverAeropuerto("RIO"), DevolverAeropuerto("GRU"), 430);
            AgregarRuta(DevolverAeropuerto("RIO"), DevolverAeropuerto("MVD"), 1820);
            AgregarRuta(DevolverAeropuerto("COR"), DevolverAeropuerto("AEP"), 660);
            AgregarRuta(DevolverAeropuerto("CYD"), DevolverAeropuerto("EZE"), 190);
            AgregarRuta(DevolverAeropuerto("SJO"), DevolverAeropuerto("ASU"), 1080);
            AgregarRuta(DevolverAeropuerto("PDP"), DevolverAeropuerto("RIO"), 1930);
            AgregarRuta(DevolverAeropuerto("MVD"), DevolverAeropuerto("LIM"), 3120);
            AgregarRuta(DevolverAeropuerto("MIA"), DevolverAeropuerto("JFK"), 1760);
            AgregarRuta(DevolverAeropuerto("MAD"), DevolverAeropuerto("JFK"), 5760);
            AgregarRuta(DevolverAeropuerto("LIM"), DevolverAeropuerto("SCL"), 2000);


            #endregion
            #region PrecargaVuelos
            AgregarVuelo("AR101", DevolverAeropuerto("MVD"), DevolverAeropuerto("EZE"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday, DayOfWeek.Wednesday });      
            AgregarVuelo("AR102", DevolverAeropuerto("MVD"), DevolverAeropuerto("GRU"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Tuesday });
            AgregarVuelo("AR103", DevolverAeropuerto("MVD"), DevolverAeropuerto("SCL"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Wednesday});
            AgregarVuelo("AR104", DevolverAeropuerto("EZE"), DevolverAeropuerto("LIM"), DevolverAvion("A320neo"), new List<DayOfWeek> { DayOfWeek.Thursday, DayOfWeek.Friday });   
            AgregarVuelo("AR105", DevolverAeropuerto("GRU"), DevolverAeropuerto("MIA"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Friday });      
            AgregarVuelo("AR106", DevolverAeropuerto("SCL"), DevolverAeropuerto("MIA"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Saturday });     
            AgregarVuelo("AR107", DevolverAeropuerto("SCL"), DevolverAeropuerto("MIA"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Saturday });      
            AgregarVuelo("AR108", DevolverAeropuerto("SCL"), DevolverAeropuerto("MIA"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Saturday });      
            AgregarVuelo("AR109", DevolverAeropuerto("PDP"), DevolverAeropuerto("AEP"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Sunday });        
            AgregarVuelo("AR110", DevolverAeropuerto("ASU"), DevolverAeropuerto("EZE"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Monday });        
            AgregarVuelo("AR111", DevolverAeropuerto("JFK"), DevolverAeropuerto("LAX"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Tuesday });     
            AgregarVuelo("AR190", DevolverAeropuerto("BCN"), DevolverAeropuerto("MAD"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Wednesday });   
            AgregarVuelo("AR140", DevolverAeropuerto("DXB"), DevolverAeropuerto("PEK"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Thursday });    
            AgregarVuelo("AR112", DevolverAeropuerto("COR"), DevolverAeropuerto("MDZ"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Friday });       
            AgregarVuelo("AR113", DevolverAeropuerto("MDZ"), DevolverAeropuerto("SCL"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Saturday });    
            AgregarVuelo("AR114", DevolverAeropuerto("CYD"), DevolverAeropuerto("MVD"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Sunday });      
            AgregarVuelo("AR115", DevolverAeropuerto("SJO"), DevolverAeropuerto("PDP"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Monday });      
            AgregarVuelo("AR116", DevolverAeropuerto("DXB"), DevolverAeropuerto("MAD"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Friday });      
            AgregarVuelo("AR117", DevolverAeropuerto("RIO"), DevolverAeropuerto("GRU"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Wednesday });     
            AgregarVuelo("AR118", DevolverAeropuerto("RIO"), DevolverAeropuerto("MVD"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Thursday });     
            AgregarVuelo("AR119", DevolverAeropuerto("COR"), DevolverAeropuerto("AEP"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Friday });        
            AgregarVuelo("AR120", DevolverAeropuerto("CYD"), DevolverAeropuerto("EZE"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Saturday });      
            AgregarVuelo("AR121", DevolverAeropuerto("SJO"), DevolverAeropuerto("ASU"), DevolverAvion("A320neo"), new List<DayOfWeek> { DayOfWeek.Sunday });        
            AgregarVuelo("AR122", DevolverAeropuerto("PDP"), DevolverAeropuerto("RIO"), DevolverAvion("A320neo"), new List<DayOfWeek> { DayOfWeek.Monday });        
            AgregarVuelo("AR123", DevolverAeropuerto("MVD"), DevolverAeropuerto("LIM"), DevolverAvion("A320neo"), new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Friday });       
            AgregarVuelo("AR125", DevolverAeropuerto("MAD"), DevolverAeropuerto("JFK"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Thursday });      
            AgregarVuelo("AR124", DevolverAeropuerto("MIA"), DevolverAeropuerto("JFK"), DevolverAvion("E195-E2"), new List<DayOfWeek> { DayOfWeek.Wednesday });     
            AgregarVuelo("AR126", DevolverAeropuerto("LIM"), DevolverAeropuerto("SCL"), DevolverAvion("A320neo"), new List<DayOfWeek> { DayOfWeek.Friday });        
            AgregarVuelo("AR127", DevolverAeropuerto("MIA"), DevolverAeropuerto("BCN"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Saturday });      
            AgregarVuelo("AR199", DevolverAeropuerto("MIA"), DevolverAeropuerto("BCN"), DevolverAvion("CS300"), new List<DayOfWeek> { DayOfWeek.Saturday });        
            AgregarVuelo("AR128", DevolverAeropuerto("MVD"), DevolverAeropuerto("JFK"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Sunday, DayOfWeek.Friday });        
            AgregarVuelo("AR129", DevolverAeropuerto("PEK"), DevolverAeropuerto("LAX"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday });        
            AgregarVuelo("AR130", DevolverAeropuerto("PEK"), DevolverAeropuerto("JFK"), DevolverAvion("737 MAX"), new List<DayOfWeek> { DayOfWeek.Tuesday });
            #endregion
            #region PrecargaPasajes
            AgregarPasaje(DevolverVuelo("AR101"), new DateTime(2025, 5, 9), DevolverCliente("oratualzc@gmail.com"), Equipaje.CABINA, 250);
            AgregarPasaje(DevolverVuelo("AR102"), new DateTime(2025, 5, 13), DevolverCliente("valen.rios@example.com"), Equipaje.BODEGA, 300);
            AgregarPasaje(DevolverVuelo("AR103"), new DateTime(2025, 5, 14), DevolverCliente("diegomez@example.com"), Equipaje.CABINA, 270);
            AgregarPasaje(DevolverVuelo("AR104"), new DateTime(2025, 5, 15), DevolverCliente("camila.silva@example.com"), Equipaje.BODEGA, 320);
            AgregarPasaje(DevolverVuelo("AR105"), new DateTime(2025, 5, 16), DevolverCliente("felipe.travelz@example.com"), Equipaje.CABINA, 310);
            AgregarPasaje(DevolverVuelo("AR106"), new DateTime(2025, 5, 17), DevolverCliente("lucia.mendez@example.com"), Equipaje.BODEGA, 290);
            AgregarPasaje(DevolverVuelo("AR107"), new DateTime(2025, 5, 17), DevolverCliente("marcos.viaja@example.com"), Equipaje.CABINA, 280);
            AgregarPasaje(DevolverVuelo("AR108"), new DateTime(2025, 5, 17), DevolverCliente("sofia.ruta@example.com"), Equipaje.CABINA, 260);
            AgregarPasaje(DevolverVuelo("AR109"), new DateTime(2025, 5, 11), DevolverCliente("joaquin.aventura@example.com"), Equipaje.BODEGA, 270);
            AgregarPasaje(DevolverVuelo("AR110"), new DateTime(2025, 5, 12), DevolverCliente("oratualzc@gmail.com"), Equipaje.CABINA, 245);
            AgregarPasaje(DevolverVuelo("AR111"), new DateTime(2025, 5, 13), DevolverCliente("valen.rios@example.com"), Equipaje.BODEGA, 330);
            AgregarPasaje(DevolverVuelo("AR112"), new DateTime(2025, 5, 16), DevolverCliente("diegomez@example.com"), Equipaje.CABINA, 220);
            AgregarPasaje(DevolverVuelo("AR113"), new DateTime(2025, 5, 17), DevolverCliente("camila.silva@example.com"), Equipaje.BODEGA, 210);
            AgregarPasaje(DevolverVuelo("AR114"), new DateTime(2025, 5, 18), DevolverCliente("felipe.travelz@example.com"), Equipaje.CABINA, 280);
            AgregarPasaje(DevolverVuelo("AR115"), new DateTime(2025, 5, 19), DevolverCliente("lucia.mendez@example.com"), Equipaje.BODEGA, 270);
            AgregarPasaje(DevolverVuelo("AR116"), new DateTime(2025, 5, 13), DevolverCliente("marcos.viaja@example.com"), Equipaje.CABINA, 350);
            AgregarPasaje(DevolverVuelo("AR117"), new DateTime(2025, 5, 14), DevolverCliente("sofia.ruta@example.com"), Equipaje.BODEGA, 290);
            AgregarPasaje(DevolverVuelo("AR118"), new DateTime(2025, 5, 15), DevolverCliente("joaquin.aventura@example.com"), Equipaje.CABINA, 260);
            AgregarPasaje(DevolverVuelo("AR119"), new DateTime(2025, 5, 16), DevolverCliente("oratualzc@gmail.com"), Equipaje.BODEGA, 250);
            AgregarPasaje(DevolverVuelo("AR120"), new DateTime(2025, 5, 17), DevolverCliente("valen.rios@example.com"), Equipaje.CABINA, 270);
            AgregarPasaje(DevolverVuelo("AR121"), new DateTime(2025, 5, 18), DevolverCliente("diegomez@example.com"), Equipaje.BODEGA, 310);
            AgregarPasaje(DevolverVuelo("AR122"), new DateTime(2025, 5, 19), DevolverCliente("camila.silva@example.com"), Equipaje.CABINA, 300);
            AgregarPasaje(DevolverVuelo("AR123"), new DateTime(2025, 5, 13), DevolverCliente("felipe.travelz@example.com"), Equipaje.BODEGA, 290);
            AgregarPasaje(DevolverVuelo("AR124"), new DateTime(2025, 5, 14), DevolverCliente("lucia.mendez@example.com"), Equipaje.CABINA, 280);
            AgregarPasaje(DevolverVuelo("AR125"), new DateTime(2025, 5, 15), DevolverCliente("joaquin.aventura@example.com"), Equipaje.BODEGA, 320);
            AgregarPasaje(DevolverVuelo("AR125"), new DateTime(2025, 5, 15), DevolverCliente("joaquin.aventura@example.com"), Equipaje.BODEGA, 2000);
            AgregarPasaje(DevolverVuelo("AR125"), new DateTime(2025, 5, 15), DevolverCliente("joaquin.aventura@example.com"), Equipaje.BODEGA, 3320);


            #endregion
        }
        // METODOS

        #region Vuelo
        public void AgregarVuelo(string nroVuelo, Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada, Avion avion, List<DayOfWeek> frecuencia)
        {
            try
            {
                ExisteVuelo(nroVuelo);
                Vuelo vuelo = new Vuelo(nroVuelo, ExisteRuta(aeropuertoSalida, aeropuertoLlegada), avion, frecuencia);
                vuelo.Validar();
                listaVuelos.Add(vuelo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vuelo DevolverVuelo(string nroVuelo)
        {
            foreach(Vuelo unVuelo in listaVuelos)
            {
                if(unVuelo.NroVuelo == nroVuelo) return unVuelo;
            }
            throw new Exception("El vuelo no existe");
        }


        public void ExisteVuelo(string nroVuelo)
        {
            foreach (Vuelo unVuelo in listaVuelos)
            {
                if (unVuelo.NroVuelo.ToUpper() == nroVuelo.ToUpper()) throw new Exception("El vuelo ya existe");
            }
        }

        public Ruta ExisteRuta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada)
        {
            // recorremos lista de rutas y si existe la ruta la devuelve.
            foreach(Ruta unaRuta in listaRutas)
            {
                if (unaRuta.AeropuertoLlegada == aeropuertoLlegada && unaRuta.AeropuertoSalida == aeropuertoSalida) return unaRuta;
            }
            throw new Exception("No existe una ruta con los aeropuertos especificados.");

        }


		public bool FechaCoincideConFrecuencia(DateTime fecha, Vuelo vuelo)
		{
			DayOfWeek diaDeLaSemana = fecha.DayOfWeek;
            if(!vuelo.Frecuencia.Contains(diaDeLaSemana) || fecha == DateTime.MinValue) throw new Exception ("No coincide la frecuencia con la fecha seleccionada o no selecciono una fecha");
			return vuelo.Frecuencia.Contains(diaDeLaSemana);
		}

		#endregion

		#region Pasaje
		public void AgregarPasaje(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje, decimal precio)
		{
			try
			{
				Pasaje pasaje = new Pasaje(vuelo, fecha, pasajero, equipaje, precio);
				pasaje.Validar();
				ValidarPasajero(pasajero);
				listaPasajes.Add(pasaje);

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public void AgregarPasajeWeb(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje)
		{
			try
			{
				ValidarPasajero(pasajero);
				decimal precioTotal = Math.Round(pasajero.CalcularPrecioPasaje(equipaje, vuelo), 2);
				Pasaje pasaje = new Pasaje(vuelo, fecha, pasajero, equipaje, precioTotal);
				pasaje.Validar(); 
				listaPasajes.Add(pasaje);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		
		public void ValidarPasajero(Cliente pasajero)
        {
            if (!listaUsuarios.Contains(pasajero)) throw new Exception("No existe el usuario");
        }
        #endregion

        #region Avion
        public void AgregarAvion(string fabricante, string modelo, int cantAsientos, int alcance, decimal costoOperacionKm)
        {
            try
            {
                Avion avion = new Avion(fabricante, modelo, cantAsientos, alcance, costoOperacionKm);
                ExisteAvion(avion);
                avion.Validar();
                listaAviones.Add(avion);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExisteAvion(Avion avion)
        {
            if (listaAviones.Contains(avion)) throw new Exception("El avion ya existe.");
        }

        public Avion DevolverAvion(string modelo)
        {
            foreach(Avion unAvion in listaAviones)
            {
                if (unAvion.Modelo == modelo) return unAvion;
            }
            throw new Exception("No se encontro el avion");
        }

        #endregion

        #region Ruta
        public void AgregarRuta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada, int distancia)
        {
            try
            {
                Ruta ruta = new Ruta(aeropuertoSalida,aeropuertoLlegada,distancia);
                ruta.Validar();
                listaRutas.Add(ruta);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Aeropuerto
        public void AgregarAeropuerto(string codigoIata, string ciudad, decimal costoOperacion, decimal costoTasas)
        {
            try
            {
                Aeropuerto aeropuerto = new Aeropuerto(codigoIata, ciudad, costoOperacion, costoTasas);
                aeropuerto.Validar();
                listaAeropuertos.Add(aeropuerto);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Aeropuerto DevolverAeropuerto(string codigoIata)
        {
            foreach (Aeropuerto unAeropuerto in listaAeropuertos)
            {
                if (unAeropuerto.CodigoIata == codigoIata) return unAeropuerto;
            }
            throw new Exception("No esta registrado el Aeropuerto");
        }
        public void ExisteAeropuerto(string codigoIata)
        {
            if (codigoIata.Length != 3) throw new Exception("El codigo Iata no puede ser mayor a 3 caracteres");
            bool existe = false;
            foreach (Aeropuerto unAeropuerto in listaAeropuertos)
            {
                if (unAeropuerto.CodigoIata == codigoIata) existe = true;
            }
            if(!existe) throw new Exception("No esta registrado el Aeropuerto");

        }

		public void ExisteAeropuerto(string codigoIata1, string codigoIata2)
		{
			if (codigoIata1.Length != 3 || codigoIata2.Length != 3)
				throw new Exception("Cada código IATA debe tener exactamente 3 caracteres");

			bool existe1 = false;
			bool existe2 = false;

			foreach (Aeropuerto unAeropuerto in listaAeropuertos)
			{
				if (unAeropuerto.CodigoIata == codigoIata1)
					existe1 = true;

				if (unAeropuerto.CodigoIata == codigoIata2)
					existe2 = true;
			}

			if (!existe1 || !existe2)
				throw new Exception("Uno o ambos aeropuertos no están registrados");
		}


		#endregion

		#region Usuario
		public Cliente DevolverCliente(string mail)
        {
            List<Cliente> aux = ListarClientes();
            foreach (Cliente unCliente in aux)
            {
                if (unCliente.Mail == mail)
                {
                    return unCliente;
                }
            }
            throw new Exception("El cliente no existe");
        }

        public Premium DevolverPremium(string mail)
        {
            List<Premium> aux = ListarClientesPremium();
            foreach (Premium unCliente in aux)
            {
                if (unCliente.Mail == mail)
                {
                    return unCliente;
                }
            }
            throw new Exception("El cliente no existe");
        }
        public Ocasionales DevolverOcasional(string mail)
        {
            List<Ocasionales> aux = ListarClientesOcasionales();
            foreach (Ocasionales unCliente in aux)
            {
                if (unCliente.Mail == mail)
                {
                    return unCliente;
                }
            }
            throw new Exception("El cliente no existe");
        }

        public Cliente? DevolverCliente(string Mail, string Password)
        {
            List<Cliente> aux = ListarClientes();
            foreach (Cliente unC in aux)
            {
                if(unC.Password == Password && unC.Mail == Mail) return unC;
            }
            return null;
        }

		public Usuario? DevolverUsuario(string Mail, string Password)
		{
			List<Usuario> aux = ListarUsuarios();
			foreach (Usuario unUser in aux)
			{
				if (unUser.Password == Password && unUser.Mail == Mail) return unUser;
			}
			return null;
		}
        public Usuario? DevolverUsuarioPorMail(string Mail)
		{
			List<Usuario> aux = ListarUsuarios();
			foreach (Usuario unUser in aux)
			{
				if (unUser.Mail == Mail) return unUser;
			}
			return null;
		}


		public void ExisteUsuario(Usuario unUser)
        {
            if (listaUsuarios.Contains(unUser)) throw new Exception("El usuario ya existe");
        }

        public void AgregarUsuario(Usuario unUser)
        {
            try
            {
                unUser.Validar();
                ExisteUsuario(unUser);
                listaUsuarios.Add(unUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AgregarOcasional(Ocasionales unUser)
        {
            try
            {
                unUser.Validar();
                ExisteUsuario(unUser);
                listaUsuarios.Add(unUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Pasaje> PasajesPorCliente(Cliente unC)
        {
            List<Pasaje> aux = new List<Pasaje>();
            foreach(Pasaje unP in ListarPasajesPrecioDesc())
            {
                if(unC.Documento == unP.Pasajero.Documento)
                {
                    aux.Add(unP);
                }
            }
            return aux;
        }

        public void ModificarPuntos(int puntos, string email)
        {
            Premium unC = DevolverPremium(email);
            unC.Puntos = puntos;
        }

        public void ModificarElegible(bool elegible, string email)
        {
            Ocasionales unC = DevolverOcasional(email);
            unC.Elegible = elegible;
        }

        #endregion

        #region Listados
        public List<Cliente> ListarClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            foreach(Usuario unUser in listaUsuarios)
            {
                if (unUser is Cliente) listaClientes.Add((Cliente)unUser);

            }
            return listaClientes;

        }
        public List<Premium> ListarClientesPremium()
        {
            List<Premium> listaClientes = new List<Premium>();
            foreach (Usuario unUser in listaUsuarios)
            {
                if (unUser is Premium) listaClientes.Add((Premium)unUser);

            }
            return listaClientes;
        }
        public List<Ocasionales> ListarClientesOcasionales()
        {
            List<Ocasionales> listaClientes = new List<Ocasionales>();
            foreach (Usuario unUser in listaUsuarios)
            {
                if (unUser is Ocasionales) listaClientes.Add((Ocasionales)unUser);

            }
            return listaClientes;
        }


        public List<Usuario> ListarUsuarios()
		{
			
			return listaUsuarios;

		}

		public List<Vuelo> ListarVuelos(string codigoIata)
        {
            List<Vuelo> aux = new List<Vuelo>();

            ExisteAeropuerto(codigoIata);
            
            foreach (Vuelo unVuelo in listaVuelos)
            {
                if (unVuelo.Ruta.AeropuertoSalida.CodigoIata == codigoIata || unVuelo.Ruta.AeropuertoLlegada.CodigoIata == codigoIata)
                {
                    aux.Add(unVuelo);
                }
            }
            return aux;
        }


		public List<Vuelo> ListarVuelosFiltrados(string IATA1, string IATA2)
		{
			List<Vuelo> aux = new List<Vuelo>();
			if (IATA1 == IATA2)
			{
				throw new Exception("Debe ingresar dos aeropuertos distintos.");
			}
			ExisteAeropuerto(IATA1, IATA2);

			

			foreach (Vuelo unVuelo in listaVuelos)
			{
				string salida = unVuelo.Ruta.AeropuertoSalida.CodigoIata;
				string llegada = unVuelo.Ruta.AeropuertoLlegada.CodigoIata;

			



				if (salida == IATA1 && llegada == IATA2)
				{
					aux.Add(unVuelo);
                }
             

			}

			return aux;
		}



		public List<Vuelo> ListarVuelos()
        {
            return listaVuelos;
        }

        public List<Pasaje> ListarPasajes(DateTime fecha1, DateTime fecha2)
        {
            if(fecha1 > fecha2 && fecha2 < fecha1) throw new Exception("La fecha 1 no puede ser mayor a la fecha 2");

            List<Pasaje> aux = new List<Pasaje>();
            foreach (Pasaje unPasaje in listaPasajes)
            {
                if (unPasaje.Fecha >= fecha1 && unPasaje.Fecha <= fecha2) {
                    aux.Add(unPasaje);
                    unPasaje.Validar();
                }
                else
                {
                    throw new Exception("No existen pasajes en esas fechas");
                }
            }
            return aux;
        }

        public List<Pasaje> ListarPasajesPrecioDesc()
        {
            listaPasajes.Sort();
            return listaPasajes;
        }

        public List<Pasaje> ListarPasajesPorFecha()
        {
            //listaPasajes.Sort(new CompareToPorFecha());
            listaPasajes.Sort();
            return listaPasajes;
        }


     
        #endregion
    }
}
