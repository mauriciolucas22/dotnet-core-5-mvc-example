using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using dotnet_mvc.Models;
using dotnet_mvc.Database;

namespace dotnet_mvc.Controllers
{
    public class BusinessController : Controller
    {

        private readonly ApplicationDBContext database;

        public BusinessController(ApplicationDBContext database) // Database connection injection
        {
            this.database = database;
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Business data)
        {
            if (data.Id == 0)
            {
                this.database.Businesses.Add(data);
            }
            else
            {
                Business storedBusiness = this.database.Businesses.First(item => item.Id == data.Id);
                storedBusiness.Name = data.Name;
                storedBusiness.Email = data.Email;
            }
            this.database.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Index()
        {
            var result = this.database.Businesses.ToList();
            return View(result);
        }

        public IActionResult Edit(int id)
        {
            Business data = this.database.Businesses.First(item => item.Id == id);
            return View("Signup", data);
        }

        public IActionResult Delete(int id)
        {
            Business stored = this.database.Businesses.First(item => item.Id == id);
            this.database.Businesses.Remove(stored);
            this.database.SaveChanges();
            return Redirect("/Business/Index");
        }
    }
}