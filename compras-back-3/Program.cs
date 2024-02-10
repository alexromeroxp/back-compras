using compras_back_3.Context;
using compras_back_3.Repository.ArticuloRepository;
using compras_back_3.Repository.ClienteRepository;
using compras_back_3.Repository.TiendaRepository;
using compras_back_3.Services.ArticuloService;
using compras_back_3.Services.ClientesService;
using compras_back_3.Services.TiendaService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("comprasdb"));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ITiendaService, TiendaService>();
builder.Services.AddScoped<ITiendaRepository, TiendaRepository>();
builder.Services.AddScoped<IArticuloService, ArticuloService>();
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();


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
