using DeveloperEvaluation.ProductsApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

builder.Configuration.AddJsonFile("appsettings.json", true, true)
                    .SetBasePath(environment.ContentRootPath)
                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
                    .AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ProductDBContext>(options =>
               options.UseNpgsql(
                   builder.Configuration.GetConnectionString("DefaultConnection")
               )
           );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

app.MapOpenApi();
app.UseSwaggerUI(opt => {

    opt.SwaggerEndpoint("/openapi/v1.json", "Products api");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
