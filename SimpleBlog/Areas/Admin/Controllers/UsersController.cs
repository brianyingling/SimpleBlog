using System;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Models;
using SimpleBlog.Infrastructure;
using SimpleBlog.Areas.Admin.ViewModels;

namespace SimpleBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [SelectedTab("users")]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            // retrieves every user in db and creates a list of users
            return View(new UsersIndex { 
                Users = Database.Session.Query<User>().ToList()
            });
        }
    }
}