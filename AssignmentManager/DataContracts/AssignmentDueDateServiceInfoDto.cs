﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public class AssignmentDueDateServiceInfoDto
    {
        public DateTime DueDate { get; set; }

        public double DaysLeft { get; set; }
    }
}
