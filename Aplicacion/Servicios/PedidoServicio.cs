using Aplicacion.Interfaces;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Servicios
{
    public class PedidoServicio : IPedidoServicio
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProductoRepository _productoRepository;

        public PedidoServicio(
            IPedidoRepository pedidoRepository,
            IProductoRepository productoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Pedido>> ObtenerTodosAsync()
        {
            return await _pedidoRepository.ObtenerTodosAsync();
        }

        public async Task<Pedido?> ObtenerPorIdAsync(int id)
        {
            return await _pedidoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<int> CrearPedidoAsync(int clienteId)
        {
            var pedido = new Pedido(clienteId);

            await _pedidoRepository.CrearAsync(pedido);

            return pedido.Id;
        }

        public async Task AgregarProductoAsync(int pedidoId, int productoId, int cantidad)
        {
            var pedido = await _pedidoRepository.ObtenerPorIdAsync(pedidoId);
            if (pedido == null)
                throw new Exception("Pedido no encontrado");

            var producto = await _productoRepository.ObtenerPorIdAsync(productoId);
            if (producto == null)
                throw new Exception("Producto no encontrado");

            pedido.AgregarProducto(producto, cantidad);

            await _pedidoRepository.ActualizarAsync(pedido);
        }

        public async Task ConfirmarPedidoAsync(int pedidoId)
        {
            var pedido = await _pedidoRepository.ObtenerPorIdAsync(pedidoId);

            if (pedido == null)
                throw new Exception("Pedido no encontrado");

            pedido.Confirmar();

            await _pedidoRepository.ActualizarAsync(pedido);
        }

        public async Task EliminarAsync(int id)
        {
            await _pedidoRepository.EliminarAsync(id);
        }
    }
}
