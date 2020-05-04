using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.WebApi.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app) =>
            app.UseExceptionHandler(appError => 
                appError.Run(context =>
                {
                    var error = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    if(error == default) return Task.CompletedTask;
                    var problem = MakeProblem(error);
                    return MakeResponse(context, problem);
                }));

        private static Task MakeResponse(HttpContext context, ProblemDetails problem)
        {
            context.Response.StatusCode =  problem.Status ?? (int) HttpStatusCode.InternalServerError;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            var json = JsonSerializer.Serialize(problem);
            return context.Response.WriteAsync(json);
        }

        private static ProblemDetails MakeProblem(Exception ex) =>
            ex is BusinessException
                ? new ProblemDetails
                {
                    Title = "Erro da requisição",
                    Detail =  ex.Message,
                    Status = (int) HttpStatusCode.BadRequest
                }
                : new ProblemDetails
                {
                    Title = ex.Message,
                    Detail = ex.StackTrace
                };
    }
}