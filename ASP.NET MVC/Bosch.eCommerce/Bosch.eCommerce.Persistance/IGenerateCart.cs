using Bosch.eCommerce.Models;

namespace Bosch.eCommerce.Persistance
{
    public interface IGenerateCart
    {
        Task<int> GenerateNewCart(int customerId);
        Task<List<MyCartVM>> GetCartItems(int cartId);
    }
}
