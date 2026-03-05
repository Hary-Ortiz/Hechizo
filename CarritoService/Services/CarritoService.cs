using CarritoService.Models;

namespace CarritoService.Services
{
    public class CarritoService
    {
        private static List<CarritoItem> carrito = new();

        public List<CarritoItem> ObtenerCarrito()
        {
            return carrito;
        }

        public void Agregar(CarritoItem item)
        {
            var existente = carrito
                .FirstOrDefault(p => p.ProductoId == item.ProductoId);

            if (existente != null)
                existente.Cantidad++;
            else
                carrito.Add(item);
        }

        public void Eliminar(int productoId)
        {
            var item = carrito
                .FirstOrDefault(p => p.ProductoId == productoId);

            if (item != null)
                carrito.Remove(item);
        }
    }
}