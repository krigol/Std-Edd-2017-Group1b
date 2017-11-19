using DataAccess.Entities;
using DataAccess.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AssignmentService : BaseService<Assignment>
    {
        public AssignmentService(BaseRepository<Assignment> repository)
            : base(repository)
        {

        }
    }
}
