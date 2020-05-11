using Hellang.Middleware.ProblemDetails;
using Microservice.Whatevers.Repositories.IoC;
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

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddControllers();
            services.AddApiVersioning();
            services.AddMvcCore(options => options.SuppressAsyncSuffixInActionNames = false);
            services.AddSwaggerGen(c => c.SwaggerDoc("api-docs", new OpenApiInfo {Title = "Api Docs"}));
            services.AddProblemDetails();
            services.AddRepository();
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
            app.UseProblemDetails();
        }
    }
}
