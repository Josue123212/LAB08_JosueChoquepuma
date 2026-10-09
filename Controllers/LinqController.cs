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

    
}