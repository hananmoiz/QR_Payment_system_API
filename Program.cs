using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QR_Payment_System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // Add controllers service for routing
builder.Services.AddDbContext<QrPaymentSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Connection to the database

// Add Swagger support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "QR_Payment_System API",          
        Description = "Managing QR_Payment_System",  
        Version = "v1"                     
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "QR_Payment_System V1");
    });
}

app.UseHttpsRedirection();

app.MapControllers(); // This will map all controller routes, including PaymentsController

app.Run();
