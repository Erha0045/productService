using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace product_service
{
    public class Wine : IProduct
    {
        public Guid ProductGuid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Origin { get; set; }
        public int AlcoholPercentage { get; set; }
        public int Year { get; set; }
        public IFormFile Image { get; set; }
        public string Size { get; set; }
        public Category Category { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<WineRemoved> Removed { get; set; } = new List<WineRemoved>();

        public ICollection<Wine> WineDes { get; set; } = new List<Wine>();
    }

}

