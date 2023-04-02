using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace product_service.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Wine> WineProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>()
                    .ToTable("wine_products")
                    .Property(w => w.Id)
                    .HasColumnName("wine_id");
            modelBuilder.Entity<Category>()
                    .ToTable("wine_categories")
                    .HasKey(c => c.Id);
        }
    }
}
