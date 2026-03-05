using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    // Implementación del servicio de productos que utiliza un repositorio para realizar operaciones de acceso a datos. Este servicio implementa la interfaz IProductoService, lo que permite abstraer la lógica de negocio relacionada con los productos y facilita la implementación de diferentes servicios que puedan manejar esta funcionalidad.
    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepository _repository;

        public ProductoServicio(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            return await _repository.ObtenerTodosAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _repository.ObtenerPorIdAsync(id);
        }

        public async Task AgregarAsync(Producto producto)
        {
            await _repository.AgregarAsync(producto);
        }

        public async Task ActualizarAsync(Producto producto)
        {
            var existente = await _repository.ObtenerPorIdAsync(producto.Id);

            if (existente == null)
                throw new Exception("Producto no encontrado");

            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            existente.Descripcion = producto.Descripcion;
            existente.Categoria = producto.Categoria;

            await _repository.ActualizarAsync(existente);
        }

        public async Task EliminarAsync(int id)
        {
            await _repository.EliminarAsync(id);
        }
    }
}