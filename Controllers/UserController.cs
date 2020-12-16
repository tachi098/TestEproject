using DemoProject.Entities;
using DemoProject.Models;
using DemoProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    public class UserController : Controller
    {
        private IUserServices services;
        private IOrderServices orderServices;
        private ApplicationContext context;
        public UserController(IUserServices services, IOrderServices orderServices, ApplicationContext context)
        {
            this.services = services;
            this.orderServices = orderServices;
            this.context = context;
        }
        public IActionResult Index(string searchString)
        {
            var list = services.GetUsers();
            if (searchString != null)
            {
                list = context.User.Where(u => u.id.Equals(searchString) || u.name.Contains(searchString) || u.address.Contains(searchString)).ToList();
            }
            return View(list);
        }

        public IActionResult Order(int id)
        {
            var list = orderServices.GetOrdersByUserId(id);
            return View(list);
        }

        public IActionResult UpdateStatus(int id)
        {
            services.UpdateStatus(id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user, IFormFile file)
        {
            user.level = false;
            user.status = false;
            user.create_at = DateTime.Now;
            user.update_at = DateTime.Now;
            var model = context.User.FirstOrDefault(u => u.email.Equals(user.email));
            try
            {
                if (ModelState.IsValid)
                {
                         if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                            var rename = Convert.ToString(Guid.NewGuid()) + "." + fileName.Split('.').Last();
                            var path = Path.Combine("wwwroot/image", rename);
                            var stream = new FileStream(path, FileMode.Create);
                            file.CopyToAsync(stream);
                            user.avatar = "image/" + rename;
                        if (model == null)
                        {
                            context.User.Add(user);
                            context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.MsgEmail = "Email is existed...";
                        }
                    }
                    else
                    {
                        ViewBag.Msg = "File Url Fail";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = services.GetUser(id);
            return View(model);
        }
    
        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = services.GetUser(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(User user, IFormFile file, int level)
        {
            user.update_at = DateTime.Now;
            try
            {
                if (ModelState.IsValid)
                {
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var rename = Convert.ToString(Guid.NewGuid()) + "." + fileName.Split('.').Last();
                        var path = Path.Combine("wwwroot/image", rename);
                        var stream = new FileStream(path, FileMode.Create);
                        file.CopyToAsync(stream);
                        user.avatar = "image/" + rename;
                        context.User.Add(user);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Msg = "File Url Fail";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }
    }
}
