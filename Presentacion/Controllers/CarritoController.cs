using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Presentacion.Controllers
{
    public class CarritoController : Controller
    {
        private readonly HttpClient _http;

        public CarritoController()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri("https://localhost:7185/");
        }

        public async Task<IActionResult> Index()
        {
            var carrito = await _http.GetFromJsonAsync<List<CarritoItem>>("api/carrito");

            return View(carrito);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            await _http.DeleteAsync($"api/carrito/{id}");

            return RedirectToAction("Index");
        }

        // Método para pagar el carrito
        public async Task<IActionResult> Pagar()
        {
            var client = new HttpClient();

            var pago = new
            {
                total = 10500,
                metodo = "Tarjeta"
            };

            var response = await client.PostAsJsonAsync(
                "https://localhost:7132/api/pago/procesar",
                pago
            );

            if (response.IsSuccessStatusCode)
            {
                TempData["mensaje"] = "Pago realizado con éxito";
            }
            else
            {
                TempData["mensaje"] = "Error al procesar el pago";
            }

            return RedirectToAction("Index");
        }
    }

    public class CarritoItem
    {
        public int productoId { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string imagen { get; set; }
    }
}