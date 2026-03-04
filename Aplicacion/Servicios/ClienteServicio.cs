using Aplicacion.Interfaces;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Servicios
{
    /// <summary>
    /// 
    /// </summary>
    public class ClienteServicio : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServico(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosAsync()
        {
            return await _clienteRepository.ObtenerTodosAsync();
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            return await _clienteRepository.ObtenerPorIdAsync(id);
        }

        public async Task CrearAsync(string nombre, string apellido, string email, string telefono)
        {
            var cliente = new Cliente(nombre, apellido, email, telefono);

            await _clienteRepository.CrearAsync(cliente);
        }

        public async Task EliminarAsync(int id)
        {
            await _clienteRepository.EliminarAsync(id);
        }
    }
}
