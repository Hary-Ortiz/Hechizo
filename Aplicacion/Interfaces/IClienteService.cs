using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task CrearAsync(string nombre, string apellido, string email, string telefono);
        Task EliminarAsync(int id);
    }
}
