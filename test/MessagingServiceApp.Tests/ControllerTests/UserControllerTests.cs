using AutoFixture;
using MessagingServiceApp.Api.Controllers.v1;
using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MessagingServiceApp.Tests.ControllerTests
{
    public class UserControllerTests
    {
        private readonly UserController _sut;
        private readonly Fixture _fixture = new Fixture();
        private readonly NewUserRequestModel _newUserRequestModel;
        private readonly Mock<IUserServices> _userService;
        private readonly Mock<ILogger<UserController>> _ILogger;

        public UserControllerTests()
        {
            _newUserRequestModel = _fixture.Create<NewUserRequestModel>();
            _userService = new Mock<IUserServices>();
            _ILogger = new Mock<ILogger<UserController>>();
            _sut = new UserController(_userService.Object, _ILogger.Object);
        }

        [Fact]
        public void UserCreate_Should_Return_As_Expected()
        {
            //Act
            var actual = _sut.Create(_newUserRequestModel).GetAwaiter().GetResult();

            //Assert
            actual.GetType().Equals(StatusCodes.Status200OK);
        }
    }
}
