using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    // Interfaz para definir los métodos que el repositorio de clientes debe implementar, como obtener todos los clientes, obtener un cliente por su ID, agregar un nuevo cliente y eliminar un cliente por su ID. Esta interfaz permite abstraer la lógica de acceso a datos relacionada con los clientes y facilita la implementación de diferentes repositorios que puedan manejar esta funcionalidad.
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Cliente cliente);
        Task EliminarAsync(int id);
    }
}
