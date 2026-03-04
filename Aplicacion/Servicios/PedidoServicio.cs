using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    public class PedidoServicio : IPedidoServicio
    {
        private readonly IPedidoRepository _repository;

        public PedidoServicio(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Pedido>> ObtenerTodosAsync()
            => await _repository.ObtenerTodosAsync();

        public async Task<Pedido?> ObtenerPorIdAsync(int id)
            => await _repository.ObtenerPorIdAsync(id);

        public async Task<int> CrearPedidoAsync(int clienteId)
        {
            var pedido = new Pedido(clienteId);
            await _repository.AgregarAsync(pedido);
            return pedido.Id;
        }

        public async Task AgregarProductoAsync(int pedidoId, Producto producto, int cantidad)
        {
            var pedido = await _repository.ObtenerPorIdAsync(pedidoId);

            if (pedido == null)
                throw new Exception("Pedido no encontrado");

            pedido.AgregarProducto(producto, cantidad);
            await _repository.ActualizarAsync(pedido);
        }

        public async Task ConfirmarPedidoAsync(int pedidoId)
        {
            var pedido = await _repository.ObtenerPorIdAsync(pedidoId);

            if (pedido == null)
                throw new Exception("Pedido no encontrado");

            pedido.Confirmar();
            await _repository.ActualizarAsync(pedido);
        }

        public async Task EliminarAsync(int id)
            => await _repository.EliminarAsync(id);
    }
}