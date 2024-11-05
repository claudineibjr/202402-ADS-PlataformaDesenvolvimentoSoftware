using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProduct(string productsId)
        {
          Product? product = await _productRepository.GetProduct(productsId);
          if (product == null) {
            throw new Exception("Product not found");
          }

          return product;
        }

        public async Task<List<Product>> GetProducts(List<string> productsIds)
        {
            return await _productRepository.GetProducts(productsIds);
        }
    }
}
