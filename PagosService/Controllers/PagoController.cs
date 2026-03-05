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
        private readonly PagoService _service;

        public PagoController(PagoService service)
        {
            _service = service;
        }

        [HttpPost("procesar")]
        public IActionResult ProcesarPago([FromBody] Pago pago)
        {
            _service.ProcesarPago(pago);

            return Ok(new { mensaje = "Pago realizado con éxito" });
        }

        [HttpGet]
        public IActionResult ObtenerPagos()
        {
            return Ok(_service.ObtenerPagos());
        }
    }
}