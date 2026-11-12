using Microsoft.AspNetCore.Mvc;
using Obligatorio_P2;

namespace Obligatorio_P2_Web.Controllers
{
    public class CasoController : Controller
    {
        Sistema sistema = Sistema.ObtenerInstancia();

        [HttpGet]
        public IActionResult MisCasos()
        {
            // Comprobamos que haya una sesión iniciada
            if (HttpContext.Session.GetInt32("IdLogueado") == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            // Esta funcionalidad corresponde a los detectives
            if (HttpContext.Session.GetString("RolLogueado") != "DETECTIVE")
            {
                return RedirectToAction("Index", "Home");
            }

            // Obtenemos el email del investigador logueado
            string email =
                HttpContext.Session.GetString("EmailLogueado");

            // Buscamos únicamente sus casos
            List<Caso> casos =
                sistema.BuscarCasosPorInvestigador(email);

            return View(casos);
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("IdLogueado") == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (HttpContext.Session.GetString("RolLogueado") != "FISCAL")
            {
                return RedirectToAction("Index", "Home");
            }

            List<Caso> casos = sistema.ListarCasos();

            return View(casos);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("IdLogueado") == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (HttpContext.Session.GetString("RolLogueado") != "FISCAL")
            {
                return RedirectToAction("Index", "Home");
            }

            Caso caso = sistema.BuscarCasoPorId(id);

            if (caso == null)
            {
                TempData["Error"] = "No se encontró el caso solicitado.";
                return RedirectToAction("Index");
            }

            return View(caso);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("IdLogueado") == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (HttpContext.Session.GetString("RolLogueado") != "FISCAL")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Sospechosos = sistema.ListarSospechosos();
            ViewBag.Detectives = sistema.ListarDetectives();

            ViewBag.IdSospechoso = 0;
            ViewBag.IdDetective = 0;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string nombre, string descripcion,
            int idSospechoso, int idDetective)
        {
            if (HttpContext.Session.GetInt32("IdLogueado") == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (HttpContext.Session.GetString("RolLogueado") != "FISCAL")
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                Sospechoso sospechoso =
                    sistema.BuscarSospechosoPorId(idSospechoso);

                Investigador detective =
                    sistema.BuscarInvestigadorPorId(idDetective);

                Caso caso = new Caso(
                    nombre,
                    descripcion,
                    false,
                    sospechoso,
                    detective
                );

                sistema.AltaCaso(caso);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                // Conservamos los datos ingresados.
                ViewBag.Nombre = nombre;
                ViewBag.Descripcion = descripcion;
                ViewBag.IdSospechoso = idSospechoso;
                ViewBag.IdDetective = idDetective;

                // Volvemos a cargar las opciones de los desplegables.
                ViewBag.Sospechosos = sistema.ListarSospechosos();
                ViewBag.Detectives = sistema.ListarDetectives();

                return View();
            }
        }
    }
}