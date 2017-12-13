using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonStore.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext()
            : base("name=PersonContext")
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}