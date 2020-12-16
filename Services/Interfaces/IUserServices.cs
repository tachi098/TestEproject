using DemoProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Services.Interfaces
{
    public interface IUserServices
    {
        List<User> GetUsers();

        User GetUser(int id);

        void AddUser(User user);

        void UpdateUser(int id);

        void DeleteUser(int id);

        void UpdateStatus(int id);
    }
}
