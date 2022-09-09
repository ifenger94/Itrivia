using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace ITrivia.Contracts.Repository
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> Read();
        IEnumerable<TEntity> Read(Expression<Func<TEntity,bool>> expression);
        TEntity ReadOne(int id);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
