using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Mail, string Password)
        {
            Sistema unS = Sistema.Instancia;
            Usuario? unUser = unS.DevolverUsuario(Mail,Password);
            if(unUser != null)
            {
                
                HttpContext.Session.SetString("Mail", unUser.Mail);
                if (unUser is Ocasionales) HttpContext.Session.SetString("Rol", "Ocasional");
                if (unUser is Premium) HttpContext.Session.SetString("Rol", "Premium");
				if (unUser is Administrador) HttpContext.Session.SetString("Rol", "Administrador");
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Mensaje = "Credenciales incorrectas"; 
                return View();
            }

        }

        
    }
}
