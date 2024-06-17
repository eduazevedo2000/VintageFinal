using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using Vintage.Context;
using Vintage.Models;
using Vintage.Repositories.Interfaces;

namespace Vintage.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Products => _context.Products;
        public IEnumerable<Category> Categories => _context.Categories;

        public IEnumerable<Product> GetProducts() 
        {
            var products = _context.Products.ToList();
            
            return products;
        }

        public IEnumerable<Product> GetProductsByBrand(string marca)
        {
            var products = _context.Products.Where(p => p.Marca == marca).ToList();

            return products;
        }

        public IEnumerable<Product> GetProductDetails(int id)
        {
            var product = _context.Products.Where(p => p.ProductId == id);

            return product;
        }
    }
}