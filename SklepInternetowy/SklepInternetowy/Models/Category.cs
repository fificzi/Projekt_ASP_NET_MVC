using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.ComponentModel.DataAnnotations;
namespace SklepInternetowy.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}