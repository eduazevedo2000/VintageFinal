using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vintage.Models;
using Vintage.Repositories.Interfaces;
using Vintage.ViewModels;

namespace Vintage.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Home()
        {
            var products = _productRepository.GetProducts();

            var viewModel = new ProductViewModel
            {
                Products = products
            };

            return View(viewModel);
        }

        public IActionResult Brand(string brand)
        {
            if (string.IsNullOrEmpty(brand))
            {
                return RedirectToAction("Home");
            }

            var products = _productRepository.GetProductsByBrand(brand);

            var viewModel = new ProductViewModel
            {
                Products = products
            };

            return View(viewModel);
        }
        [Authorize]
        public IActionResult ProductDetails(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return RedirectToAction("Home");
            }

            var products = _productRepository.GetProductDetails(id);

            var viewModel = new ProductViewModel
            {
                Products = products
            };

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
