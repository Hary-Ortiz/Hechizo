using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    // Controlador para manejar las operaciones relacionadas con las categorías, como mostrar la lista de categorías, crear una nueva categoría, editar una categoría existente, mostrar los detalles de una categoría y eliminar una categoría. El controlador utiliza un servicio de categorías para realizar las operaciones necesarias en la base de datos y devolver las vistas correspondientes.
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
