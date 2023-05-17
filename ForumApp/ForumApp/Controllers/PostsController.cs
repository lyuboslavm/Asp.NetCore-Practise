using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly ForumAppDbContext context;

        public PostsController(ForumAppDbContext _context)
        {
            this.context = _context;
        }


        public IActionResult All()
        {
            var posts = this.context.Posts 
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content= p.Content,
                })
                .ToList();

            return View(posts);
        }


        public IActionResult Add()
            => View();

        [HttpPost]
        public IActionResult Add(PostFormModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
            };

            this.context.Posts.Add(post);
            this.context.SaveChanges();

            return RedirectToAction("All");
        }


        public IActionResult Edit(int id)
        {
            var post = this.context.Posts.Find(id);

            return View(new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content,
            });

        }

        [HttpPost]
        public IActionResult Edit(int id, PostFormModel model)
        {
            var post = this.context.Posts.Find(id);

            post.Title = post.Title;
            post.Content = model.Content;

            this.context.SaveChanges();

            return RedirectToAction("All");
        }

        public IActionResult Delete(int id)
        {
            var post = this.context.Posts.Find(id);

            this.context.Posts.Remove(post);
            this.context.SaveChanges();

            return RedirectToAction("All");

        }
    }
}
