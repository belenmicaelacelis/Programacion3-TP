using Microsoft.AspNetCore.Mvc;

namespace Programacion3.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("ProductosController funcionando");
    }
}