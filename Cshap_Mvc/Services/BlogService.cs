using Cshap_Mvc.Db;
using Cshap_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cshap_Mvc.Services
{
    public class BlogService
    {
        private static Blog_ManagementEntities db = new Blog_ManagementEntities();

        /// <summary>
        /// Get all blog
        /// </summary>
        /// <returns></returns>
        public static List<BlogModel> findAll()
        {
            List<BlogModel> list = db.blogs.Where(b => b.is_active == true).Select(b => new BlogModel
            {
                Id = b.id,
                Title = b.title,
                Short_Description = b.short_description,
                Description = b .description,
                Category = db.categories.Where(c=>c.id==b.id).FirstOrDefault().name,
                Image_Url = b.img_url,
                Place = b.place,
                Public_Date = b.public_date != null ? b.public_date.Value : DateTime.Now
            }).ToList();
            return list;
        }

        /// <summary>
        /// Get list blog by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<BlogModel> findByTitle(String title = null)
        {
            if (String.IsNullOrEmpty(title))
                return findAll();
            return new List<BlogModel>();
        }
    }
}