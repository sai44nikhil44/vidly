using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace vidly.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<movie> Movies { get; set; }
        public DbSet<MembershipType> membershipTypes { get; set; }
        public MyDbContext()
        {
            
        }
    }
}