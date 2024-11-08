using Core.Models;

namespace Core.Services
{
    public interface IProductService
    {
        public Task<Product> GetProduct(string productId);
        public Task<List<Product>> GetProducts(List<string> productsIds);
    }
}
