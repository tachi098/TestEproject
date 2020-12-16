using DemoProject.Entities;
using DemoProject.Seeders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Orderdetail> Orderdetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var mainSeeder = new ApplicationSeeders();
            new ApplicationSeeders().OnModelSeeders(modelBuilder);
        }
    }
}
