using SMS_Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data_Layer.Repositories.Interfaces.Base
{
    public interface IKernelRepository<T> where T : IBaseEntity
    {
        Task<List<T>> GetAll();
        Task<List<T>> Get(Expression<Func<T, bool>> expression);
        Task<T> GetById(int id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression);

        Task<bool> Any(Expression<Func<T, bool>> expression);

        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
