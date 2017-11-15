﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public int AssignmentId { get; set; }

        public virtual Assignment Assignmnet { get; set; }
    }
}