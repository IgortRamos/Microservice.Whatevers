using System;
using System.Net;
using System.Net.Http;
using Hellang.Middleware.ProblemDetails;
using Microservice.Whatevers.Repositories.IoC;
using Microservice.Whatevers.Services.IoC;
using Microservice.Whatevers.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;

namespace Microservice.Whatevers.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            services.AddHealthChecks();
            services.AddControllers();
            services.AddApiVersioning();
            services.AddMvcCore(options => options.SuppressAsyncSuffixInActionNames = false);
            services.AddSwaggerGen(c => c.SwaggerDoc("api-docs", new OpenApiInfo {Title = "Api Docs"}));
            services.AddProblemDetails();
            services.AddDbContext(options => options.ConnectionString = Configuration.GetConnectionString("DefaultConnection"));
            services.AddAutoMapper();
            services.AddServices();
            services.AddRepository();
            services.AddHttpClient("google", c => 
                c.BaseAddress = new Uri(Configuration["UrlBaseGoogle"])).AddPolicyHandler(GetRetryPolicy());
            services.AddTokenAuthentication();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseHealthChecks("/health");
            app.UseProblemDetails();
            app.ConfigureExceptionHandler();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/api-docs/swagger.json", "Api Docs"));
            app.UseProblemDetails();
        }
        
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
            => HttpPolicyExtensions.HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }
}
