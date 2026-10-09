using LAB08_JosueChoquepuma.Models;

namespace LAB08_JosueChoquepuma.Repositories;

public interface ILinqRepository
{
    // Ejercicio 1: Obtener clientes cuyo nombre empiece/contenga un valor específico
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
}