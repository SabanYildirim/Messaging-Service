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
        public MessageService(IMessageRepository messageRepository, IConfiguration configuration)
        {
            _messageRepository = messageRepository;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<bool>> SendMessage(UserSenderMessageRequestModel userSenderMessageRequest, string sender)
        {
            Message entity = new Message();

            entity.ReceiverUserName = userSenderMessageRequest.ReceiverUserName;
            entity.Message = userSenderMessageRequest.Message;
            entity.SenderUserName = sender;

            var message = await _messageRepository.Add(entity);

            return new ServiceResponse<bool>()
            {
                Value = message != null,
            };
        }
    }
}
