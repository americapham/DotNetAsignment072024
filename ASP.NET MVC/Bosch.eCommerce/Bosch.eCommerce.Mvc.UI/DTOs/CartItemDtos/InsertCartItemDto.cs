namespace Bosch.eCommerce.Mvc.UI.DTOs.CartItemDtos
{
    public class InsertCartItemDto
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; } = 1;
        public int Size { get; set; } = 7;
    }
}
