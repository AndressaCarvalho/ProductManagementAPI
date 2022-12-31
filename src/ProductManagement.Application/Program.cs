using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.DTOs.Mapping;
using ProductManagement.Domain.Interfaces;
using ProductManagement.Infra.Data.Context;
using ProductManagement.Infra.Data.Repository;
using ProductManagement.Service.Services;
using System.Text.Json.Serialization;

using IHost host = Host.CreateDefaultBuilder(args).Build();

var builder = WebApplication.CreateBuilder(args);
var configuration = host.Services.GetRequiredService<IConfiguration>();

// Add services to the container.
builder.Services.AddDbContext<ProductManagementContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IProviderService<>), typeof(ProviderService<>));
builder.Services.AddScoped(typeof(IProductService<>), typeof(ProductService<>));
builder.Services.AddScoped(typeof(IProviderRepository<>), typeof(ProviderRepository<>));
builder.Services.AddScoped(typeof(IProductRepository<>), typeof(ProductRepository<>));

builder.Services.AddAutoMapper(typeof(ProviderMapDTO));
builder.Services.AddAutoMapper(typeof(ProductMapDTO));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
