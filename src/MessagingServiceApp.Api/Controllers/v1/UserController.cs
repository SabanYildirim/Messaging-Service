using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("/getall")]
        public async Task<IActionResult> Get()
        {
            return Ok("");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]NewUserRequestModel newUserRequestModel )
        {
            return Ok(_userServices.Add(newUserRequestModel));
        }
    }
}
