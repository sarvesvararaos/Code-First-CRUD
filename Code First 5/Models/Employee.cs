using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_5.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EName { get; set; }
        public int ItemId { get; set; }
        public virtual Item item { get; set; }
    }
}