using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    // Interfaz para definir los métodos que el repositorio de reservas debe implementar, como obtener todas las reservas, obtener una reserva por su ID, agregar una nueva reserva, actualizar una reserva existente y eliminar una reserva por su ID. Esta interfaz permite abstraer la lógica de acceso a datos relacionada con las reservas y facilita la implementación de diferentes repositorios que puedan manejar esta funcionalidad.
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> ObtenerTodasAsync();
        Task<Reserva?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Reserva reserva);
        Task ActualizarAsync(Reserva reserva);
        Task EliminarAsync(int id);
    }
}
