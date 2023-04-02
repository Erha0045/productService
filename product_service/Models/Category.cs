using System.ComponentModel.DataAnnotations.Schema;

namespace product_service
{
    public class Category
    {
        [Column("category_id")]
        public int Id { get; set; }
        [Column("category_name")]
        public string Name { get; set; }
    }
}