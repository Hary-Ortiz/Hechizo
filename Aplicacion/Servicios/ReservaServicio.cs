using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    // Implementación del servicio de reservas que utiliza un repositorio para realizar operaciones de acceso a datos. Este servicio implementa la interfaz IReservaService, lo que permite abstraer la lógica de negocio relacionada con las reservas y facilita la implementación de diferentes servicios que puedan manejar esta funcionalidad.
    public class ReservaServicio : IReservaServicio
    {
        private readonly IReservaRepository _repository;

        public ReservaServicio(IReservaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Reserva>> ObtenerTodasAsync()
            => await _repository.ObtenerTodasAsync();

        public async Task<Reserva?> ObtenerPorIdAsync(int id)
            => await _repository.ObtenerPorIdAsync(id);

        public async Task CrearAsync(DateTime fecha, int numeroPersonas, string observaciones, int clienteId)
        {
            var reserva = new Reserva(fecha, numeroPersonas, observaciones, clienteId);
            await _repository.AgregarAsync(reserva);
        }

        public async Task ConfirmarAsync(int id)
        {
            var reserva = await _repository.ObtenerPorIdAsync(id);

            if (reserva == null)
                throw new Exception("Reserva no encontrada");

            reserva.Confirmar();
            await _repository.ActualizarAsync(reserva);
        }

        public async Task CancelarAsync(int id)
        {
            var reserva = await _repository.ObtenerPorIdAsync(id);

            if (reserva == null)
                throw new Exception("Reserva no encontrada");

            reserva.Cancelar();
            await _repository.ActualizarAsync(reserva);
        }

        public async Task EliminarAsync(int id)
            => await _repository.EliminarAsync(id);
    }
}