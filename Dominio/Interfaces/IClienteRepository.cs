using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Cliente cliente);
        Task EliminarAsync(int id);
    }
}
