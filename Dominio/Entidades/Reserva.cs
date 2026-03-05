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
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NumeroPersonas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Observaciones { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EstadoReserva Estado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ClienteId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected Reserva() { }

        /// <summary>
        /// 
        /// </summary>
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