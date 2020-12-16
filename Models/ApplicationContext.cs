using DemoProject.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Users
            modelBuilder.Entity<User>().HasData(
                new User{id = 1, name = "huy", email = "toilahuy098@gmail.com", phone = "0933691822", address = "binh thanh", password = "123456", avatar = "image/p1.png", level = true, status = true, create_at = DateTime.Now,update_at = DateTime.Now,},
                new User{id = 2, name = "chi", email = "thaochi098@gmail.com", phone = "0933691822", address = "quan 3", password = "123456", avatar = "image/p2.png", level = false, status = true, create_at = DateTime.Now,update_at = DateTime.Now,}
            );

            //Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { id = 1, userid = 1, name = "huy", email = "toilahuy098@gmail.com", phone = "0933691822", address = "binh thanh", status = true },
                new Order { id = 2, userid = 1, name = "huy", email = "toilahuy098@gmail.com", phone = "0933691822", address = "binh thanh", status = true }
                );
        }
    }
}
