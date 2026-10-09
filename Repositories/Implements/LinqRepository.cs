using LAB08_JosueChoquepuma.Models;

namespace LAB08_JosueChoquepuma.Repositories.Implements;

public class LinqRepository : ILinqRepository
{
    private readonly LinqexampleContext _context;

    public LinqRepository(LinqexampleContext context)
    {
        _context = context;
    }

    
}