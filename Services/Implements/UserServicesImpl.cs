using DemoProject.Entities;
using DemoProject.Models;
using DemoProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Services.Implements
{
    public class UserServicesImpl : IUserServices
    {
        private ApplicationContext context;

        public UserServicesImpl(ApplicationContext context)
        {
            this.context = context;
        }
        public void AddUser(User user)
        {
            context.User.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var model = context.User.SingleOrDefault(u => u.id == id);
            context.User.Remove(model);
            context.SaveChanges();
        }

        public User GetUser(int id)
        {
            var model = context.User.SingleOrDefault(u => u.id == id);
            return model;
        }

        public List<User> GetUsers()
        {
            var list = context.User.ToList();
            return list;
        }

        public void UpdateStatus(int id)
        {
            var model = context.User.SingleOrDefault(u => u.id == id);
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

        public void UpdateUser(int id)
        {
            var model = context.User.SingleOrDefault(u => u.id == id);
            context.User.Update(model);
            context.SaveChanges();
        }
    }
}
