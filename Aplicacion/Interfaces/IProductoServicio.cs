using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductoServicio
    {
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task CrearAsync(string nombre, decimal precio, string? descripcion, string categoria);
        Task ActualizarAsync(int id, string nombre, decimal precio, string? descripcion, string categoria);
        Task EliminarAsync(int id);
    }
}
