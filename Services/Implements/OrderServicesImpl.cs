using DemoProject.Entities;
using DemoProject.Models;
using DemoProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Services.Implements
{
    public class OrderServicesImpl : IOrderServices
    {
        private ApplicationContext context; 

        public OrderServicesImpl(ApplicationContext context)
        {
            this.context = context;
        }
        public List<Order> GetOrders()
        {
            var list = context.Order.ToList();
            return list;
        }

        public List<Order> GetOrdersByUserId(int userid)
        {
            var list = context.Order.Where(o => o.userid == userid).ToList();
            return list;
        }

        public void UpdateStatus(int id)
        {
            var model = context.Order.SingleOrDefault(o => o.id == id);
            if (model.status == true)
            {
                model.status = false;
                context.SaveChanges();
            }
            else
            {
                model.status = true;
                context.SaveChanges();
            }
        }
    }
}
