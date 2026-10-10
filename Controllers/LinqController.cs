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
    // Ejercicio 4: Cantidad total de productos en una orden específica
    [HttpGet("ejercicio4")]
    public async Task<IActionResult> GetEjercicio4([FromQuery] int orderId = 1)
    {
        var totalQuantity = await _repository.GetTotalQuantityByOrderIdAsync(orderId);
        return Ok(new { OrderId = orderId, TotalQuantity = totalQuantity });
    }
    // Ejercicio 5: Obtener el producto más caro
    [HttpGet("ejercicio5")]
    public async Task<IActionResult> GetEjercicio5()
    {
        var product = await _repository.GetMostExpensiveProductAsync();
        if (product == null)
            return NotFound("No se encontraron productos.");

        return Ok(product);
    }
    // Ejercicio 6: Obtener pedidos posteriores a una fecha
    [HttpGet("ejercicio6")]
    public async Task<IActionResult> GetEjercicio6([FromQuery] DateTime date)
    {
        var orders = await _repository.GetOrdersAfterDateAsync(date);
        return Ok(orders);
    }
    // Ejercicio 7: Obtener el precio promedio de los productos
    [HttpGet("ejercicio7")]
    public async Task<IActionResult> GetEjercicio7()
    {
        var averagePrice = await _repository.GetAverageProductPriceAsync();
        return Ok(new { AveragePrice = averagePrice });
    }
    // Ejercicio 8: Obtener productos sin descripción
    [HttpGet("ejercicio8")]
    public async Task<IActionResult> GetEjercicio8()
    {
        var products = await _repository.GetProductsWithoutDescriptionAsync();
        return Ok(products);
    }
}