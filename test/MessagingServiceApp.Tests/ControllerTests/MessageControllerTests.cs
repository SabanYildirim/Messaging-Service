using AutoFixture;
using MessagingServiceApp.Api.Controllers.v1;
using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MessagingServiceApp.Tests.ControllerTests
{
    public class MessegeControllerTests
    {
        private readonly MessageController _sut;
        private readonly Fixture _fixture = new Fixture();
        private readonly SendMessageRequestModel _sendMessageRequestModel;
        private readonly string _targerUserName;
        private readonly Mock<IMessageServices> _messageService;
        private readonly Mock<ILogger<MessageController>> _ILogger;

        public MessegeControllerTests()
        {
            _sendMessageRequestModel = _fixture.Create<SendMessageRequestModel>();
            _targerUserName = _fixture.Create<string>();
            _messageService = new Mock<IMessageServices>();
            _ILogger = new Mock<ILogger<MessageController>>();
            _sut = new MessageController(_messageService.Object);

        }

        [Fact]
        public void SendMessage_Should_Return_As_Expected()
        {
            //Act
            var actual = _sut.SendMessage(_sendMessageRequestModel).GetAwaiter().GetResult();

            //Assert
            actual.GetType().Equals(StatusCodes.Status200OK);
        }

        [Fact]
        public void GetMessageHistory_Should_Return_As_Expected()
        {
            //Act
            var actual = _sut.MessageHistory(_targerUserName).GetAwaiter().GetResult();

            //Assert
            actual.GetType().Equals(StatusCodes.Status200OK);
        }
    }
}
