using LAB08_JosueChoquepuma.Models;
using Microsoft.EntityFrameworkCore;

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
}