using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fuzion.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fuzion.API.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _ctx;

        public Repository(DbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _ctx.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _ctx.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public void Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Detached;
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}