using Programacion3.API.Models;

namespace Programacion3.API.Services;

public class ProductoService : IProductoService
{
    private readonly List<Producto> _productos = new()
    {
        new Producto { Id = 1, Nombre = "Teclado mecánico", Precio = 45999.90m, Stock = 25 },
        new Producto { Id = 2, Nombre = "Mouse inalámbrico", Precio = 18500.00m, Stock = 40 }
    };

    public List<Producto> ObtenerTodos()
    {
        return _productos;
    }

    public Producto? ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }
}