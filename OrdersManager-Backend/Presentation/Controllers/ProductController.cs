using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IProductService _productService;

        public ProductController(IAuthService authService, IProductService productService)
        {
            _authService = authService;
            _productService = productService;
        }

        [HttpGet("{ProductId}")]
        public async Task<Product> GetProduct(string ProductId) {
          return await _productService.GetProduct(ProductId);
        }
    }
}
