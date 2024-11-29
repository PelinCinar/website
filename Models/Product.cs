using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class Product
    {
        [Display(Name = "Ürün ID")]
        public int ProductId { get; set; }

        [Display(Name = "Ürün Adı")]

        public string Name { get; set; } = string.Empty;//içinde boş bile kalsa bunu dolu bir veri gibi al demiş oluyoruz.
        [Display(Name = "Ürün Fiyatı")]

        public decimal Price { get; set; }
        
        [Display(Name = "Ürün Görseli")]
        public string Image { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
    }
}