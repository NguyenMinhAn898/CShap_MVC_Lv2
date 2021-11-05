using Cshap_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cshap_Mvc.Controllers
{
    public class HomeController : Controller
    {
        static List<BlogModel> listBlog = new List<BlogModel>();

        /// <summary>
        /// Get Index list blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public ActionResult Index(BlogModel blog)
        {
            initData();

            ViewBag.blog = blog;
            return View(listBlog);
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

            }
            return View("Index", listBlog);
        }

        /// <summary>
        /// Get view edit blog
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            // Fetch data
            BlogModel blog = new BlogModel(1, "Title abc", "Mô tả ngắn abc", "Chi tiết abc", "Thời sự", true, "Việt Nam, Kinh tế", DateTime.Now, true);
            
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

        /// <summary>
        /// Fetch data
        /// </summary>
        private void initData()
        {
            if (listBlog.Count == 0)
            {
                for (int i = 1; i < 11; i++)
                {
                    listBlog.Add(new BlogModel(i, "Hom nay la thu " + i, "Mô tả ngắn " + i, "Mô tả chi tiết " + i, "Giai tri " + i, true, "Ae " + i, DateTime.Now, true));
                }
            }
        }

    }
}