using System;
namespace product_service
{
	public interface IProduct
	{
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public string origin { get; set; }

        public IFormFile image { get; set; }
    }
}

