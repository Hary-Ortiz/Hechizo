using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    /// Interfaz para definir los métodos que el servicio de categorías debe implementar, como obtener todas las categorías, obtener una categoría por su ID, agregar una nueva categoría, actualizar una categoría existente y eliminar una categoría por su ID. Esta interfaz permite abstraer la lógica de negocio relacionada con las categorías y facilita la implementación de diferentes servicios que puedan manejar esta funcionalidad.
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObtenerTodasAsync();
        Task<Categoria?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Categoria categoria);
        Task ActualizarAsync(Categoria categoria);
        Task EliminarAsync(int id);
    }
}
