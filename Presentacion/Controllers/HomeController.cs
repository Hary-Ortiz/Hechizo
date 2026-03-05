using Microsoft.AspNetCore.Mvc;
using Presentacion.Models;
using System.Diagnostics;

namespace Presentacion.Controllers
{
    // Controlador para manejar las operaciones relacionadas con la página de inicio y la privacidad, así como para mostrar la página de error en caso de que ocurra un error en la aplicación. El controlador incluye métodos para devolver las vistas correspondientes a cada acción, y el método de error utiliza el modelo ErrorViewModel para mostrar información sobre el error ocurrido.
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
