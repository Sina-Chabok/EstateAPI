using DataLayer.Contracts;
using DataLayer.Contracts.Contracts;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Service.Busineses;
using Service.IBusineses;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();


services.AddDbContext<DefaultDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<IEstateRepository, EstateRepository>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IEstateImageRepository, EstateImageRepository>();
services.AddScoped<IQueryRepository, QueryRepository>();


services.AddScoped<IEstateBusiness, EstateBusiness>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
