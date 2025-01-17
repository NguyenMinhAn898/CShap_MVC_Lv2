﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cshap_Mvc.Models
{
    public class BlogModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [Display(Name ="Tiêu đề")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Please enter short description")]
        [Display(Name = "Mô tả ngắn")]
        public String Short_Description { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        [Display(Name = "Chi tiết")]
        public String Description { get; set; }

        
        [Display(Name = "Loại")]
        public String Category { get; set; }

        [Required(ErrorMessage = "Please enter catgory name")]
        public int Category_Id { get; set; }

        [Display(Name = "Hình ảnh")]
        public String Image_Url { get; set; }

        [Required(ErrorMessage = "Please enter status")]
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Vị trí")]
        public String Place { get; set; }

        [Display(Name = "Ngày public")]
        public DateTime? Public_Date { get; set; }

        public bool Is_Active { get; set; }

        public String Public_Date_Str
        {
            get
            {
                return Public_Date != null ? Public_Date.Value.ToString("yyyy/MM/dd") : "";
            }
        }

        public BlogModel() { }

        public BlogModel(int id)
        {
            this.Id = id;
        }
    }    

    public class BlogDbContext : DbContext
    {
        public BlogDbContext() { }
        public DbSet<BlogModel> Blog { get; set; }
    }
}