using Core.Models;

namespace Core.Repositories
{
    public interface IProductRepository
    {
        public Task<Product?> GetProduct(string productsId);
        public Task<List<Product>> GetProducts(List<string> productsIds);
    }
}
