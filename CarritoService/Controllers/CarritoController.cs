using Microsoft.AspNetCore.Mvc;
using CarritoService.Services;
using CarritoService.Models;

namespace CarritoService.Controllers
{
    [ApiController]
    [Route("api/carrito")]
    public class CarritoController : ControllerBase
    {
        private readonly Services.CarritoService _service;

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