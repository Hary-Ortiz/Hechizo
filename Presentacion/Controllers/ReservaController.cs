using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    public class ReservaController : Controller
    {
        private readonly IReservaServicio _service;

        public ReservaController(IReservaServicio service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.ObtenerTodasAsync();
            return View(data);
        }

        public IActionResult Create() => View();

        public IActionResult Details(int id) => View();

        public IActionResult Confirmar(int id) => View();

        public IActionResult Cancelar(int id) => View();
    }
}
