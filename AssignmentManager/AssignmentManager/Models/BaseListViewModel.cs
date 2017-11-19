using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class BaseListViewModel<T> 
        where T : BaseViewModel
    {
        public List<T> EntryList { get; private set; }

        public BaseListViewModel()
        {
            EntryList = new List<T>();
        }
    }
}