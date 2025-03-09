using DeveloperEvaluation.CartsApi.Application.Queries;
using DeveloperEvaluation.CartsApi.Data;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.Core.Utils;
using DeveloperEvaluation.Core.Web;
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

builder.Services.AddDbContext<CartsDBContext>(options =>
               options.UseNpgsql(
                   builder.Configuration.GetConnectionString("DefaultConnection")
               ).EnableSensitiveDataLogging()
                .UseLazyLoadingProxies()
           );

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(Program).Assembly
    );
});

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(PagedMappingProfile).Assembly);

builder.Services.AddScoped<IDbContext, CartsDBContext>();
builder.Services.AddScoped<ICartsQueries, CartsQueries>();

DependencyResolver.RegisterDependencies(builder);


var app = builder.Build();
app.UseMiddleware<ValidationExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}
app.MapOpenApi();
app.UseSwaggerUI(opt => {

    opt.SwaggerEndpoint("/openapi/v1.json", "Carts api");
});

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

/*update database*/
using (var scope = app.Services.CreateScope())
{
    using (var appContext = scope.ServiceProvider.GetRequiredService<CartsDBContext>())
    {
        try
        {
            appContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}

app.Run();
