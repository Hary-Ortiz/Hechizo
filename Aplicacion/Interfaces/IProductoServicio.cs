using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    // Interfaz para definir los métodos que el servicio de productos debe implementar, como obtener todos los productos, obtener un producto por su ID, agregar un nuevo producto, actualizar un producto existente y eliminar un producto por su ID. Esta interfaz permite abstraer la lógica de negocio relacionada con los productos y facilita la implementación de diferentes servicios que puedan manejar esta funcionalidad.
    public interface IProductoServicio
    {
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Producto producto);
        Task ActualizarAsync(Producto producto);
        Task EliminarAsync(int id);
    }
}
