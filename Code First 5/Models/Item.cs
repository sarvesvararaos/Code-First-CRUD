using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_5.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemCount { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}