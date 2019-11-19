﻿using Project_ATP2.Interfaces;
using Project_ATP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ATP2.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ProjectDBEntities Context;

        public Repository(ProjectDBEntities Context)
        {
            this.Context = Context;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}