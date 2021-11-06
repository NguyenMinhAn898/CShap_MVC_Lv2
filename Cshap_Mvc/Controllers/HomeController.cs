﻿using AutoMapper;
using Cshap_Mvc.Db;
using Cshap_Mvc.Mapper;
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
            if(id == 0)
                return RedirectToAction("Index");

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
            //checking model state
            if (ModelState.IsValid)
            {
                //update blog to db
                if (blogService.updateBlog(blog))
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
            ViewBag.listCategory = categoryService.findAll();
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
            return View();
        }
    }
}