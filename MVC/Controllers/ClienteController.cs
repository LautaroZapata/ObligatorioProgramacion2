using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ClienteController : Controller
    {

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/Login");
            return View();
        }
        public IActionResult VerVuelos()
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/Login");
            if (HttpContext.Session.GetString("Rol") == "Premium" || HttpContext.Session.GetString("Rol") == "Ocasional")
            {
                Sistema unS = Sistema.Instancia;
                List<Vuelo> lista = unS.ListarVuelos();
                ViewBag.ListaVuelos = lista;
                if (lista.Count == 0)
                {
                    ViewBag.error = "Lista vacia";
                }
            }
            else
            {
                ViewBag.error = "Acceso no autorizado";

            }
            return View();

        }
        public IActionResult VerPasajes()
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/Login");
            if (HttpContext.Session.GetString("Rol") == "Premium" || HttpContext.Session.GetString("Rol") == "Ocasional")
            {
                Sistema unS = Sistema.Instancia;
                string mailCliente = HttpContext.Session.GetString("Mail");
                Pasaje.Orden = 0;
                List<Pasaje> listaP = unS.PasajesPorCliente(unS.DevolverCliente(mailCliente));
                ViewBag.ListaPasajes = listaP;
                if (listaP.Count == 0)
                {
                    ViewBag.error = "Lista vacia";
                }
            } else
            {
                ViewBag.error = "Acceso no autorizado";
            }

            return View();
        }

        public IActionResult VerPerfil()
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/Login");
            if (HttpContext.Session.GetString("Rol") == "Premium" || HttpContext.Session.GetString("Rol") == "Ocasional")
            {
                Sistema unS = Sistema.Instancia;
                Usuario unC = unS.DevolverUsuarioPorMail(HttpContext.Session.GetString("Mail"));
                ViewBag.Usuario = unC;
                
            }
            else
            {
                ViewBag.error = "Acceso no autorizado";

            }
            return View();
        }
    }
}
