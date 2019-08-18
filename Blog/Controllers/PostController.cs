using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        protected ApplicationDbContext _context { get; set; }
        protected UserManager<ApplicationUser> userManager { get; set; }

        public PostController()
        {
            _context = new ApplicationDbContext();
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this._context));
        }
        
        // GET: Post
        public ActionResult Index()
        {
            var posts = _context.Posts.OrderByDescending(p => p.Created_at).ToList();
            return View("List", posts);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Index(Post post)
        {
            Post pp = new Post();
            if (ModelState.IsValid)
            {
                var user = userManager.FindById(User.Identity.GetUserId());
                post.User = user;
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("Add");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Post post = _context.Posts.Find(id);
            return View(post);
        }

        public ActionResult Add()
        {
            return View();
        }

    }
}