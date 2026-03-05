using Microsoft.AspNetCore.Mvc;
using PagosService.Models;
using PagosService.Services;
using PagosService.Models;

namespace PagosService.Controllers
{
    [ApiController]
    [Route("api/pago")]
    public class PagoController : ControllerBase
    {

        // Inyección de dependencia del servicio de pagos para manejar la lógica de negocio relacionada con los pagos, como procesar un pago o recuperar la lista de pagos realizados.

        private readonly PagoService _service;

        public PagoController(PagoService service)
        {
            _service = service;
        }

        //Acá se usa el patrón Builder para construir el objeto Pago de manera más flexible y legible, permitiendo configurar solo las propiedades necesarias y evitando constructores con muchos parámetros.

        [HttpPost("procesar")]
        public IActionResult ProcesarPago([FromBody] Pago pago)
        {
            var builder = new PagoBuilder();

            var pagoFinal = builder
                .ConTotal(pago.Total)
                .ConMetodo(pago.Metodo)
                .Build();

            _service.ProcesarPago(pagoFinal);

            return Ok(new { mensaje = "Pago realizado con éxito" });
        }

        // Este endpoint permite obtener la lista de pagos realizados, devolviendo un resultado con el estado HTTP 200 (OK) y la lista de pagos en el cuerpo de la respuesta.

        [HttpGet]
        public IActionResult ObtenerPagos()
        {
            return Ok(_service.ObtenerPagos());
        }


    }
}