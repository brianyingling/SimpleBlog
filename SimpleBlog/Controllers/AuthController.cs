using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.ViewModels;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form) {
            // redisplay the login form if the form is invalid
            if (!ModelState.IsValid)
                return View();

            if (form.Username != "rainbow dash")
            {
                ModelState.AddModelError("username", "username or password isn't 20% cooler.");
                return View(form);
            }
            
            return Content("The form is valid.");    
        }
    }
}