using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPedidoServicio
    {
        Task<IEnumerable<Pedido>> ObtenerTodosAsync();
        Task<Pedido?> ObtenerPorIdAsync(int id);
        Task<int> CrearPedidoAsync(int clienteId);
        Task AgregarProductoAsync(int pedidoId, int productoId, int cantidad);
        Task ConfirmarPedidoAsync(int pedidoId);
        Task EliminarAsync(int id);
    }
}
