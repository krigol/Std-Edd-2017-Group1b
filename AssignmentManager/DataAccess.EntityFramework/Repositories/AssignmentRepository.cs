using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Repositories
{
    public class AssignmentRepository
    {
        private AssignmentManagerDbContext context;
        private DbSet<Assignment> dbSet;

        public AssignmentRepository()
        {
            context = new AssignmentManagerDbContext();
            dbSet = context.Set<Assignment>();
        }

        public List<Assignment> GetAll()
        {
            return dbSet.ToList();
        }

        public Assignment GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(Assignment entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(Assignment entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Assignment entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
