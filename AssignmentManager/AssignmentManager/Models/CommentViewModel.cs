using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManager.Models
{
    public class CommentViewModel : BaseViewModel
    {
        public string Content { get; set; }

        public int AssignmentId { get; set; }

        public int AssignmentDropdownId { get; set; }

        public List<SelectListItem> AssignmentList { get; set; }
    }
}