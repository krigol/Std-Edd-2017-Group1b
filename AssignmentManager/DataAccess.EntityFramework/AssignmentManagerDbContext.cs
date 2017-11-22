using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class AssignmentManagerDbContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public AssignmentManagerDbContext()
            : base("AssignmentManagerEf")
        {

        }
    }
}
