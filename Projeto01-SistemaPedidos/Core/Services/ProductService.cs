using Projeto01_OrdersManager.Core.Models;
using Projeto01_OrdersManager.Repositories;

namespace Projeto01_OrdersManager.Core.Services {
  public class ProductService {
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository) {
      _productRepository = productRepository;
    }

    public async Task<List<Product>> GetProducts(IEnumerable<string> productsIds) {
      return await _productRepository.GetProducts(productsIds);
    }
  }
}