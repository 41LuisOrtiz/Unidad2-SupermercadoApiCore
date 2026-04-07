var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registro del Servicio de Dominio
builder.Services.AddScoped<ICategoriaDomainService, CategoriaDomainService>();
// Registro del Servicio de Aplicación 
builder.Services.AddScoped<ICategoriaAppService, CategoriaAppService>();

builder.Services.AddScoped<IProductoDomainService, ProductoDomainService>();
builder.Services.AddScoped<IProductoAppService, ProductoAppService>();

builder.Services.AddScoped<IClienteDomainService, ClienteDomainService>();
builder.Services.AddScoped<IClienteAppService, ClienteAppService>();

builder.Services.AddScoped<IProductoDomainService, ProductoDomainService>();
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
