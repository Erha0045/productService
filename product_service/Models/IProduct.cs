using System;
namespace product_service
{
	public interface IProduct
	{
        public int WineId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Origin { get; set; }

        public IFormFile Image { get; set; }
    }
}

