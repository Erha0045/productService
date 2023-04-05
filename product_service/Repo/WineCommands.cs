using Microsoft.EntityFrameworkCore;
using product_service.Data;
using product_service.RabbitMQ;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace product_service.Repo
{
    public class WineCommands
    {
        private readonly ProductContext _repository;
        private readonly RabbitMQProducer _rabbitMQProducer;

        public WineCommands(ProductContext repository)
        {
            _repository = repository;
        }

        // Create Wine
        public async Task<Wine> CreateWine(Wine wine)
        {
            // Create the new wine
            wine.ProductGuid = Guid.NewGuid();
            wine.ModifiedDate = DateTime.Now;
            _repository.WineProducts.Add(wine);
            await _repository.SaveChangesAsync();

            // Publish a message to RabbitMQ with the new wine information
            var message = new { ActionType = "Create", Wine = wine };
            _rabbitMQProducer.PublishMessage(message);

            return wine;
        }

        // Update Wine
        public async Task<Wine> UpdateWine(Wine wine)
        {
            _repository.Entry(wine).State = EntityState.Modified;
            await _repository.SaveChangesAsync();
            return wine;
        }

        // Delete Wine
        public async Task DeleteWine(Guid productGuid)
        {


            var wine = await _repository.WineProducts.FirstOrDefaultAsync(i=>i.ProductGuid==productGuid);
            if (wine != null)
            {
                _repository.WineProducts.Remove(wine);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
