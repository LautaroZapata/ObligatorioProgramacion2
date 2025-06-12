using System;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(string Documento, string Nombre, string Nacionalidad, string Mail, string Password)
        {
            Sistema unS = Sistema.Instancia;

            try
            {
                Ocasionales unUser = new Ocasionales(Documento,Nombre,Nacionalidad,Mail,Password);
                unS.AgregarOcasional
                    (unUser);
                HttpContext.Session.SetString("Mail", unUser.Mail);
                HttpContext.Session.SetString("Rol", unUser.GetType().ToString());
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; 
                return View();
            }
        }

    }
}
