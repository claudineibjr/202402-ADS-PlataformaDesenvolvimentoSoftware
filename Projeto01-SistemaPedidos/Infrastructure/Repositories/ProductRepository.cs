using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.Core.Models;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager.Repositories
{
    public class ProductRepository
    {
        private readonly OrdersDbContext _context;

        public ProductRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts(IEnumerable<string> productsIds)
        {
            List<Product> products = await _context
                .Products
                .Where(p => productsIds.Contains(p.Id))
                .ToListAsync();

            return products;
        }
    }
}
