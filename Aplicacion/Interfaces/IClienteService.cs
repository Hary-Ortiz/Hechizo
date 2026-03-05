using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    // Interfaz para definir los métodos que el servicio de clientes debe implementar, como obtener todos los clientes, obtener un cliente por su ID, agregar un nuevo cliente y eliminar un cliente por su ID. Esta interfaz permite abstraer la lógica de negocio relacionada con los clientes y facilita la implementación de diferentes servicios que puedan manejar esta funcionalidad.
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(string nombre, string apellido, string email, string telefono);
        Task EliminarAsync(int id);
    }
}
