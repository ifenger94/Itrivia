
using ITrivia.Contracts.Repository;
using ITrivia.Types.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.DataAccess.Repository
{
    public abstract class GenericRepository<TContext, TEntity> : IGenericRepository<TEntity>
        where TContext : DbContext, new() where TEntity : class, IBaseClass
    {
        private TContext context;

        public TContext Context
        {
            get { return context; }
            set { context = value; }
        }

        public GenericRepository()
        {
        }

        private void OpenConnection()
        {
            if (context != null) context.Dispose();
            context = new TContext();
        }

        public TEntity Create(TEntity entity)
        {
            OpenConnection();
            Context.Set<TEntity>().Add(entity);
            Save();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            OpenConnection();
            Context.Entry(entity).State = EntityState.Deleted;
            Save();
        }

        public IEnumerable<TEntity> Read()
        {
            OpenConnection();
            return Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Read(Expression<Func<TEntity, bool>> expression)
        {

            OpenConnection(); 
            return Context.Set<TEntity>().Where(expression);
        }

        public TEntity ReadOne(int id)
        {
            OpenConnection();
            return Context.Set<TEntity>().Find(id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            OpenConnection();
            Context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}
