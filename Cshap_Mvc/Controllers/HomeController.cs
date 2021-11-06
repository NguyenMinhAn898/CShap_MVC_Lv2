using Cshap_Mvc.Models;
using Cshap_Mvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cshap_Mvc.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Get Index list blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.blog = new BlogModel();
            return View(BlogService.findAll());
        }

        /// <summary>
        /// Get list blog by title 
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchByTitle(BlogModel blog)
        {
            if (!String.IsNullOrEmpty(blog.Title))
            {
                ViewBag.blog = blog;
                return View("Index",BlogService.findAll());
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Get view edit blog
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            // Fetch data
            BlogModel blog = new BlogModel();
            return View(blog);
        }

        /// <summary>
        /// Update blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(BlogModel blog)
        {
            //checking model state
            if (ModelState.IsValid)
            { 
                //update blog to db

                return RedirectToAction("Index");
            }
            return View(blog);
        }

        /// <summary>
        /// Get view create blog
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            // clear mesage validate in fist load page
            ModelState.Clear();

            return View();
        }

        /// <summary>
        /// Create blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(BlogModel blog)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                //update blog to db

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}