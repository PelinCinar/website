
using System.ComponentModel.DataAnnotations;

namespace website.Data
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Writer { get; set; }
        public string? Image { get; set; } = string.Empty;
    }
}