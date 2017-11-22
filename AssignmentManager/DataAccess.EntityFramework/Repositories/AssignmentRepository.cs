using DataAccess.Entities;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Repositories
{
    public class AssignmentRepository : BaseRepository<Assignment>
    {
        public AssignmentDueDateDatabaseInfoDto GetAssignemntDueDateInfoDto(int id)
        {
            var query = from assignment in context.Assignments
                        where assignment.Id == id
                        select new AssignmentDueDateDatabaseInfoDto 
                        {
                            DueDate = assignment.DueDate
                        };

            return query.FirstOrDefault();
        }
    }
}
