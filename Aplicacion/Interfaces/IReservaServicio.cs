using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    // Interfaz para definir los métodos que el servicio de reservas debe implementar, como obtener todas las reservas, obtener una reserva por su ID, crear una nueva reserva, confirmar una reserva, cancelar una reserva y eliminar una reserva por su ID. Esta interfaz permite abstraer la lógica de negocio relacionada con las reservas y facilita la implementación de diferentes servicios que puedan manejar esta funcionalidad.
    public interface IReservaServicio
    {
        Task<IEnumerable<Reserva>> ObtenerTodasAsync();
        Task<Reserva?> ObtenerPorIdAsync(int id);

        Task CrearAsync(DateTime fecha, int numeroPersonas, string observaciones, int clienteId);

        Task ConfirmarAsync(int Id);
        Task CancelarAsync(int Id);

        Task EliminarAsync(int id);
    }
}
