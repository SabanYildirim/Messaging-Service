using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.DTO.Response;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.BusinessEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Services
{
    public class MessageService : IMessageServices
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IConfiguration _configuration;
        private readonly IUserServices _userService;

        public MessageService(IMessageRepository messageRepository, IConfiguration configuration, IUserServices userServices)
        {
            _messageRepository = messageRepository;
            _configuration = configuration;
            _userService = userServices;
        }

        public async Task<SuccessResponse> SendMessage(string receiverUserName, string message, string sender)
        {
            var user = _userService.GetUserByUsername(receiverUserName);
            if (user == null)
            {
                throw new Exception("User not found or given information is wrong");
            }

            Message entity = new Message();
            entity.ReceiverUsername = receiverUserName;
            entity.UserMessage = message;
            entity.SenderUsername = sender;
            entity.CreateDate = DateTime.Now;

            var messageEntity = await _messageRepository.Add(entity);

            return new SuccessResponse()
            {
                 Success = messageEntity != null,
            };
        }

        public async Task<List<MessageHistoryResponse>> GetMessageHistory(string username, string targetUsername)
        {
            var message = await _messageRepository.GetMessageHistory(username, targetUsername);

            var model = message.Select(x => new MessageHistoryResponse
            {
                ReceiverUserName = x.ReceiverUsername,
                SendDate = x.CreateDate,
                SenderUserName = x.SenderUsername,
                UserMessage = x.UserMessage
            }).OrderByDescending(x => x.SendDate).ToList();

            return model;
        }
    }
}
