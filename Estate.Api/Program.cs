using DataLayer.Contracts;
using DataLayer.Contracts.Contracts;
using DataLayer.Models;
using Estate.Api.Extensions;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.Busineses;
using Service.IBusineses;
using System.Text;
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

// Dependency Injection
services.AddScoped<IEstateBusiness, EstateBusiness>();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<IQueryRepository, QueryRepository>();
services.AddScoped<IEstateRepository, EstateRepository>();
services.AddScoped<IUserBusiness, UserBusiness>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// ✅ JWT Authentication Configuration
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (string.IsNullOrWhiteSpace(jwtKey))
    throw new InvalidOperationException("Jwt:Key is not configured in appsettings.json");

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // ❗ در لوکال و تست غیرفعال کن
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),

        ClockSkew = TimeSpan.Zero // بدون تأخیر در انقضای توکن
    };
});

// ✅ CORS (فعلاً کاملاً آزاد)
services.AddCors(options =>
{
    options.AddPolicy("anyCors",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();



// ✅ Middleware pipeline
app.UseMiddleware<Estate.Public.Middlewares.ExceptionMiddleware>();
app.UseFromSwagger();
app.UseHttpsRedirection();

// ترتیب خیلی مهمه 👇
app.UseCors("anyCors");          // اول CORS
app.UseAuthentication();         // بعد Authentication
app.UseAuthorization();          // بعد Authorization

app.MapControllers();
app.Run();
