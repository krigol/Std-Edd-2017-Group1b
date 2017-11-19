using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class CommentListViewModel : BaseListViewModel<CommentViewModel>
    {
        public int AssignmentId { get; set; }
    }
}