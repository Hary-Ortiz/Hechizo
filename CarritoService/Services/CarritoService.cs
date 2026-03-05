using CarritoService.Models;

// Servicio para manejar la lógica de negocio relacionada con el carrito de compras, como agregar productos, eliminar productos y obtener el contenido del carrito. El servicio utiliza una lista estática para almacenar los elementos del carrito, lo que permite simular un almacenamiento en memoria sin necesidad de una base de datos.

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