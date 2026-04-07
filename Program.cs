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

// Base de datos 
builder.Services.AddDbContext<SuperDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SupermercadoDB")));

// Repositorios 
builder.Services.AddScoped<InterfaceCategoriaRepository, CategoriasRepository>();
builder.Services.AddScoped<InterfaceClienteRepository, ClienteRepository>();
builder.Services.AddScoped<InterfaceEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<InterfaceProductoRepository, ProductoRepository>();

// Domain Services 
builder.Services.AddScoped<CategoriaDomainService>();
builder.Services.AddScoped<ClienteDomainService>();
builder.Services.AddScoped<EmpleadoDomainService>();
builder.Services.AddScoped<ProductoDomainService>();

// App Services 
builder.Services.AddScoped<ICategoriaAppService, CategoriaAppService>();
builder.Services.AddScoped<IClienteAppService,   ClienteAppService>();
builder.Services.AddScoped<IEmpleadoAppService,  EmpleadoAppService>();
builder.Services.AddScoped<IProductoAppService,  ProductoAppService>();


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
