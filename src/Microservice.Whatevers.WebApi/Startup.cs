using Hellang.Middleware.ProblemDetails;
using Microservice.Whatevers.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Microservice.Whatevers.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddControllers();
            services.AddApiVersioning();
            services.AddSwaggerGen(c => c.SwaggerDoc("api-docs", new OpenApiInfo {Title = "Api Docs"}));
            services.AddProblemDetails();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHealthChecks("/health");
            app.UseProblemDetails();
            app.ConfigureExceptionHandler();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/api-docs/swagger.json", "Api Docs"));
        }
    }
}
