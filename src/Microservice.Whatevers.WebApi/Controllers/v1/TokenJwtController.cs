using Microservice.Whatevers.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class TokenJwtController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpGet]  
        public string GetRandomToken() => 
            new JwtService().GenerateSecurityToken();
    }
}