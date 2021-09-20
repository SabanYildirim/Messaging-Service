using AutoFixture;
using MessagingServiceApp.Api.Controllers.v1;
using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MessagingServiceApp.Tests.ControllerTests
{
    public class AuthenticationControllerTests
    {
        private readonly AuthenticationController _sut;
        private readonly Fixture _fixture = new Fixture();
        private readonly UserLoginRequestModel _userLoginRequestModel;
        private readonly Mock<IAuthenticationService> _IauthenticationService;

        public AuthenticationControllerTests()
        {
            _userLoginRequestModel = _fixture.Create<UserLoginRequestModel>();
            _IauthenticationService = new Mock<IAuthenticationService>();
            _sut = new AuthenticationController(_IauthenticationService.Object);
        }

        [Fact]
        public void Login_Should_Return_As_Expected()
        {
            //Act
            var actual = _sut.Login(_userLoginRequestModel).GetAwaiter().GetResult();

            //Assert
            actual.GetType().Equals(StatusCodes.Status200OK);
        }
    }
}
