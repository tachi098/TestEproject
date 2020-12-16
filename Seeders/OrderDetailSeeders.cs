using DemoProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Seeders
{
    public class OrderDetailSeeders
    {
        public OrderDetailSeeders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orderdetail>().HasData(
            new Orderdetail { id = 1, detail = "Nokia"}
        );
        }
    }
}
