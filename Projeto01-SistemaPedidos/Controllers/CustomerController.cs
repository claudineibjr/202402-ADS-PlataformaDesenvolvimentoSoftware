using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        
        private readonly OrdersDbContext _context;

        public CustomerController(OrdersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
    }

}
