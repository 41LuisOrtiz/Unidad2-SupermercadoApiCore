using Microsoft.EntityFrameworkCore;
using SuperMercadoWebApplication.Features.SuperMercado.Interfaces;
using SuperMercadoWebApplication.Features.SuperMercado.AppService;
using SuperMercadoWebApplication.Features.SuperMercado.DomainService;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Repositories;
using SuperMercadoWebApplication.Infraestructure.Database;
using SuperMercadoWebApplication.Infraestructure.Interfases;
using Microsoft.Data.SqlClient;
using SuperMercadoWebApplication.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SuperDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SuperDb")));

builder.Services.AddScoped<InterfaceCategoriaRepository , CategoriaRepository>();
builder.Services.AddScoped<InterfaceClienteRepository , ClienteRepository>();
builder.Services.AddScoped<InterfaceEmpleadoRepository , EmpleadoRepository>();
builder.Services.AddScoped<InterfaceProductoRepository , ProductoRepository>();

// Registro del Servicio de Dominio
builder.Services.AddScoped<CategoriaDomainService, CategoriaDomainService>();
builder.Services.AddScoped<ClienteDomainService, ClienteDomainService>();
builder.Services.AddScoped<EmpleadoDomainService, EmpleadoDomainService>();
builder.Services.AddScoped<ProductoDomainService, ProductoDomainService>();

// App Services 
builder.Services.AddScoped<ICategoriaAppService, CategoriaAppService>();
builder.Services.AddScoped<IClienteAppService, ClienteAppService>();
builder.Services.AddScoped<IEmpleadoAppService, EmpleadoAppService>();
builder.Services.AddScoped<IProductoAppService, ProductoAppService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
