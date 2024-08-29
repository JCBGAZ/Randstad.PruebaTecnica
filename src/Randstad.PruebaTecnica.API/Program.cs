using Randstad.PruebaTecnica.API.Middleware;
using Randstad.PruebaTecnica.Application;
using Randstad.PruebaTecnica.Infrastructure;
using LazyCache;
using Microsoft.OpenApi.Models;

namespace Randstad.PruebaTecnica.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpClient();
            builder.Services.AddServicesInfrastructure(builder.Configuration);
            builder.Services.AddServicesApplication();
            builder.Services.AddSingleton<IAppCache, CachingService>();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Products", Version = "v1" });
            });

            var app = builder.Build();

            app.UseMiddleware<RequestTiming>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Products v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
