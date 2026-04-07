var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registro de Domain Services
builder.Services.AddScoped<IProductoDomainService, ProductoDomainService>();

// Registro de App Services
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
