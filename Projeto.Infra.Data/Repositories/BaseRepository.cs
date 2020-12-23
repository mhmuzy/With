﻿using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Context;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {

        private readonly SqlServerContext context;

        protected BaseRepository(SqlServerContext context)
        {
            this.context = context;
        }

        public void Create(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }
        public void Update(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

    }
}
