using Aplicacion.Interfaces;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoServicio(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            return await _productoRepository.ObtenerTodosAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _productoRepository.ObtenerPorIdAsync(id);
        }

        public async Task CrearAsync(string nombre, decimal precio, string? descripcion, string categoria)
        {
            var producto = new Producto
            {
                Nombre = nombre,
                Precio = precio,
                Descripcion = descripcion,
                Categoria = categoria
            };

            await _productoRepository.CrearAsync(producto);
        }

        public async Task ActualizarAsync(int id, string nombre, decimal precio, string? descripcion, string categoria)
        {
            var producto = await _productoRepository.ObtenerPorIdAsync(id);

            if (producto == null)
                throw new Exception("Producto no encontrado");

            producto.Nombre = nombre;
            producto.Precio = precio;
            producto.Descripcion = descripcion;
            producto.Categoria = categoria;

            await _productoRepository.ActualizarAsync(producto);
        }

        public async Task EliminarAsync(int id)
        {
            await _productoRepository.EliminarAsync(id);
        }
    }
}
