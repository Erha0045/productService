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
            var result = await _repository.Wine
                .Where(wine => !wine.Removed.Any())
                .Select(
                    wine =>
                        new
                        {
                            wine.ProductGuid,
                            Wine = wine.WineDes
                                .OrderByDescending(d => d.ModifiedDate)
                                .FirstOrDefault()
                        }
                )
                .ToListAsync();

            return result.Select(row => MapWineModel(row.ProductGuid, row.Wine)).ToList();
        }

        public async Task<Wine> GetWine(Guid productGuid)
        {
            return await _repository.Wine.FirstOrDefaultAsync(w => w.ProductGuid == productGuid);
        }

        private static Wine MapWineModel(Guid productGuid, Wine wine)
        {
            return new Wine { ProductGuid = productGuid, Name = wine?.Name, };
        }
    }
}
