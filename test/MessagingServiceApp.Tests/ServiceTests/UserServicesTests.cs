using AutoFixture;
using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.DTO.Response;
using MessagingServiceApp.Application.Interfaces;
using MessagingServiceApp.Application.Services;
using MessagingServiceApp.Infrastructure.Abstractions;
using MessagingServiceApp.Infrastructure.BusinessEntities;
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
    public class UserServicesTests
    {
        private readonly UserServices _sut;
        private readonly Fixture _fixture = new Fixture();
        private readonly Mock<IUserRepository> _userRepository;
        private readonly UserEntity _user;
        private readonly UserModel _userModel;
        private readonly Mock<IMessagingMapper> _mapper;
        private readonly SuccessResponse _successResponse;
        private readonly NewUserRequestModel _newUserRequestModel;
        private readonly string _username;

        public UserServicesTests()
        {
            _user = _fixture.Create<UserEntity>();
            _successResponse = _fixture.Create<SuccessResponse>();
            _mapper = new Mock<IMessagingMapper>();
            _userRepository = new Mock<IUserRepository>();
            _userModel = _fixture.Create<UserModel>();
            _sut = new UserServices(_userRepository.Object, _mapper.Object);
            _newUserRequestModel = _fixture.Create<NewUserRequestModel>();
            _username = _fixture.Create<string>();
        }

        [Fact]
        public void MessageAdd_Should_Return_As_Expected()
        {
            //Arrange
            _userRepository.Setup(c => c.Add(_user)).Returns(Task.FromResult(_user));
            _mapper.Setup(x => x.Map<UserEntity, SuccessResponse>(_user)).Returns(_successResponse);

            //Act
            var actual = _sut.Add(_newUserRequestModel).GetAwaiter().GetResult();

            //Assert
            actual.Success = true;
        }

        [Fact]
        public void GetUserByUsername_Should_Return_As_Expected()
        {
            //Arrange
            _userRepository.Setup(c => c.GetUserByUsername(_username)).Returns(Task.FromResult(_user));
            _mapper.Setup(x => x.Map<UserEntity, UserModel>(_user)).Returns(_userModel);

            //Act
            var actual = _sut.GetUserByUsername(_username).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(actual);
        }
    }
}
