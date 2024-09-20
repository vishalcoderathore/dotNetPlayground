using DotNetAPI.Data;
using DotNetAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Setup database context (DataContextEF)
builder.Services.AddDbContext<DataContextEF>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the UserRepository for dependency injection
builder.Services.AddScoped<UserRepository>();

// Add AutoMapper with the assembly containing the profiles (if not already added)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Setup CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", corsBuilder =>
    {
        corsBuilder
            .WithOrigins(
                "http://localhost:4200",
                "http://localhost:3000",
                "http://localhost:8000",
                "http://localhost:8080",
                "http://localhost:5000"
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials(); // Use if you need credentials (cookies, etc.)
    });

    options.AddPolicy("ProdCors", corsBuilder =>
    {
        corsBuilder
            .WithOrigins("https://myProductionSite.com")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials(); // Use if you need credentials
    });
});

builder.Services.AddScoped<IUserRespository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection(); // Ensure HTTPS redirection comes before UseCors
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection(); // Ensure HTTPS redirection comes before UseCors
    app.UseCors("ProdCors");
}

app.MapControllers();

app.Run();
