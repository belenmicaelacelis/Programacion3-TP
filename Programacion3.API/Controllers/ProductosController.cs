using Microsoft.AspNetCore.Mvc;
using Programacion3.API.Services;

namespace Programacion3.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var productos = _productoService.ObtenerTodos();
        return Ok(productos);
    }
}