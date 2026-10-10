using LAB08_JosueChoquepuma.DTOs;
using LAB08_JosueChoquepuma.Models;

namespace LAB08_JosueChoquepuma.Repositories;

public interface ILinqRepository
{
    // Ejercicio 1: Obtener clientes cuyo nombre empiece/contenga un valor específico
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
    // Ejercicio 2: Obtener productos con precio mayor a un valor específico
    Task<IEnumerable<Product>> GetProductsWithPriceGreaterThanAsync(decimal minPrice);
    // Ejercicio 3: Obtener detalles proyectados (Nombre y Cantidad) de una orden
    Task<IEnumerable<ProductOrderDetailDto>> GetProductsByOrderIdAsync(int orderId);
    // Ejercicio 4: Cantidad total de productos por orden
    Task<int> GetTotalQuantityByOrderIdAsync(int orderId);
    // Ejercicio 5: Obtener el producto más caro
    Task<Product?> GetMostExpensiveProductAsync();
    // Ejercicio 6: Obtener órdenes posteriores a una fecha especificada
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
    // Ejercicio 7: Promedio de precio de los productos
    Task<decimal> GetAverageProductPriceAsync();
}