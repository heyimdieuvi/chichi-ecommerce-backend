
using ChiChiEcommerce.Application.DTOs;
//using ChiChiEcommerce.Application.Services;
using ChiChiEcommerce.Application.UseCases.AuthUseCase;
using ChiChiEcommerce.Domain.Repositories;
//using ChiChiEcommerce.Domain.Usecases;
using ChiChiEcommerce.Infrastructure;
using ChiChiEcommerce.Infrastructure.Data;
using ChiChiEcommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký các dependency cho Clean Architecture
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<CreateShopUseCase>();
builder.Services.AddScoped<ShopService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<CreateProductUseCase>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CreateCategoryUseCase>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<RegisterUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//Map route
app.MapControllers();

app.Run();
