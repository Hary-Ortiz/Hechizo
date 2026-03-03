using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    /// <summary>
    /// Método que define los posibles estados de la reserva
    /// </summary>
    public enum EstadoReserva
    { 
        Desconocido = 0,
        Pendiente = 1,
        Confirmada = 2,
        Cancelada = 3
    }
}
