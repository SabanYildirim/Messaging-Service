using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.Interfaces
{
    public interface IMessagingMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
