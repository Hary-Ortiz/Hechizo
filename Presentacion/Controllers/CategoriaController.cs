using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.ObtenerTodasAsync();
            return View(data);
        }

        public IActionResult Create() => View();

        public IActionResult Edit(string id) => View();

        public IActionResult Details(string id) => View();

        public IActionResult Delete(string id) => View();
    }
}
