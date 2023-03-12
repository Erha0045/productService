using Microsoft.AspNetCore.Mvc;

namespace product_service.Controllers;

[ApiController]
[Route("[controller]")]
public class WineController : ControllerBase
{
   
    private readonly ILogger<WineController> _logger;

    public WineController(ILogger<WineController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWine")]
    public IEnumerable<Wine> Get()
    {
       /* return Enumerable.Range(1, 5).Select(index => new Wine
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
       */
    }
}

