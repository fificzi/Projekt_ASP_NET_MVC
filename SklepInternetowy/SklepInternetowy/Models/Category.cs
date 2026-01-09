using System.ComponentModel.DataAnnotations;

namespace SklepInternetowy.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
