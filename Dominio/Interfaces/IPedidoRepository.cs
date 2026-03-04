using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> ObtenerTodosAsync();
        Task<Pedido?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Pedido pedido);
        Task ActualizarAsync(Pedido pedido);
        Task EliminarAsync(int id);
    }
}
