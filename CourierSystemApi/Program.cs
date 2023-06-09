using CourierSystemBusinessLayer.Services;
using CourierSystemDataLayer.Data;
using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddScoped<IShipmentInfo, ShipmentInfoRepository>();
builder.Services.AddScoped<ShipmentInfoService>();
builder.Services.AddScoped<OrderPlaceService>();
builder.Services.AddScoped<IShipperInfo, ShipperInfoRepository>();
builder.Services.AddScoped<ShipperService>();
builder.Services.AddScoped<ICustomer,CustomerRepository>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<IAdmin, AdminRepository>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
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
