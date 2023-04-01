using Microsoft.EntityFrameworkCore;

namespace product_service.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options){
        }
        public DbSet<Wine> Wine { get; set; }
    }
}
