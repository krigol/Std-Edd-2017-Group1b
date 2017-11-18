using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class AssignmentListViewModel : BaseListViewModel<AssignmentViewModel>
    {
        public string Title { get; set; }
    }
}