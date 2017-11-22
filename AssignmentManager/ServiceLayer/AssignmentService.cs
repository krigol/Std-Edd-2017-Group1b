using DataAccess.Entities;
using DataAccess.EntityFramework.Repositories;
using DataContracts;
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

        public AssignmentDueDateServiceInfoDto GetDetails(int id)
        {
            var repo = (AssignmentRepository)_repository;
            var databaseDto = repo.GetAssignemntDueDateInfoDto(id);

            var serviceDto = new AssignmentDueDateServiceInfoDto
            {
                DueDate = databaseDto.DueDate
            };

            serviceDto.DaysLeft = (serviceDto.DueDate - DateTime.Now).TotalDays;

            return serviceDto;
        }
    }
}
