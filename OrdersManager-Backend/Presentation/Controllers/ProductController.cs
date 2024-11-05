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

          string fileExtension = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1);

          string folderName = "products";
          string productsUploadFolderPath = Path.Combine("wwwroot", folderName);
          Directory.CreateDirectory(productsUploadFolderPath);

          string fileName = $"{ProductId}.{fileExtension}";
          string filePath = Path.Combine(productsUploadFolderPath, fileName);

          using (var stream = new FileStream(filePath, FileMode.Create))
          {
            await file.CopyToAsync(stream);
          }

          string imageUrl = $"/{folderName}/{fileName}";

          return CreatedAtAction(nameof(UploadImage), imageUrl);
        }
    }
}
