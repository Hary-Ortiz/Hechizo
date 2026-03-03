using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    /// <summary>
    /// Método que define la clase Cliente
    /// </summary>
    public class Cliente
    {
        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public string Email { get; private set; }

        public string Telefono { get; private set; }

        public DateTime FechaRegistro { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"> Nombre del cliente</param>
        /// <param name="apellido">Apellido del cliente</param>
        /// <param name="email">Correo electrónico del cliente</param>
        /// <param name="telefono">Teléfono del cliente</param>
        public Cliente(string nombre, string apellido, string email, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            FechaRegistro = DateTime.UtcNow;
        }
    }
}
