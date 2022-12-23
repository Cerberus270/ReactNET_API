using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using ReactNET_API.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    // Wildcard * allow all origins
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
