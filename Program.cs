using Microsoft.EntityFrameworkCore;
using product0419.Application.Interfaces;
using product0419.Application.Services;
using product0419.Infrastructure.Data;
using product0419.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// --------------------
// Add Services
// --------------------

builder.Services.AddControllers();

// ✅ Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ DbContext (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// ✅ Dependency Injection (Repository + Service)
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// --------------------
// Build App
// --------------------

var app = builder.Build();

// --------------------
// Middleware Pipeline
// --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();