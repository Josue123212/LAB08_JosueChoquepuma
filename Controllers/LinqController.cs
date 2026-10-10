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
    // Ejercicio 2: Obtener productos con precio mayor a un valor
    [HttpGet("ejercicio2")]
    public async Task<IActionResult> GetEjercicio2([FromQuery] decimal minPrice = 20)
    {
        var products = await _repository.GetProductsWithPriceGreaterThanAsync(minPrice);
        return Ok(products);
    }
    // Ejercicio 3
    [HttpGet("ejercicio3")]
    public async Task<IActionResult> GetEjercicio3([FromQuery] int orderId = 1)
    {
        var details = await _repository.GetProductsByOrderIdAsync(orderId);
        return Ok(details);
    }
}