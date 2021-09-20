using AutoMapper;
using MessagingServiceApp.Application.DTO.Request;
using MessagingServiceApp.Application.DTO.Response;
using MessagingServiceApp.Infrastructure.BusinessEntities;

namespace MessagingServiceApp.Application.Mapping
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<MessageEntity, MessageHistoryResponse>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
