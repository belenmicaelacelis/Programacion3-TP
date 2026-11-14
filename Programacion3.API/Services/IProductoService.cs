using Programacion3.API.Models;

namespace Programacion3.API.Services;

public interface IProductoService
{
    List<Producto> ObtenerTodos();
    Producto? ObtenerPorId(int id);
}