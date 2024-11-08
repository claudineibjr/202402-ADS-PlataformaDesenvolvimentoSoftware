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

        [HttpPost("{ProductId}/UploadImage")]
        public async Task<ActionResult<string>> UploadImage(string ProductId, IFormFile file)
        {
          if (file == null || file.Length == 0)
          {
              return BadRequest("No image found");
          }

          using var memoryStream = new MemoryStream();
          await file.CopyToAsync(memoryStream);

          var fileData = new FileData
          {
              FileName = file.FileName,
              Content = memoryStream.ToArray(),
              ContentType = file.ContentType,
              Extension = Path.GetExtension(file.FileName),
          };

          string imageUrl = await _productService.UploadProductImage(ProductId, fileData);

          return CreatedAtAction(nameof(UploadImage), imageUrl);
        }
    }
}
