using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class CommentViewModel : BaseViewModel
    {
        public string Content { get; set; }

        public int AssignmentId { get; set; }
    }
}