using AutoMapper;
using MessagingServiceApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Mapping
{
    public class AutoMapping : IMessagingMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new BusinessProfile()));

            IMapper mapper = mapperConfig.CreateMapper();

            return mapper.Map<TDestination>(source);
        }
    }
}
