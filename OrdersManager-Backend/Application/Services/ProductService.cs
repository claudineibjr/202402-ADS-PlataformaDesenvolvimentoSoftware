using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageService _imageService;

        public ProductService(IProductRepository productRepository, IImageService imageService)
        {
            _productRepository = productRepository;
            _imageService = imageService;
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

        public async Task<string> UploadProductImage(string productId, FileData file)
        {
          Product product = await GetProduct(productId);

          string uploadedFileUrl = await _imageService.UploadImage(file, "products", productId);

          product.ImageUrl = uploadedFileUrl;

          await _productRepository.UpdateProduct();

          return uploadedFileUrl;
        }
  }
}
