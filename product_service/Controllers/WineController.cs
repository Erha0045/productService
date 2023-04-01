using Microsoft.AspNetCore.Mvc;
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

    public WineController(WineQueries queries, WineCommands commands)
    {
        _productQueries = queries;
        _productCommands = commands;
    }

    //[HttpGet("Wine")]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //return View(await _productQueries.ListProducts());
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
    public async Task<IActionResult> CreateWine([FromBody] Wine wine)
    {
        var createdWine = await _productCommands.CreateWine(wine);
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
        return NoContent();
    }

    // DELETE: api/Wine/{guid}
    [HttpDelete("{productGuid}")]
    public async Task<IActionResult> DeleteWine(Guid productGuid)
    {
        await _productCommands.DeleteWine(productGuid);
        return NoContent();
    }
}
