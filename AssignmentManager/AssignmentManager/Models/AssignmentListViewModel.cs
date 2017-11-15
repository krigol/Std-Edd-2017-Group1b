﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class AssignmentListViewModel : BaseListViewModel
    {
        public string Title { get; set; }

        public List<AssignmentViewModel> Assignments { get; private set; }

        public AssignmentListViewModel()
        {
            Assignments = new List<AssignmentViewModel>();
        }
    }
}