using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Code_First_5.Models
{
    public class Cmns:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}