using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Blog.ViewModels;

namespace Blog.Controllers
{
    public class ProfileController : Controller
    {

        private ApplicationDbContext _context;

        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Profile/Register
        //[AllowAnonymous]
        public ActionResult Register(ProfileViewModel profileViewModel)
        {
            if (!ModelState.IsValid)
            {
                
                return View("Index");
            }
            ViewBag.Email = profileViewModel.profile.Name;
            ViewBag.Password = profileViewModel.Email;
            return View();
        }

    }
}