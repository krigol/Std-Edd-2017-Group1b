using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int AssignmentId { get; set; }
    }
}