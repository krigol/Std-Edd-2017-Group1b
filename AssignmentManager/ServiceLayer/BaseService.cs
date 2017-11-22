using DataAccess.Entities;
using DataAccess.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class BaseService<T>
        where T : BaseEntity
    {
        protected BaseRepository<T> _repository;

        public BaseService(BaseRepository<T> repo)
        {
            _repository = repo;
        }
        
        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _repository.GetAll(filter);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public void Save(T entity)
        {
            if (entity.Id <= 0)
            {
                _repository.Insert(entity);
            }
            else
            {
                _repository.Update(entity);
            }
        }

        private void Insert(T entity)
        {
            _repository.Insert(entity);
        }

        private void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
