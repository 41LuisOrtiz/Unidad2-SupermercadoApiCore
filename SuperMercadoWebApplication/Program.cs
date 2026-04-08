using Microsoft.EntityFrameworkCore;
using SuperMercadoWebApplication.Features.SuperMercado.Interfaces;
using SuperMercadoWebApplication.Features.SuperMercado.AppService;
using SuperMercadoWebApplication.Features.SuperMercado.DomainService;
using SuperMercadoWebApplication.Entities.Supermercado;
using SuperMercadoWebApplication.Infraestructure.Repositories;
using SuperMercadoWebApplication.Infraestructure.Database;
using SuperMercadoWebApplication.Infraestructure.Interfases;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//DB CONTECXT
builder.Services.AddDbContext<SuperDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.


builder.Services.AddScoped<InterfaceCategoriaRepository, CategoriasRepository>();
builder.Services.AddScoped<InterfaceClienteRepository, ClienteRepository>();
builder.Services.AddScoped<InterfaceEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<InterfaceProductoRepository, ProductoRepository>();

// Registro del Servicio de Dominio
builder.Services.AddScoped<CategoriaDomainService, CategoriaDomainService>();
builder.Services.AddScoped<ClienteDomainService, ClienteDomainService>();
builder.Services.AddScoped<EmpleadoDomainService, EmpleadoDomainService>();
builder.Services.AddScoped<ProductoDomainService, ProductoDomainService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//SWAGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

