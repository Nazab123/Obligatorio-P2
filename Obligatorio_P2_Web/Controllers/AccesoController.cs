
using Microsoft.AspNetCore.Mvc;
using Obligatorio_P2;

namespace Obligatorio_P2_Web.Controllers
{
    public class AccesoController : Controller
    {
        private Sistema _sistema;

        public AccesoController(Sistema sistema)
        {
            _sistema = sistema;
        }

        // Muestra el formulario de login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Recibe los datos del formulario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string contrasena)
        {
            Investigador investigador =
                _sistema.IniciarSesion(email, contrasena);

            if (investigador == null)
            {
                ViewBag.Error = "Email o contraseña incorrectos";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
