using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

// Controlador para manejar las operaciones relacionadas con las reservas, como mostrar la lista de reservas, crear una nueva reserva, mostrar los detalles de una reserva, confirmar una reserva y cancelar una reserva. El controlador utiliza un servicio de reservas para realizar las operaciones necesarias en la lógica de negocio relacionada con las reservas, como obtener la lista de reservas, crear una nueva reserva, confirmar una reserva y cancelar una reserva.

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
