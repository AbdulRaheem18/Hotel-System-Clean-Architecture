using Microsoft.EntityFrameworkCore;
using application.Repositories;
using domain.entities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using application.common;
using System.Linq;
namespace infrastructure.Persistence
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext context;
        public BaseRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

         public async Task<PagedList<TEntity>> GetPaged(BasePagedRequest request)
        {
            var list = await context.Set<TEntity>().ToListAsync();
            return PagedList<TEntity>.ToPagedList(list.AsQueryable(),request.PageNumber,request.PageSize);
        }


        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

    }
}