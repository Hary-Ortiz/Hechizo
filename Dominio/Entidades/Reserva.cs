using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    /// <summary>
    /// Método que define la clase Reserva
    /// </summary>
    
    public class Reserva
    {
       
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public int NumeroPersonas { get; set; }

       
        public string? Observaciones { get; set; }

        public EstadoReserva Estado { get; set; }

        
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        protected Reserva() { }

        /// <param name="fecha"></param>
        /// <param name="numeroPersonas"></param>
        /// <param name="observaciones"></param>
        /// <param name="clienteId"></param>
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