using System;
using System.Runtime.InteropServices;

namespace product_service
{
	public class Wine : IProduct
	{
        public int id { get; set; }
        public string name { get; set; }
        public string description { get ; set; }
        public decimal price { get; set; }
        public string origin { get; set; }
        public int alcoholPercentage { get; set; }
        public int year { get; set; }
        public IFormFile image { get; set; }
        public string size { get; set; }
        public Category category { get; set; }

 
        public Wine()
		{
		}

        public Wine(int id, string name, string description, decimal price,
            string origin, int alcoholPercentage, int year, IFormFile image, string size, Category category)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.origin = origin;
            this.alcoholPercentage = alcoholPercentage;
            this.year = year;
            this.image = image;
            this.size = size;
            this.category = category;
        }
    }

}

