using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccess.Entities
{
    public class Assignment
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}