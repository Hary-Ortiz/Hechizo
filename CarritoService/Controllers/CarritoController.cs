using Microsoft.AspNetCore.Mvc;
using CarritoService.Services;
using CarritoService.Models;

//Controlador para manejar las operaciones relacionadas con el carrito de compras, como agregar productos, eliminar productos y obtener el contenido del carrito. Además, incluye un método para procesar el pago del carrito, que se comunica con el servicio de pagos a través de una solicitud HTTP POST.
namespace CarritoService.Controllers
{
    [ApiController]
    [Route("api/carrito")]
    public class CarritoController : ControllerBase
    {

        // Inyección de dependencia del servicio de carrito para manejar la lógica de negocio relacionada con el carrito, como agregar productos, eliminar productos y obtener el contenido del carrito.
        private readonly Services.CarritoService _service;

        // El constructor del controlador recibe una instancia del servicio de carrito a través de la inyección de dependencias, lo que permite al controlador utilizar los métodos del servicio para realizar las operaciones necesarias en el carrito de compras.
        public CarritoController(Services.CarritoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Obtener()
        {
            return Ok(_service.ObtenerCarrito());
        }

        [HttpPost("agregar")]
        public IActionResult Agregar(CarritoItem item)
        {
            _service.Agregar(item);
            return Ok();
        }

        [HttpDelete("{productoId}")]
        public IActionResult Eliminar(int productoId)
        {
            _service.Eliminar(productoId);
            return Ok();
        }

        // Método para procesar el pago del carrito, que se comunica con el servicio de pagos a través de una solicitud HTTP POST.

        public async Task<IActionResult> Pagar()
        {
            var client = new HttpClient();

            var pago = new
            {
                monto = 10000,
                metodo = "Tarjeta"
            };

            var response = await client.PostAsJsonAsync(
                "https://localhost:7132/api/pago/procesar",
                pago
            );

            if (response.IsSuccessStatusCode)
            {
                return Ok("Pago realizado con éxito");
            }
            else
            {
                return BadRequest("Error en el pago");
            }
        }
    }
}