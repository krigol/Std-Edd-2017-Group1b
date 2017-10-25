using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Repositories
{
    public class CommentRepository
    {
        private AssignmentManagerDbContext context;
        private DbSet<Comment> dbSet;

        public CommentRepository()
        {
            context = new AssignmentManagerDbContext();
            dbSet = context.Set<Comment>();
        }

        public List<Comment> GetAll(Expression<Func<Comment,bool>> filter)
        {
            return dbSet.Where(filter).ToList();
        }

        public List<Comment> GetAll()
        {
            return dbSet.ToList();
        }

        public Comment GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(Comment entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Comment entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
