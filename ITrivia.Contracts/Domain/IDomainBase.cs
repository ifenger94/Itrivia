using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ITrivia.Contracts.Domain
{
    public interface IDomainBase<TEntity>
    {
        TEntity Create(TEntity entity);
        void Delete(TEntity entity);
        void Remove(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllBy(Expression<Func<TEntity,bool>> expression);
        void Save();
        void Update(TEntity entity);
    }
}