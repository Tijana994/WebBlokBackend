﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RentACarApp.Repo
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
        
    {
        protected readonly DbContext Context;

       
        public Repository(DbContext applicationDbContext)
        {
            Context = applicationDbContext;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().Where(expression);
        }

        public TEntity Get(int key)
        {
            return Context.Set<TEntity>().Find(key);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        
    }
}