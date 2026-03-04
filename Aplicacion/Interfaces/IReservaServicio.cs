using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReservaServicio
    {
        Task<IEnumerable<Reserva>> ObtenerTodasAsync();
        Task<Reserva?> ObtenerPorIdAsync(int id);

        Task<int> CrearAsync(DateTime fecha, int numeroPersonas, string observaciones, int clienteId);

        Task ConfirmarAsync(int reservaId);
        Task CancelarAsync(int reservaId);

        Task EliminarAsync(int id);
    }
}
