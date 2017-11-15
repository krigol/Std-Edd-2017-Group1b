using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class CommentListViewModel : BaseListViewModel
    {
        public List<CommentViewModel> Comments { get; set; }

        public CommentListViewModel()
        {
            Comments = new List<CommentViewModel>();
        }
    }
}