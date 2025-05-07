using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Streamer.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder
    .Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDataContext>(options=>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    builder.Services
        .AddScoped<IFilmeRepository, FilmeRepository>();
    builder.Services
        .AddScoped<ICategoriaRepository, CategoriaRepository>();
        

builder.Services.AddControllers()
    .AddJsonOptions(x =>
         x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
