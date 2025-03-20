using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;
using WebAPI.Extensions;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebApplication1 API",
                    Version = "v1",
                    Description = "API Description"
                });
            });

            builder.Services.ConfigureInfrastructure(builder.Configuration);
            builder.Services.ConfigureApplication();

            builder.Services.ConfigureApiBehavior();
            builder.Services.ConfigureCorsPolicy();

            var app = builder.Build();

   
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseErrorHandler();
            app.UseCors();
            app.MapControllers();
            app.Run();
        }
    }
}