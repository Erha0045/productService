using Microsoft.EntityFrameworkCore;
using product_service.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace product_service.Repo
{
    public class WineQueries
    {
        private readonly ProductContext _repository;

        public WineQueries(ProductContext repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<Wine>> ListProducts()
        {
            var result = await _repository.WineProducts
                .Select(wine => new Wine
                {
                    Id = wine.Id,
                    ProductGuid = wine.ProductGuid,
                    Name = wine.Name,
                    Description = wine.Description,
                    Price = wine.Price,
                    Origin = wine.Origin,
                    AlcoholPercentage = wine.AlcoholPercentage,
                    Year = wine.Year,
                    Image = wine.Image,
                    Size = wine.Size,
                    CategoryId = wine.CategoryId,
                    ModifiedDate = wine.ModifiedDate
                })
                .ToListAsync();
            return result;
        }

        public async Task<Wine> GetWine(Guid productGuid)
        {
            return await _repository.WineProducts.FirstOrDefaultAsync(w => w.ProductGuid == productGuid);
        }

        private static Wine MapWineModel(Guid productGuid, Wine wine)
        {
            return new Wine { ProductGuid = productGuid, Name = wine?.Name, };
        }
    }
}
