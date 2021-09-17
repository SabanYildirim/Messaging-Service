using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingServiceApp.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserServices userServices, ILogger<UserController> logger)
        {
            _userServices = userServices;
            _logger = logger;
        }

        [HttpGet("/getall")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok("");
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(string username,string password)
        {
            return Ok(await _userServices.Login(username,password));
        }

        [HttpPost("/add")]
        public async Task<IActionResult> Add(NewUserRequestModel newUserRequestModel )
        {
            _logger.LogInformation($"Random Value is test");

            return Ok(await _userServices.Add(newUserRequestModel));
        }
    }
}
