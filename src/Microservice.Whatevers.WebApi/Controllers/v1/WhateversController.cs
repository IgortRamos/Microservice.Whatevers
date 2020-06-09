using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Services;
using Microservice.Whatevers.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Whatevers.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class WhateversController : ApiControllerBase
    {
        private readonly IWhateverService _whateverService;

        public WhateversController(IWhateverService whateverService)
        {
            _whateverService = whateverService;
        }

        [HttpGet]
        public Task<List<Whatever>> GetAllAsync(CancellationToken cancellationToken) => 
            _whateverService.GetAllAsync(cancellationToken);

        [HttpPost]
        public Task<Whatever> PostAsync([FromBody] WhateverModel model, CancellationToken cancellationToken) =>
            _whateverService.SaveAsync(model, cancellationToken);
    }
}