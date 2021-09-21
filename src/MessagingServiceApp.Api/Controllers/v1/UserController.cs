using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MessagingServiceApp.Api.Controllers.v1
{
   
    [Route("api/user")]
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

        [HttpPost]
        public async Task<IActionResult> Create(NewUserRequestModel newUserRequestModel )
        {
            return Ok(await _userServices.Add(newUserRequestModel));
        }
    }
}
