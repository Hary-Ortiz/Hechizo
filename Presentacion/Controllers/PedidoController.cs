using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoServicio _service;

        public PedidoController(IPedidoServicio service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.ObtenerTodosAsync();
            return View(data);
        }

        public IActionResult Create() => View();

        public IActionResult Details(int id) => View();

        public IActionResult Confirmar(int id) => View();
    }
}
}
