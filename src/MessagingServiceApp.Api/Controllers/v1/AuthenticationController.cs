using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingServiceApp.Api.Controllers.v1
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationServices;

        public AuthenticationController(IAuthenticationService authenticationServices)
        {
            _authenticationServices = authenticationServices;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel userLoginRequest)
        {
            return Ok(await _authenticationServices.Login(userLoginRequest));
        }
    }
}
