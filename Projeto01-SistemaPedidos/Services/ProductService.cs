using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts(List<string> productsIds)
        {
            return await _productRepository.GetProducts(productsIds);
        }
    }
}
