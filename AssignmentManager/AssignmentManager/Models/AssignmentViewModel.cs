using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class AssignmentViewModel : BaseViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage="Please input at least 5 symbols")]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}