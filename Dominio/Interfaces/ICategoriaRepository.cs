using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    // Interfaz para definir los métodos que el repositorio de categorías debe implementar, como obtener todas las categorías, obtener una categoría por su ID, agregar una nueva categoría, actualizar una categoría existente y eliminar una categoría por su ID. Esta interfaz permite abstraer la lógica de acceso a datos relacionada con las categorías y facilita la implementación de diferentes repositorios que puedan manejar esta funcionalidad.
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ObtenerTodasAsync();
        Task<Categoria?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Categoria categoria);
        Task ActualizarAsync(Categoria categoria);
        Task EliminarAsync(int id);
    }
}
