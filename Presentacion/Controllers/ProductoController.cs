using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;



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

        public async Task<IActionResult> PorCategoria(string categoria)
        {
            var productos = await _service.ObtenerTodosAsync();

            var filtrados = productos
                .Where(p => p.Categoria == categoria)
                .ToList();

            return View("Index", filtrados);
        }

        public async Task<IActionResult> AgregarCarrito(int id)
        {
            var producto = await _service.ObtenerPorIdAsync(id);

            var carritoItem = new
            {
                productoId = producto.Id,
                nombre = producto.Nombre,
                precio = producto.Precio,
                imagen = producto.Imagen
            };

            using var client = new HttpClient();

            await client.PostAsJsonAsync(
                "https://localhost:7185/api/carrito/agregar",
                carritoItem
            );

            return RedirectToAction("Index");
        }


    }


}
