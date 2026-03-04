using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoServicio _service;

        public ProductoController(IProductoServicio service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.ObtenerTodosAsync();
            return View(data);
        }

        public IActionResult Create() => View();

        public IActionResult Edit(int id) => View();

        public IActionResult Details(int id) => View();

        public IActionResult Delete(int id) => View();
    }
}
