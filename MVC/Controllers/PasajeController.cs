using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MVC.Controllers
{
    public class PasajeController : Controller
    {
        public IActionResult ComprarPasaje(string id)
        {
            Sistema unS = Sistema.Instancia;

            ViewBag.Vuelo = unS.DevolverVuelo(id);
            ViewBag.Id = id;

			return View();
        }

        public IActionResult DetalleCompra()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DetalleCompra(string NroVuelo, DateTime Fecha, Equipaje equipaje) 
        {
			Sistema unS = Sistema.Instancia;
			try
			{
                Cliente cliente = unS.DevolverCliente(HttpContext.Session.GetString("Mail"));
                unS.FechaCoincideConFrecuencia(Fecha, unS.DevolverVuelo(NroVuelo));
                unS.AgregarPasajeWeb(unS.DevolverVuelo(NroVuelo), Fecha, cliente, equipaje);
			    return RedirectToAction("VerPasajes", "Cliente");
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View("ComprarPasaje");
			}

		}


		[HttpPost]
		public IActionResult FiltradoPasajes(string IATA1, string IATA2)
        {
            try
            {
                Sistema unS = Sistema.Instancia;
                ViewBag.Vuelo = unS.ListarVuelosFiltrados(IATA1.ToUpper(),IATA2.ToUpper());

				return View("FiltradoPasajes");
			}
            catch(Exception ex) 
            {
				ViewBag.Error = ex.Message;  
				return View ();

			}
            

        }



	}
    
    
    
}
