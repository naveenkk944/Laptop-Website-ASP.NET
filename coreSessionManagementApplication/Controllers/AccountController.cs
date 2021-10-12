using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreSessionManagementApplication.Helpers;
using coreSessionManagementApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace coreSessionManagementApplication.Controllers
{
    public class AccountController : Controller
    {
        ApplicationDBContext context;
        public AccountController()
        {
            context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var userObj = context.Users.Where(u => u.Username == user.Username && u.password == user.password).SingleOrDefault();
                
            if (userObj!=null)
            {
                SessionHelper.setObjectAsJson(HttpContext.Session, "user", userObj);
                User usr = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
                HttpContext.Session.SetString("usertype", usr.usertype);

                HttpContext.Session.SetString("username", usr.name);

                if (usr.usertype=="admin")
                {
                  
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Invalid Credentials";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.Error = "Please Enter Your Credentials.";
                return View("Index");
            }
        }
       
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                context.Add(user);
                await context.SaveChangesAsync();
            }
            return View("Index");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
