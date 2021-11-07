using AutoMapper;
using Cshap_Mvc.Db;
using Cshap_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cshap_Mvc.Services
{
    class BlogService : BaseService
    {
        // Chưa có log khi lỗi 
        // Chưa sử lý auto mapper

        public BlogService() : base()
        {
        }

        /// <summary>
        /// Get all blog
        /// </summary>
        /// <returns></returns>
        public  List<BlogModel> findAll()
        {
            try
            {
                List<BlogModel> list = cnn.blogs.Where(b => b.is_active == true)
                    .Select(b => new BlogModel
                    {
                        Id = b.id,
                        Title = b.title,
                        Short_Description = b.short_description,
                        Description = b.description,
                        // cần sửa vì 2 bảng đã join 
                        Category = cnn.categories.Where(c => c.id == b.id).FirstOrDefault().name,
                        Image_Url = b.img_url,
                        Place = b.place,
                        Status = b.status,
                        Public_Date = b.public_date
                    }).ToList();
                return list;
            }
            catch
            {
                return new List<BlogModel>();
            }            
        }

        /// <summary>
        /// Get list blog by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public  List<BlogModel> findByTitle(String title)
        {
            try
            {
                List<BlogModel> listBlogs = cnn.blogs.Where(blog => blog.title.Contains(title) && blog.is_active == true)
                    .Select(blog => new BlogModel
                    {
                        Id = blog.id,
                        Title = blog.title,
                        Short_Description = blog.short_description,
                        Description = blog.description,
                        Place = blog.place,
                        Status = blog.status,
                        Public_Date = blog.public_date
                    }).ToList();

                return listBlogs;
            }
            catch(Exception ex)
            {
                return new List<BlogModel>();
            }
        }

        /// <summary>
        /// Get A blog by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  BlogModel findById(int id)
        {
            try
            {
                BlogModel ouput = (from blog in cnn.blogs
                                   where blog.id.Equals(id) && blog.is_active == true
                                   select (new BlogModel
                                   {
                                       Id = blog.id,
                                       Title = blog.title,
                                       Description = blog.description,
                                       Short_Description = blog.short_description,
                                       Status = blog.status,
                                       Category_Id = blog.category_id,
                                       Public_Date = blog.public_date
                                   })).FirstOrDefault();
                return ouput;
            }
            catch(Exception ex)
            {
                return new BlogModel();
            }
        }

        /// <summary>
        /// Add new blog
        /// </summary>
        /// <param name="newBlogModel"></param>
        /// <returns></returns>
        public bool createBlog(BlogModel newBlogModel)
        {
            try
            {
                blog newblog = new blog();
                newblog.title = newBlogModel.Title;
                newblog.short_description = newBlogModel.Short_Description;
                newblog.description = newBlogModel.Description;
                newblog.category_id = 1;
                newblog.status = newBlogModel.Status;
                newblog.is_active = true;
                newblog.public_date = newBlogModel.Public_Date;

                cnn.blogs.Add(newblog);
                cnn.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update blog 
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public  bool updateBlog(BlogModel blog)
        {
            try
            {
                blog blogUpdate = cnn.blogs.Find(blog.Id);

                if (blogUpdate != null && blogUpdate.is_active == true)
                {
                    blogUpdate.title = blog.Title;
                    blogUpdate.short_description = blog.Short_Description;
                    blogUpdate.description = blog.Description;
                    blogUpdate.status = blog.Status;
                    blogUpdate.public_date = blog.Public_Date;
                    blogUpdate.img_url = blog.Image_Url;
                    blogUpdate.place = blog.Place;
                    blogUpdate.category_id = blog.Category_Id;

                    cnn.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public  bool deleteBlog(BlogModel blog)
        {
            try
            {
                blog blogUpdate = cnn.blogs.Find(blog.Id);

                if (blogUpdate != null && blogUpdate.is_active==true)
                {
                    blogUpdate.is_active = false;

                    cnn.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}