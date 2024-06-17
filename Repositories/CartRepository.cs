using Microsoft.EntityFrameworkCore;
using Vintage.Context;
using Vintage.Models;
using Vintage.Repositories.Interfaces;

namespace Vintage.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cart> GetCartItems(string userId)
        {
            return _context.Cart.Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ToList();
        }

        public void AddToCart(string userId, int productId, int quantity)
        {
            var cartItem = _context.Cart.SingleOrDefault(c => c.UserId == userId && c.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new Cart { UserId = userId, ProductId = productId, Quantity = quantity };
                _context.Cart.Add(cartItem);
            }
            _context.SaveChanges();
        }

        public void RemoveFromCart(string userId, int productId)
        {
            var cartItem = _context.Cart.SingleOrDefault(c => c.UserId == userId && c.ProductId == productId);
            if (cartItem != null)
            {
                _context.Cart.Remove(cartItem);
                _context.SaveChanges();
            }
        }

        public void ClearCart(string userId)
        {
            var cartItems = _context.Cart.Where(c => c.UserId == userId).ToList();
            _context.Cart.RemoveRange(cartItems);
            _context.SaveChanges();
        }
    }
}
