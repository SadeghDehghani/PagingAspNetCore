using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagingAspNet.Models;
using PagingAspNet.Models.Domain;
using ReflectionIT.Mvc.Paging;
using System.Diagnostics;

namespace PagingAspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DataBaseContext _db;



        public HomeController(ILogger<HomeController> logger, DataBaseContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(int pageIndex = 1)
        {
            var model = PagingList.Create(_db.Posts.ToList(), 10, pageIndex);
            return View(model);
        }
 

        public IActionResult Privacy()
        {

            for (int i = 0; i < 400; i++)
            {

                Post post = new Post() {

                    Caption = $"Post {i.ToString()}",
                    Image = $"{i.ToString()}.jpg",
                };

                _db.Posts.Add(post);
                _db.SaveChanges();

            }


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
