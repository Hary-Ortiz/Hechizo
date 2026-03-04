using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObtenerTodasAsync();
        Task<Categoria?> ObtenerPorIdAsync(string id);
        Task CrearAsync(string id, string nombre, string? descripcion);
        Task ActualizarAsync(string id, string nombre, string? descripcion);
        Task EliminarAsync(string id);
    }
}
