using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class BaseListViewModel<Y>
        where Y : BaseListViewModel
    {
        public List<Y> List { get; }

        public BaseListViewModel()
        {
            List = new List<Y>();
        }
    }
}