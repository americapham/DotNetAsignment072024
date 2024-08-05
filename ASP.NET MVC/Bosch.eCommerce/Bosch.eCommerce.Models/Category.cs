using System.ComponentModel.DataAnnotations;

namespace Bosch.eCommerce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is a required field!")]
        [MaxLength(100, ErrorMessage = "Category name can not exceed 100 characters!")]
        public string CategoryName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Category name is a required field!")]
        [MaxLength(200, ErrorMessage = "Category name can not exceed 200 characters!")]
        public string Description { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; set; }
    }
}

