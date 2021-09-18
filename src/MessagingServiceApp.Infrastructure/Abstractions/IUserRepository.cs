using MessagingServiceApp.Infrastructure.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Infrastructure.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUsername(string username);
    }
}
