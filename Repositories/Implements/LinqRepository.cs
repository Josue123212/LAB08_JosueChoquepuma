using LAB08_JosueChoquepuma.Models;
using Microsoft.EntityFrameworkCore;
using LAB08_JosueChoquepuma.DTOs;

namespace LAB08_JosueChoquepuma.Repositories.Implements;

public class LinqRepository : ILinqRepository
{
    private readonly LinqexampleContext _context;

    public LinqRepository(LinqexampleContext context)
    {
        _context = context;
    }

    // Ejercicio 1
    public async Task<IEnumerable<Client>> GetClientsByNameAsync(string name)
    {
        return await _context.Clients
            .Where(c => c.Name.ToLower().StartsWith(name.ToLower()))
            .ToListAsync();
    }
    // Ejercicio 2
    public async Task<IEnumerable<Product>> GetProductsWithPriceGreaterThanAsync(decimal minPrice)
    {
        return await _context.Products
            .Where(p => p.Price > minPrice)
            .ToListAsync();
    }
    public async Task<IEnumerable<ProductOrderDetailDto>> GetProductsByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Include(od => od.Product)
            .Where(od => od.Orderid == orderId)
            .Select(od => new ProductOrderDetailDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
    // Ejercicio 4
    public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.Orderid == orderId)
            .Select(od => od.Quantity)
            .SumAsync();
    }
    // Ejercicio 5
    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }
    // Ejercicio 6
    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.Orderdate > date)
            .ToListAsync();
    }
    // Ejercicio 7
    public async Task<decimal> GetAverageProductPriceAsync()
    {
        return await _context.Products
            .Select(p => p.Price)
            .AverageAsync();
    }
    // Ejercicio 8
    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }
    // Ejercicio 9
    public async Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync()
    {
        return await _context.Orders
            .GroupBy(o => o.Clientid)
            .OrderByDescending(g => g.Count())
            .Select(g => new ClientOrderCountDto
            {
                ClientId = g.Key,
                OrderCount = g.Count()
            })
            .FirstOrDefaultAsync();
    }
    // Ejercicio 10
    public async Task<IEnumerable<OrderProductDetailDto>> GetAllOrdersWithDetailsAsync()
    {
        return await _context.Orderdetails
            .Include(od => od.Product)
            .Select(od => new OrderProductDetailDto
            {
                OrderId = od.Orderid,
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
    // Ejercicio 11
    public async Task<IEnumerable<string>> GetProductsByClientIdAsync(int clientId)
    {
        return await _context.Orderdetails
            .Where(od => od.Order.Clientid == clientId)
            .Select(od => od.Product.Name)
            .Distinct()
            .ToListAsync();
    }
    // Ejercicio 12
    public async Task<IEnumerable<string>> GetClientsByProductIdAsync(int productId)
    {
        return await _context.Orderdetails
            .Where(od => od.Productid == productId)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync();
    }
}