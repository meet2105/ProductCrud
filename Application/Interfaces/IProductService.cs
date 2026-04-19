using product0419.Application.DTOs;
using product0419.Domain.Entities;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product dto);
    Task<bool> UpdateAsync(int id, Product dto);
    Task<bool> DeleteAsync(int id);
}
