using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Domain.Base
{
    public abstract class DomainBase<TRepository, TEntity> : IDomainBase<TEntity>
         where TRepository : IGenericRepository<TEntity> where TEntity : IBaseClass
    {
        public TRepository _repository;

        protected DomainBase(TRepository repository)
        {
            _repository = repository;
        }

        public virtual TEntity Get(int id)
        {
            return _repository.ReadOne(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.Read();
        }

        public virtual IEnumerable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Read(expression);
        }

        public virtual TEntity Create(TEntity entity)
        {
            entity.AltaFecha = DateTime.Now;
            entity.Usuario = "prueba";
            return _repository.Create(entity);
        }

        public virtual void Update(TEntity entity)
        {
            entity.Usuario = "prueba";
            entity.ModiFecha = DateTime.Now;
            _repository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            entity.Baja = true;
            entity.ModiFecha = DateTime.Now;
            _repository.Update(entity);
        }

        public virtual void Save()
        {
            _repository.Save();
        }

        public void Remove(int id)
        {
            TEntity _entity = Get(id);
            _repository.Delete(_entity);
        }
    }
}
