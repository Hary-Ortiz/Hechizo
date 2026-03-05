namespace CarritoService.Models
{
    // Modelo que representa un producto en el carrito de compras, con propiedades como ProductoId, Nombre, Precio, Cantidad e Imagen. Este modelo se utiliza para almacenar la información de los productos que el usuario ha agregado al carrito y se utiliza en las operaciones relacionadas con el carrito, como agregar productos, eliminar productos y obtener el contenido del carrito.
    public class CarritoItem
    {
        public int ProductoId { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public string Imagen { get; set; }
    }
}