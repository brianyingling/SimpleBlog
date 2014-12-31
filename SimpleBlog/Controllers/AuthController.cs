using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using SimpleBlog.ViewModels;
using SimpleBlog.Models;
using NHibernate.Linq;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl) {
            var user = Database.Session.Query<User>().FirstOrDefault(u => u.Username == form.Username);

            // simulate a hashing password
            if (user == null) {
                SimpleBlog.Models.User.FakeHash();
            }

            if (user == null || !user.CheckPassword(form.Password)) {
                ModelState.AddModelError("username", "Password is incorrect");
            }

            // redisplay the login form if the form is invalid
            if (!ModelState.IsValid)
                return View();
            
            // how we tell ASP.NET a person says who he is
            FormsAuthentication.SetAuthCookie(user.Username, true);

            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);

            return RedirectToRoute("home");    
        }
    }
}