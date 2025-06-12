using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/Login");

            return View();
            
        }

        public IActionResult VerPasajes()
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/Login");
            if (HttpContext.Session.GetString("Rol")  == "Administrador")
            {
                Sistema unS = Sistema.Instancia;
                Pasaje.Orden = 1; // ORDEN PARA ADMIN
                List<Pasaje> listaP = unS.ListarPasajesPorFecha();
                ViewBag.ListaPasajes = listaP;
                if (listaP.Count == 0)
                {
                    ViewBag.error = "Lista vacia";
                }
            }
            else
            {
                ViewBag.error = "Acceso no autorizado";

            }
            return View("VerPasajesAdm", "Admin");
        }

        public IActionResult VerClientes() 
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/Login");
            if (HttpContext.Session.GetString("Rol") == "Administrador")
            {
                Sistema unS = Sistema.Instancia;
                List<Cliente> listaC = unS.ListarClientes();
                ViewBag.ListaClientes = listaC;
                if (listaC.Count == 0)
                {
                    ViewBag.error = "Lista vacia";
                }
            }else
            {
                ViewBag.error = "Acceso no autorizado";
            }
            return View("VerClientesAdm", "Admin");
        }

        [HttpPost]

        public IActionResult EditarCliente (string Elegible, int Puntos, string Mail)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/Login");
            if (HttpContext.Session.GetString("Rol") == "Administrador")
            {
                Sistema unS = Sistema.Instancia;
                Cliente cliente = unS.DevolverCliente(Mail);
                if(cliente is Premium)
                {
                    if (Puntos > 0) unS.ModificarPuntos(Puntos,Mail);
                }
                if (cliente is Ocasionales)
                {
                    bool eleccion;
                    if (Elegible == "True")
                    {
                        eleccion = true;
                        unS.ModificarElegible(eleccion, Mail);
                    }
                    else
                    {
                        eleccion = false;
                        unS.ModificarElegible(eleccion, Mail);
                    }
                }
            }
            else
            {
                ViewBag.error = "No se pudo modificar el cliente";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
