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

        public ActionResult Index(BlogModel blog)
        {
            initData();

            ViewBag.blog = blog;
            return View(listBlog);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Fetch data
        /// </summary>
        private void initData()
        {
            if(listBlog.Count == 0)
            {
                for (int i = 1; i < 11; i++)
                {
                    listBlog.Add(new BlogModel(i, "Hom nay la thu " + i, "Giai tri " + i,"Mô tả ngắn "+i , "Mô tả chi tiết "+i , true, "Ae " + i, DateTime.Now, true));
                }
            }            
        }

    }
}