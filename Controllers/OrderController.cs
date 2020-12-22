using DemoProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    public class OrderController : Controller
    {
        private IOrderServices services;

        public OrderController(IOrderServices services)
        {
            this.services = services;
        }
        public IActionResult Index()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }

        public IActionResult UpdateStatus(int id, int userid)
        {
            services.UpdateStatus(id);
            // ReSharper disable once Mvc.ActionNotResolved
            return RedirectToAction("Order", new RouteValueDictionary(
            new { controller = "User", action = "Order", Id = userid }));
        }
    }
}
