using AutoMapper;
using Cshap_Mvc.Db;
using Cshap_Mvc.Mapper;
using Cshap_Mvc.Models;
using Cshap_Mvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Cshap_Mvc.Controllers
{
    public class HomeController : Controller
    {
        private BlogService blogService = new BlogService();
        private CategoryService categoryService = new CategoryService();

        /// <summary>
        /// Get Index list blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.blog = new BlogModel();
            return View(blogService.findAll());
        }

        /// <summary>
        /// Get list blog by title 
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchByTitle(BlogModel blog)
        {
            // check string search
            if (!String.IsNullOrEmpty(blog.Title))
            {
                ViewBag.blog = blog;
                return View("Index", blogService.findByTitle(blog.Title));
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Get view edit blog
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            ViewBag.listPlace = listPlace();
            ViewBag.listCategory = categoryService.findAll();

            return View(blogService.findById(id));
        }

        /// <summary>
        /// Update blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(BlogModel blog)
        {
            // Lỗi, chưa lấy được giá trị của địa chỉ => cháu nghĩ cần sử lý js để lấy trước khi sumit sẽ phải gộp lại các giá trị của place
            //checking model state
            if (ModelState.IsValid)
            {
                //update blog to db
                if (blogService.updateBlog(blog))
                    return RedirectToAction("Index");
            }
            ViewBag.listCategory = categoryService.findAll();
            ViewBag.listPlace = listPlace();

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
            ViewBag.listCategory = categoryService.findAll();
            ViewBag.listPlace = listPlace();

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
                if (blogService.createBlog(blog))
                    return RedirectToAction("Index");
            }
            ViewBag.listCategory = categoryService.findAll();
            ViewBag.listPlace = listPlace();

            return View();
        }

        /// <summary>
        /// Delete row by id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int Id = 0)
        {
            if (Id <= 0)
                return Json(data: false);

            return blogService.deleteBlog(new BlogModel(Id)) ? Json(data: true) : Json(data: false); ;
        }

        /// <summary>
        /// Fetch list place
        /// </summary>
        /// <returns></returns>
        public List<PlaceModel> listPlace()
        {
            List<PlaceModel> list = new List<PlaceModel>();

            list.Add(new PlaceModel(1, "Việt Nam"));
            list.Add(new PlaceModel(2, "Châu Á"));
            list.Add(new PlaceModel(3, "Châu Âu"));
            list.Add(new PlaceModel(4, "Châu Úc"));
            list.Add(new PlaceModel(5, "Châu Mỹ"));

            return list;
        }
    }
}