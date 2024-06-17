using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vintage.Models;
using Vintage.Repositories;
using Vintage.Repositories.Interfaces;
using Vintage.ViewModels;

namespace Vintage.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<Users> _userManager;
        private readonly IOrderRepository _orderRepository;

        public CartController(ICartRepository cartRepository, UserManager<Users> userManager, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        private string GetUserId()
        {
            return _userManager.GetUserId(User);
        }

        public IActionResult Index()
        {
            var userId = GetUserId();
            var cartItems = _cartRepository.GetCartItems(userId);

            var viewModel = new CartViewModel
            {
                Cart = cartItems
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var userId = GetUserId();
            _cartRepository.AddToCart(userId, productId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var userId = GetUserId();
            _cartRepository.RemoveFromCart(userId, productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            var userId = GetUserId();
            _cartRepository.ClearCart(userId);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var userId = _userManager.GetUserId(User);
            var cartItems = _cartRepository.GetCartItems(userId);

            var viewModel = new CartViewModel
            {
                Cart = cartItems
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            var userId = _userManager.GetUserId(User);
            var cartItems = _cartRepository.GetCartItems(userId);

            if (!cartItems.Any())
            {
                return RedirectToAction("Index");
            }

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = cartItems.Sum(item => item.Quantity * item.Product.Preco),
                Status = "Entregue",
                OrderItem = cartItems.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                }).ToList()
            };

            _orderRepository.AddOrder(order);
            _cartRepository.ClearCart(userId);

            return RedirectToAction("Index");
        }
    }
}
