using Vintage.Models;

namespace Vintage.Repositories.Interfaces
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetCartItems(string userId);
        void AddToCart(string userId, int productId, int quantity);
        void RemoveFromCart(string userId, int productId);
        void ClearCart(string userId);
    }
}
