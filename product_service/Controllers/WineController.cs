using Microsoft.AspNetCore.Mvc;
using product_service.Repo;

namespace product_service.Controllers;

// Tilføjet senere end mødet
[Route("api/[controller]")]
[ApiController]
public class WineController : Controller
{

    private readonly WineQueries _productQueries;


    public WineController(WineQueries productQueries)
    {
        _productQueries = productQueries;
    }


    // GET: Products
    [HttpGet]
    //[HttpGet("Wine")]
    public async Task<IActionResult> Index()
    {
        return View(await _productQueries.ListProducts());
    }

}

