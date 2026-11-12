using Microsoft.AspNetCore.Mvc;
using Obligatorio_P2;

namespace Obligatorio_P2_Web.Controllers
{
    public class SospechosoController : Controller
    {
        Sistema sistema = Sistema.ObtenerInstancia();

        [HttpGet]
        public IActionResult Index(string edad)
        {
            if (HttpContext.Session.GetInt32("IdLogueado") == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (HttpContext.Session.GetString("RolLogueado") != "DETECTIVE")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Edad = edad;

            List<Sospechoso> sospechosos = new List<Sospechoso>();

            if (string.IsNullOrEmpty(edad))
            {
                // Sin filtro, mostramos todos
                sospechosos = sistema.ListarSospechosos();
            }
            else
            {
                int edadIngresada;
                bool esNumero = int.TryParse(edad, out edadIngresada);

                if (!esNumero || edadIngresada < 0)
                {
                    ViewBag.Error =
                        "Ingresá una edad entera mayor o igual a cero.";
                }
                else
                {
                    sospechosos =
                        sistema.FiltrarSospechososPorEdad(edadIngresada);
                }
            }

            return View(sospechosos);
        }
    }
}