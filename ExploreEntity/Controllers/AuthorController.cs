using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExploreEntity.DAL;
using ExploreEntity.Models;

namespace ExploreEntity.Controllers
{
    public class AuthorController : Controller
    {
        private BlogRepository repo = new BlogRepository();

        public ActionResult Index()
        {
            List<Author> list_of_authors = repo.GetAuthors();

            // Using ViewBag
            //ViewBag.Authors = list_of_authors;

            return View(list_of_authors);
        }

        public ActionResult WithViewBag()
        {
            List<Author> list_of_authors = repo.GetAuthors();
            ViewBag.Authors = list_of_authors;
            return View();
        }

        public ActionResult PenUsed(string penname)
        {
            return View();
        }
    }
}