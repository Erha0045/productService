using Microsoft.AspNetCore.Mvc;
using product_service.Repo;

namespace product_service.Controllers;


public class ProductsController : Controller
{
 
        private readonly ProductQueries productQueries;


        public ProductsController(ProductQueries productQueries)
        {
            this.productQueries = productQueries;
        }
     

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await productQueries.ListProducts());
        }
   
}

