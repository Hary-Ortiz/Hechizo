using Aplicacion.Interfaces;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Servicios
{
    public class ReservaServicio : IReservaServicio
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaServicio(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<IEnumerable<Reserva>> ObtenerTodasAsync()
        {
            return await _reservaRepository.ObtenerTodasAsync();
        }

        public async Task<Reserva?> ObtenerPorIdAsync(int id)
        {
            return await _reservaRepository.ObtenerPorIdAsync(id);
        }

        public async Task<int> CrearAsync(DateTime fecha, int numeroPersonas, string observaciones, int clienteId)
        {
            var reserva = new Reserva(fecha, numeroPersonas, observaciones, clienteId);

            await _reservaRepository.CrearAsync(reserva);

            return reserva.Id;
        }

        public async Task ConfirmarAsync(int reservaId)
        {
            var reserva = await _reservaRepository.ObtenerPorIdAsync(reservaId);

            if (reserva == null)
                throw new Exception("Reserva no encontrada");

            reserva.Confirmar();

            await _reservaRepository.ActualizarAsync(reserva);
        }

        public async Task CancelarAsync(int reservaId)
        {
            var reserva = await _reservaRepository.ObtenerPorIdAsync(reservaId);

            if (reserva == null)
                throw new Exception("Reserva no encontrada");

            reserva.Cancelar();

            await _reservaRepository.ActualizarAsync(reserva);
        }

        public async Task EliminarAsync(int id)
        {
            await _reservaRepository.EliminarAsync(id);
        }
    }
}
