using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    // Interfaz para definir los métodos que el repositorio de pedidos debe implementar, como obtener todos los pedidos, obtener un pedido por su ID, agregar un nuevo pedido, actualizar un pedido existente y eliminar un pedido por su ID. Esta interfaz permite abstraer la lógica de acceso a datos relacionada con los pedidos y facilita la implementación de diferentes repositorios que puedan manejar esta funcionalidad.
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> ObtenerTodosAsync();
        Task<Pedido?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Pedido pedido);
        Task ActualizarAsync(Pedido pedido);
        Task EliminarAsync(int id);
    }
}
