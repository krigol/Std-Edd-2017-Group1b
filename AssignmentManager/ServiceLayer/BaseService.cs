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
        private BaseRepository<T> repository;

        public BaseService(BaseRepository<T> repo)
        {
            repository = repo;
        }
        
        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return repository.GetAll(filter);
        }

        public List<T> GetAll()
        {
            return repository.GetAll();
        }

        public T GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Delete(T entity)
        {
            repository.Delete(entity);
        }

        public void Save(T entity)
        {
            if (entity.Id <= 0)
            {
                repository.Insert(entity);
            }
            else
            {
                repository.Update(entity);
            }
        }

        private void Insert(T entity)
        {
            repository.Insert(entity);
        }

        private void Update(T entity)
        {
            repository.Update(entity);
        }

    }
}
