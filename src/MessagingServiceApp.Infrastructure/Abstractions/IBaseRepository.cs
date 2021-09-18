using MessagingServiceApp.Infrastructure.BusinessEntities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Infrastructure.Abstractions
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        T GetById(Guid id);
        void Remove(Guid id);
        Task<IEnumerable<T>> GetAll();
        void Update(T entity);
    }
}
