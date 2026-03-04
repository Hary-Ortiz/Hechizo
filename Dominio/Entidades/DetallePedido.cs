using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    /// <summary>
    /// Método que define los detalles del pedido 
    /// </summary>
    public class DetallePedido
    {
        public int Id { get; set; }

        public int ProductoId { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int Cantidad { get; set; }
        public decimal Subtotal => PrecioUnitario * Cantidad;

        protected DetallePedido() { }

        public DetallePedido(int productoId, decimal precioUnitario, int cantidad)
        {
            ProductoId = productoId;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
        }
    }
}
