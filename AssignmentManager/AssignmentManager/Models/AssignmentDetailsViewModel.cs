using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class AssignmentDetailsViewModel
    {
        public DateTime DueDate { get; set; }

        public double DaysLeft { get; set; }
    }
}