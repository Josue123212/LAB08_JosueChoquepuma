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
}