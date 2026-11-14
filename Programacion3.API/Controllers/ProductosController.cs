using Microsoft.AspNetCore.Mvc;
using Programacion3.API.Models;

namespace Programacion3.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Teclado mecánico", Precio = 45999.90m, Stock = 25 },
            new Producto { Id = 2, Nombre = "Mouse inalámbrico", Precio = 18500.00m, Stock = 40 }
        };

        return Ok(productos);
    }
}