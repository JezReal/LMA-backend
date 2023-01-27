using System.Net;
using System.Text;
using LMA_backend.Auth.Repositories;
using LMA_backend.Auth.Services;
using LMA_backend.Books.Repositories;
using LMA_backend.Books.Services;
using LMA_backend.Data;
using LMA_backend.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Yoh.Text.Json.NamingPolicies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LmaContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("LMAConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicies.SnakeCaseLower;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Variables:SigningKey").Value)),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetSection("Variables:Issuer").Value.ToString(),
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetSection("Variables:Audience").Value.ToString()
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var error = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (error is ResourceNotFoundException)
        {
            context.Response.StatusCode = (int) HttpStatusCode.NotFound;
            await context.Response.WriteAsJsonAsync(new
            {
                Message = error.Message
            });
        }

        if (error is BadRequestException)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new
            {
                Message = error.Message
            });
        }
    });
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();