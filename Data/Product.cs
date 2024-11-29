
using System.ComponentModel.DataAnnotations;

namespace website.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public decimal? Price { get; set; }

        public string? Image { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int? CategoryId { get; set; }


    }
}