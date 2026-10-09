using Microsoft.AspNetCore.Mvc;
using LAB08_JosueChoquepuma.Repositories;

namespace LAB08_JosueChoquepuma.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LinqController : ControllerBase
{
    private readonly ILinqRepository _repository;

    public LinqController(ILinqRepository repository)
    {
        _repository = repository;
    }

    // Ejercicio 1: Obtener clientes por nombre
    [HttpGet("ejercicio1")]
    public async Task<IActionResult> GetEjercicio1([FromQuery] string name = "Juan")
    {
        var clients = await _repository.GetClientsByNameAsync(name);
        return Ok(clients);
    }
}