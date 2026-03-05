using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    // Controlador para manejar las operaciones relacionadas con los pedidos, como mostrar la lista de pedidos, crear un nuevo pedido, mostrar los detalles de un pedido y confirmar un pedido. El controlador utiliza un servicio de pedidos para obtener la información necesaria y realizar las operaciones correspondientes.
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

