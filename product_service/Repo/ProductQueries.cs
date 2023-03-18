using Microsoft.EntityFrameworkCore;
using product_service.Data;
using System.Collections.Generic;
namespace product_service.Repo
{
    public class ProductQueries
    {
        private readonly ProductContext repository;

        public ProductQueries(ProductContext repository)
        {
            this.repository = repository;
        }

        public async Task<List<Wine>> ListProducts()
        {
            var result = await repository.Wine
                .Where(wine => !wine.Removed.Any())
                .Select(wine => new
                {
                    wine.ProductGuid,
                    Wine = wine.WineDes
                        .OrderByDescending(d => d.ModifiedDate)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return result
                .Select(row => MapWineModel(row.ProductGuid, row.Wine))
                .ToList();
        }

           private static Wine MapWineModel(Guid productGuid, Wine wine)
        {
            return new Wine
            {
                ProductGuid = productGuid,
                Name = wine?.Name        
            };
        }

    }
}
