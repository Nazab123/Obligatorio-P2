
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

            HttpContext.Session.SetString("EmailLogueado", investigador.Email);
            HttpContext.Session.SetInt32("IdLogueado", investigador.Id);
            HttpContext.Session.SetString("RolLogueado", investigador.Rol.ToString());

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Registro()
        {
            // El registro es para personas que no están logueadas
            if (HttpContext.Session.GetInt32("IdLogueado") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(string nombre, string email, string contrasena)
        {
            if (HttpContext.Session.GetInt32("IdLogueado") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                // Creamos al investigador siempre con rol detective
                Investigador investigador = new Investigador(
                    email,
                    contrasena,
                    nombre,
                    Rol.DETECTIVE
                );

                // Validamos y agregamos al investigador al sistema
                _sistema.AltaInvestigador(investigador);

                // Iniciamos su sesión automáticamente
                HttpContext.Session.SetInt32("IdLogueado", investigador.Id);
                HttpContext.Session.SetString("EmailLogueado", investigador.Email);
                HttpContext.Session.SetString("RolLogueado", investigador.Rol.ToString());

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                // Conservamos estos datos para que pueda corregirlos
                ViewBag.Nombre = nombre;
                ViewBag.Email = email;

                return View();
            }
        }

        [HttpGet]
        public IActionResult Perfil()
        {
            // Obtenemos el ID del investigador que inició sesión
            int? idLogueado = HttpContext.Session.GetInt32("IdLogueado");

            if (idLogueado == null){
                return RedirectToAction("Login");
            }

            // Buscamos al investigador en el sistema
            Investigador investigador = _sistema.BuscarInvestigadorPorId(idLogueado.Value);

            if (investigador == null){
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }

            // Enviamos el investigador a la vista
            return View(investigador);
        }

    }
}
