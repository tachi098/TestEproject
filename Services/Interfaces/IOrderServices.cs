using DemoProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Services.Interfaces
{
    public interface IOrderServices
    {
        List<Order> GetOrders();
        List<Order> GetOrdersByUserId(int userid);
        void UpdateStatus(int id);
    }
}
