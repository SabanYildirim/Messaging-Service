using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingServiceApp.Api.Controllers.v1
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageServices _messageServices;

        public MessageController(IMessageServices messageServices)
        {
            _messageServices = messageServices;   
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SendMessage(SendMessageRequestModel userSenderMessageRequestModel)
        {
            return Ok(await _messageServices.SendMessage(userSenderMessageRequestModel.ReceiverUserName, userSenderMessageRequestModel.Message, HttpContext.Items["username"].ToString()));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MessageHistory(string targetUsername)
        {
            return Ok(await _messageServices.GetMessageHistory(HttpContext.Items["username"].ToString(), targetUsername));
        }
    }
}
