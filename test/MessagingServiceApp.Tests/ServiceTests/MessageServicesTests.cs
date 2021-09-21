using AutoFixture;
using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.DTO.Response;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Application.Services;
using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.BusinessEntities;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MessagingServiceApp.Tests.ServiceTests
{
    public class MessageServicesTests
    {
        private readonly MessageService _sut;
        private readonly Fixture _fixture = new Fixture();
        private readonly Mock<IMessageRepository> _messageRepository;
        private readonly Mock<IConfiguration> _IConfiguration;
        private readonly MessageEntity _message;
        private readonly MessageHistoryResponse _messageHistoryResponse;
        private readonly Mock<IMessagingMapper> _mapper;
        private readonly SuccessResponse _successResponse;       
        private readonly string _username;
        private readonly string _receiverUserName;
        private readonly string _sender;
        private readonly string _userMessage;
        private readonly Mock<IUserServices> _userService;
        private readonly IEnumerable<MessageEntity> _messageList;
        private readonly List<MessageHistoryResponse> _messageHistory;


        public MessageServicesTests()
        {
            _message = _fixture.Create<MessageEntity>();
            _successResponse = _fixture.Create<SuccessResponse>();
            _messageList = _fixture.Create<IEnumerable<MessageEntity>>();
            _messageHistory = _fixture.Create<List<MessageHistoryResponse>>();
            _userMessage = _fixture.Create<string>();
            _sender = _fixture.Create<string>();
            _username = _fixture.Create<string>();
            _receiverUserName = _fixture.Create<string>();

            _mapper = new Mock<IMessagingMapper>();
            _messageRepository = new Mock<IMessageRepository>();
            _IConfiguration = new Mock<IConfiguration>();
            _userService = new Mock<IUserServices>();
            _sut = new MessageService(_messageRepository.Object, _IConfiguration.Object, _userService.Object, _mapper.Object);
        }

        [Fact]
        public void SendMessage_Should_Return_As_Expected()
        {
            //Arrange
            _messageRepository.Setup(c => c.Add(_message)).Returns(Task.FromResult(_message));
            _mapper.Setup(x => x.Map<MessageEntity, SuccessResponse>(_message)).Returns(_successResponse);

            //Act
            var actual = _sut.SendMessage(_receiverUserName, _userMessage,_sender).GetAwaiter().GetResult();

            //Assert
            actual.Success = true;
        }

        [Fact]
        public void GetMessageHistory_Should_Return_As_Expected()
        {
            //Arrange
            _messageRepository.Setup(c => c.GetMessageHistory(_username, _receiverUserName)).Returns(Task.FromResult(_messageList));
            _mapper.Setup(x => x.Map<MessageEntity, SuccessResponse>(_message)).Returns(_successResponse);

            //Act
            var actual = _sut.GetMessageHistory(_username, _receiverUserName).GetAwaiter().GetResult();

            //Assert
            Assert.IsType<List<MessageHistoryResponse>>(actual);
        }
    }
}
