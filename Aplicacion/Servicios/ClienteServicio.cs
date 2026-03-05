using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    /// Implementación del servicio de clientes que utiliza un repositorio para realizar operaciones de acceso a datos. Este servicio implementa la interfaz IClienteService, lo que permite abstraer la lógica de negocio relacionada con los clientes y facilita la implementación de diferentes servicios que puedan manejar esta funcionalidad.
    public class ClienteServicio : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteServicio(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosAsync()
            => await _repository.ObtenerTodosAsync();

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
            => await _repository.ObtenerPorIdAsync(id);

        public async Task AgregarAsync(string nombre, string apellido, string email, string telefono)
        {
            var cliente = new Cliente(nombre, apellido, email, telefono);
            await _repository.AgregarAsync(cliente);
        }

        public async Task EliminarAsync(int id)
            => await _repository.EliminarAsync(id);
    }
}