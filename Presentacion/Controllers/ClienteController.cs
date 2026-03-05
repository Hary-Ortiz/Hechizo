using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    // Controlador para manejar las operaciones relacionadas con los clientes, como mostrar la lista de clientes, crear un nuevo cliente, mostrar los detalles de un cliente y eliminar un cliente. El controlador utiliza un servicio de clientes para realizar las operaciones necesarias y devolver las vistas correspondientes.
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
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

        public IActionResult Delete(int id) => View();
    }
}
