using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    /// <summary>
    /// Método que define la clase Reserva
    /// </summary>
    /// .
    public class Reserva
    {
        public int Id { get; private set; }

        public DateTime Fecha { get; private set; }

        public int NumeroPersonas { get; private set; }

        public string? Observaciones { get; private set; }

        public EstadoReserva Estado { get; private set; }

        public int ClienteId { get; private set; }

        public Cliente Cliente { get; private set; }

        protected Reserva() { }

        public Reserva(DateTime fecha, int numeroPersonas, string observaciones, int clienteId)
        {
            Fecha = fecha;
            NumeroPersonas = numeroPersonas;
            Observaciones = observaciones;
            ClienteId = clienteId;
            Estado = EstadoReserva.Pendiente;
        }

        public void Confirmar()
        {
            Estado = EstadoReserva.Confirmada;
        }

        public void Cancelar()
        {
            Estado = EstadoReserva.Cancelada;
        }
    }
}