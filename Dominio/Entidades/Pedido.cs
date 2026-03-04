using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    /// <summary>
    /// Método que define la clase Pedido
    /// </summary>
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public EstadoPedido Estado { get; set; }

        public decimal Total { get; set; }
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();

        protected Pedido() { }

        public Pedido(int clienteId)
        {
            ClienteId = clienteId;
            Fecha = DateTime.UtcNow;
            Estado = EstadoPedido.Pendiente;
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            var detalle = new DetallePedido(producto.Id, producto.Precio, cantidad);
            Detalles.Add(detalle);
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            Total = Detalles.Sum(d => d.Subtotal);
        }

        public void Confirmar()
        {
            Estado = EstadoPedido.Confirmado;
        }
    }
}
