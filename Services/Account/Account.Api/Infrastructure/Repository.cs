using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Account.Api.Infrastructure
{
    public abstract class Repository 
    {
        private readonly DbContext dbContext;
        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> SaveAsync<TEntity>(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(SaveAsync)} entity cannot be null");
            }

            try
            {
                await dbContext.AddAsync(entity);
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<IList<TEntity>> GetAll<TEntity>() where TEntity : class, new()
        {
            try
            {
                var list = dbContext.Set<TEntity>().ToList();
                return await Task.Run(() => list);                               
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }            
        }

        public async Task<int> UpdateAsync<TEntity>(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                dbContext.Update(entity);
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public async Task<IList<TEntity>> GetList<TEntity>(Func<TEntity, bool> where
            , params Expression<Func<TEntity, object>>[] navigationProperties) where TEntity : class, new()
        {
            List<TEntity> list;
             
                IQueryable<TEntity> dbQuery = dbContext.Set<TEntity>();

                //Apply eager loading
                foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

                list = dbQuery  
                    .Where(where)
                    .ToList();

            return await Task.Run(() => list);             
        }        
    }
}
