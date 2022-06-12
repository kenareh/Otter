using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Otter.DataAccess.Repositories;

namespace Otter.DataAccess.SQLServer.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class

    {
        protected ApplicationDbContext context;
        protected DbSet<TEntity> set;

        protected BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            set = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return set;
        }

        public virtual void Add(TEntity entity)
        {
            set.Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            set.AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            set.Remove(entity);
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            set.RemoveRange(entities);
        }

        public virtual IQueryable<TEntity> Find()
        {
            return set;
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return set.Where(predicate);
        }

        public virtual void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            context.Entry(entities).State = EntityState.Modified;
        }
    }
}