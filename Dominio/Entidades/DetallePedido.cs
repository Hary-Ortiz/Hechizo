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
        public int Id { get; private set; }

        public int ProductoId { get; private set; }

        public decimal PrecioUnitario { get; private set; }

        public int Cantidad { get; private set; }

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
