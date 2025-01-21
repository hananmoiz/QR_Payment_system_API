# QR_Payment_system_API

## Setup Instructions

1. Create a new web project:

    ```bash
    dotnet new web -o QR_Payment_System -f net8.0
    cd QR_Payment_System  # Make sure you're in your project directory
    ```

2. Install required packages:

    ```bash
    dotnet add package Microsoft.EntityFrameworkCore.sqlserver
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite 
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Swashbuckle.AspNetCore --version 6.5.0
    dotnet add package Microsoft.AspNetCore.OpenApi --version 7.0.0
    ```

## Initial Program Setup

Replace the contents of your Program.cs with:

```csharp
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
    
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
    
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "QR_Payment_System API V1");
   });
}
    
app.MapGet("/", () => "Welcome to QR_Payment_System!");
    
app.Run();
```

## Database Setup

To scaffold your database context, run:

```bash
dotnet ef dbcontext scaffold "Server=(localdb)\MSSQLLocalDB;Database=qr_payment_system;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
```
