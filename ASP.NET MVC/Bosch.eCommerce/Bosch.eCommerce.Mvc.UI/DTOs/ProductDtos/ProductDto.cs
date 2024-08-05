namespace Bosch.eCommerce.Mvc.UI.DTOs.ProductDtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Picture { get; set; }
        public int CategoryId { get; set; }
    }
}
