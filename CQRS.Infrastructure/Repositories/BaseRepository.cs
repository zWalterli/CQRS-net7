using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CQRS.Infrastructure.Repositories
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private readonly APIContext _context;
        public BaseRepository(APIContext contextAPI)
        {
            _context = contextAPI;
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public virtual async Task<T> AddAsync(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<List<T>> AddAsync(List<T> models)
        {
            await _context.Set<T>().AddRangeAsync(models);
            await _context.SaveChangesAsync();
            return models;
        }

        public virtual async Task<List<T>> ListAsync(Func<T, bool> predicate)
        {
            var models = _context.Set<T>().AsNoTracking().Where(predicate);
            return await Task.FromResult(models.ToList());
        }

        public virtual async Task<List<T>> ListAsync(Func<T, bool> predicate, int page, int pageSize, params Expression<Func<T, Object>>[] includes)
        {
            var skip = pageSize * (page - 1);
            var query = _context.Set<T>().AsNoTracking();

            if (includes is not null && includes.Any())
                foreach (var include in includes)
                    query = query.Include(include);

            var models = query.Skip(skip).Take(pageSize).Where(predicate);
            return await Task.FromResult(models.ToList());
        }

        public virtual async Task<List<T>> ListAsync(int page, int pageSize, params Expression<Func<T, Object>>[] includes)
        {
            var skip = pageSize * (page - 1);
            var query = _context.Set<T>().AsNoTracking();

            if (includes is not null && includes.Any())
                foreach (var include in includes)
                    query = query.Include(include);

            var models = query.Skip(skip).Take(pageSize);
            return await Task.FromResult(models.ToList());
        }

        public virtual async Task<T> UpdateAsync(T model)
        {
            // _context.Entry(model).State = EntityState.Modified;
            _context.Entry(model).State = EntityState.Detached;
            _context.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<List<T>> UpdateAsync(List<T> models)
        {
            // _context.Entry(models).State = EntityState.Modified;
            _context.Entry(models).State = EntityState.Detached;
            _context.UpdateRange(models);
            await _context.SaveChangesAsync();
            return models;
        }

        public async Task<List<T>> ListAsync(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            if (includes is not null && includes.Any())
                foreach (var include in includes)
                    query = query.Include(include);

            return await Task.FromResult(query.Where(predicate).ToList());
        }

        public virtual async Task RemoveAsync(T model)
        {
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(List<T> models)
        {
            foreach (var model in models)
                _context.Set<T>().Remove(model);

            await _context.SaveChangesAsync();
        }
    }
}
