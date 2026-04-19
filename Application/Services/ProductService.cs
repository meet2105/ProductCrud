using product0419.Application.DTOs;
using product0419.Application.Interfaces;
using product0419.Domain.Entities;

namespace product0419.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Product> CreateAsync(Product dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };

            await _repo.AddAsync(product);
            await _repo.SaveAsync();

            return product;
        }

        public async Task<bool> UpdateAsync(int id, Product dto)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            _repo.Update(product);
            await _repo.SaveAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return false;

            _repo.Delete(product);
            await _repo.SaveAsync();

            return true;
        }
    }
}