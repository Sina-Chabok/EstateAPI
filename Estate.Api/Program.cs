using DataLayer.Contracts;
using DataLayer.Contracts.Contracts;
using Estate.Api.Extensions;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Service.Busineses;
using Service.IBusineses;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });


services.AddDbContext<DefaultDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Swagger configuration
services.AddSwagger();

services.AddScoped<IEstateBusiness, EstateBusiness>();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<IQueryRepository, QueryRepository>();
services.AddScoped<IEstateRepository, EstateRepository>();

services.AddCors(options =>
{
    options.AddPolicy("anyCors",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

//ToDo(Exeption Handeling)

var app = builder.Build();

app.UseFromSwagger();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("anyCors");
app.Run();