using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Seeders
{
    public class ApplicationSeeders
    {
        public void OnModelSeeders(ModelBuilder modelBuilder)
        {
            //User
            new UserSeeders(modelBuilder);

            //Order
            new OrderSeeders(modelBuilder);

            //OrderDetail
            new OrderDetailSeeders(modelBuilder);
        }
    }
}
