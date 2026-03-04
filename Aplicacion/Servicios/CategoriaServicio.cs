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
    public class CategoriaServicio : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaServicio(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodasAsync()
        {
            return await _categoriaRepository.ObtenerTodasAsync();
        }

        public async Task<Categoria?> ObtenerPorIdAsync(string id)
        {
            return await _categoriaRepository.ObtenerPorIdAsync(id);
        }

        public async Task CrearAsync(string id, string nombre, string? descripcion)
        {
            var categoria = new Categoria
            {
                Id = id,
                Nombre = nombre,
                Descripcion = descripcion
            };

            await _categoriaRepository.CrearAsync(categoria);
        }

        public async Task ActualizarAsync(string id, string nombre, string? descripcion)
        {
            var categoria = await _categoriaRepository.ObtenerPorIdAsync(id);

            if (categoria == null)
                throw new Exception("Categoría no encontrada");

            categoria.Nombre = nombre;
            categoria.Descripcion = descripcion;

            await _categoriaRepository.ActualizarAsync(categoria);
        }

        public async Task EliminarAsync(string id)
        {
            await _categoriaRepository.EliminarAsync(id);
        }
    }
}
