using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace product_service
{
    public class Wine : IProduct
    {
        [Column("wine_id")]
        public int Id { get; set; }
        [Column("product_uuid")]
        public Guid ProductGuid { get; set; }
        [Column("wine_name")]
        public string Name { get; set; }
        [Column("wine_description")]
        public string Description { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("wine_origin")]
        public string Origin { get; set; }
        [Column("alcohol_percentage")]
        public float AlcoholPercentage { get; set; }
        [Column("production_year")]
        public int Year { get; set; }
        [Column("image")]
        public string Image { get; set; }
        [Column("bottle_size")]
        public string Size { get; set; }
        [Column("wine_category_id")]
        public int CategoryId { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
        //public ICollection<WineRemoved> Removed { get; set; } = new List<WineRemoved>();
        //public ICollection<Wine> WineDes { get; set; } = new List<Wine>();
    }

}

