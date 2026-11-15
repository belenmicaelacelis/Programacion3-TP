using Microsoft.AspNetCore.Mvc;
using Programacion3.API.Data;
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
        try
        {
            var productos = _productoService.ObtenerTodos();
            return Ok(productos);
        }
        catch (AccesoDatosException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { mensaje = "Ocurrió un error al consultar los productos. Intente nuevamente más tarde." });
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetPorId(int id)
    {
        try
        {
            var producto = _productoService.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }
        catch (AccesoDatosException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { mensaje = "Ocurrió un error al consultar el producto. Intente nuevamente más tarde." });
        }
    }
}