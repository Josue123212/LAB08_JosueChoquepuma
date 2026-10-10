using LAB08_JosueChoquepuma.Models;

namespace LAB08_JosueChoquepuma.Repositories;

public interface ILinqRepository
{
    // Ejercicio 1: Obtener clientes cuyo nombre empiece/contenga un valor específico
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
    // Ejercicio 2: Obtener productos con precio mayor a un valor específico
    Task<IEnumerable<Product>> GetProductsWithPriceGreaterThanAsync(decimal minPrice);
}