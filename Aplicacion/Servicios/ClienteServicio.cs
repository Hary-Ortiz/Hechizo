using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
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