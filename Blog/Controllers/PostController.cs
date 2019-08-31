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
        [Authorize]
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

            return post.User.Id == User.Identity.GetUserId() ? View("OwnerDetail", post) : View(post);
        }

        public ActionResult Add()
        {
            return View();
        }


        public ActionResult Delete(int id)
        {
            // get the post
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            // check if the user is the owner of that post
            if (post.User.Id == User.Identity.GetUserId())
            {
                // delete the post and redirect to Index
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // else return Unauthorized
            return new HttpUnauthorizedResult();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var post = _context.Posts.Find(id);
            return View(post);

        }

        [HttpPost]
        public ActionResult Edit(int id, Post post)
        {
            var oldPost = _context.Posts.Find(id);
            oldPost.Title = post.Title;
            oldPost.Text = post.Text;
            _context.SaveChanges();

            return RedirectToAction("Detail", new { id = oldPost.Id });
        }
    }
}