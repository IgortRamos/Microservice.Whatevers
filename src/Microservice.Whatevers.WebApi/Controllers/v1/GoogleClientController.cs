using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Services;
using Microservice.Whatevers.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class GoogleClientController : ApiControllerBase
    {
        private readonly IGoogleService _googleService;

        public GoogleClientController(IGoogleService googleService)
        {
            _googleService = googleService;
        }

        [HttpGet]
        public Task<GoogleClientModel> GetAsync(CancellationToken cancellationToken) =>
            _googleService.GetAsync(cancellationToken);
    }
}