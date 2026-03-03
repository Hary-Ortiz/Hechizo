using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    /// <summary>
    /// Método que define el estado del pedido
    /// </summary>
    public enum EstadoPedido
    {
        Desconocido = 0,
        Pendiente = 1,
        Confirmado = 2,
        EnPreparacion = 3,
        Entregado = 4,
        Cancelado = 5
    }
}
