
using ChiChiEcommerce.Application.DTOs;
using ChiChiEcommerce.Application.Services;
using ChiChiEcommerce.Domain.Repositories;
using ChiChiEcommerce.Domain.Usecases;
using Infrastructure.Data;
using ChiChiEcommerce.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký các dependency cho Clean Architecture
builder.Services.AddScoped<ShopRepository, ShopRepositoryImpl>();
builder.Services.AddScoped<CreateShopUseCase>();
builder.Services.AddScoped<ShopService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/shops", async (ShopDto shopDto, ShopService shopService) =>
{
    if (shopDto == null || string.IsNullOrEmpty(shopDto.Name))
    {
        return Results.BadRequest("Shop name is required.");
    }

    try
    {
        await shopService.CreateShopAsync(shopDto);
        return Results.Ok("Shop created successfully.");
    }
    catch (Exception ex)
    {
        return Results.StatusCode(500);
    }
})
.WithName("CreateShop")
.WithOpenApi();

app.Run();
