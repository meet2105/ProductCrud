using Microsoft.EntityFrameworkCore;
using product0419.Application.Interfaces;
using product0419.Domain.Entities;
using product0419.Infrastructure.Data;
using product0419.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetInStockProductsAsync()
    {
        return await _context.Products
            .Where(p => p.Stock > 0)
            .AsNoTracking() // ✅ performance optimization
            .ToListAsync();
    }
}