using product0419.Application.DTOs;
using product0419.Domain.Entities;

namespace product0419.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetInStockProductsAsync();
    }
}
