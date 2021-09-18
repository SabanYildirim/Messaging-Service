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
        private readonly IMessageServices _messageServices;

        public UserController(IUserServices userServices, IMessageServices messageServices, ILogger<UserController> logger)
        {
            _userServices = userServices;
            _messageServices = messageServices;
            _logger = logger;
        }

        [HttpGet("/getall")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok("");
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromQuery]UserLoginRequestModel userLoginRequest)
        {
            return Ok(await _userServices.Login(userLoginRequest));
        }

        [HttpPost("/add")]
        public async Task<IActionResult> Add(NewUserRequestModel newUserRequestModel )
        {
            _logger.LogInformation($"Random Value is test");

            return Ok(await _userServices.Add(newUserRequestModel));
        }

        [HttpPost("/sendMessage")]
        [Authorize]
        public async Task<IActionResult> SendMessage(UserSenderMessageRequestModel userSenderMessageRequestModel)
        {
            return Ok(await _messageServices.SendMessage(userSenderMessageRequestModel, HttpContext.Items["username"].ToString()));
        }
    }
}
