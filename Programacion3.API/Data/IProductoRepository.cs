using Programacion3.API.Models;

namespace Programacion3.API.Data;

public interface IProductoRepository
{
    List<Producto> ObtenerTodos();
    Producto? ObtenerPorId(int id);
}