using System.Collections.Generic;
using System.Threading.Tasks;
using domain.entities;
using System;
using application.common;

namespace application.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<PagedList<T>> GetPaged(BasePagedRequest request);
        Task<T> Get(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
    }
}