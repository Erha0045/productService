using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using product_service.RabbitMQ;
using product_service.Repo;
using System.Threading.Tasks;

namespace product_service.Controllers;

// Tilføjet senere end mødet
[Route("api/[controller]")]
[ApiController]
public class WineController : Controller
{
    private readonly WineQueries _productQueries;
    private readonly WineCommands _productCommands;
    private readonly RabbitMQProducer _rabbitMQProducer;

    public WineController(WineQueries queries, WineCommands commands, RabbitMQProducer rabbitMQProducer)
    {
        _productQueries = queries;
        _productCommands = commands;
        _rabbitMQProducer = rabbitMQProducer;
    }

    //[HttpGet("Wine")]

    [HttpGet]
    [EnableCors]
    public async Task<IActionResult> Index()
    {
        return Ok(await _productQueries.ListProducts());
    }

    // GET: api/Wine/{guid}
    [HttpGet("{productGuid}")]
    public async Task<IActionResult> GetWine(Guid productGuid)
    {
        var wine = await _productQueries.GetWine(productGuid);
        if (wine == null)
        {
            return NotFound();
        }

        return Ok(wine);
    }

    // POST: api/Wine
    [HttpPost]
    [EnableCors]
    public async Task<IActionResult> CreateWine([FromBody] Wine wine)
    {
        var createdWine = await _productCommands.CreateWine(wine);

        // Publish the message to RabbitMQ
        _rabbitMQProducer.PublishMessage(createdWine, "wine.create");

        return CreatedAtAction(
            nameof(GetWine),
            new { productGuid = createdWine.ProductGuid },
            createdWine
        );
    }

    // PUT: api/Wine/{guid}
    [HttpPut("{productGuid}")]
    public async Task<IActionResult> UpdateWine(Guid productGuid, [FromBody] Wine wine)
    {
        if (productGuid != wine.ProductGuid)
        {
            return BadRequest();
        }

        var updatedWine = await _productCommands.UpdateWine(wine);

        // Publish the message to RabbitMQ
        _rabbitMQProducer.PublishMessage(updatedWine, "wine.update");

        return NoContent();
    }

    // DELETE: api/Wine/{guid}
    [HttpDelete("{productGuid}")]
    public async Task<IActionResult> DeleteWine(Guid productGuid)
    {
        await _productCommands.DeleteWine(productGuid);

        // Publish the message to RabbitMQ
        _rabbitMQProducer.PublishMessage(new { ProductGuid = productGuid }, "wine.delete");

        return NoContent();
    }
}
