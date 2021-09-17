using MessagingServiceApp.Application.DTO.Request;
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

        [HttpGet("/getall")]
        public async Task<IActionResult> Get()
        {
            return Ok("");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]NewUserRequestModel newUserRequestModel )
        {
            
        }
    }
}
