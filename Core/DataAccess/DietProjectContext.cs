using DietProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.DataAccess
{
    public class DietProjectContext : DbContext
    {
        public DietProjectContext() : base()
        {
         
        }

        // @"Server=.\SQLEXPRESS;Database=DietSystem;Trusted_Connection=True;"

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DietDetail> DietDetails { get; set; }
        public DbSet<Dietitian> Dietitians { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
