using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    // Interfaz para definir los métodos que el servicio de pedidos debe implementar, como obtener todos los pedidos, obtener un pedido por su ID, crear un nuevo pedido, agregar un producto a un pedido existente, confirmar un pedido y eliminar un pedido por su ID. Esta interfaz permite abstraer la lógica de negocio relacionada con los pedidos y facilita la implementación de diferentes servicios que puedan manejar esta funcionalidad.
    public interface IPedidoServicio
    {
        Task<IEnumerable<Pedido>> ObtenerTodosAsync();
        Task<Pedido?> ObtenerPorIdAsync(int id);
        Task<int> CrearPedidoAsync(int clienteId);
        Task AgregarProductoAsync(int pedidoId, Producto producto, int cantidad);
        Task ConfirmarPedidoAsync(int pedidoId);
        Task EliminarAsync(int id);
    }
}
