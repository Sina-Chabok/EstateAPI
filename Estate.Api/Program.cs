using DataLayer.Contracts;
using DataLayer.Contracts.Contracts;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service.Busineses;
using Service.IBusineses;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });


builder.Services.AddDbContext<DefaultDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Estate API",
        Version = "v1",
        Description = "API for managing real estate entities."
    });
});
builder.Services.AddScoped<IEstateBusiness, EstateBusiness>();
builder.Services.AddScoped<IQueryRepository, QueryRepository>();
builder.Services.AddScoped<IEstateRepository, EstateRepository>();



var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estate API v1");
        c.RoutePrefix = string.Empty; // Swagger در مسیر اصلی بالا بیاد
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();