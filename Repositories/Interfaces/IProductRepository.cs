using System;
using Vintage.Models;

namespace Vintage.Repositories.Interfaces
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();
		IEnumerable<Product> GetProductsByBrand(string marca);
		IEnumerable<Product> GetProductDetails(int id);
    }
}