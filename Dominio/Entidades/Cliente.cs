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
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaRegistro { get; set; }

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
