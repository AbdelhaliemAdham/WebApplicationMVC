using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, string? includeParameters)
        {
            IQueryable<T> query = dbSet;

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            if (!string.IsNullOrEmpty(includeParameters))
            {
                foreach (string param in includeParameters.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(param);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, string? includeParameters = null)
        {
            IQueryable<T> query = dbSet;

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            if (!string.IsNullOrEmpty(includeParameters))
            {
                foreach (string param in includeParameters.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(param);
                }
            }

            return await query.ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity is not null)
            {
                await dbSet.AddAsync(entity);
                await SaveAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}