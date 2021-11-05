using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cshap_Mvc.Models
{
    public class BlogModel
    {
        [Required]
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

        [Required(ErrorMessage = "Please enter catgory name")]
        [Display(Name = "Loại")]
        public String Category { get; set; }

        [Display(Name = "Hình ảnh")]
        public String Image_Url { get; set; }

        [Required(ErrorMessage = "Please enter status")]
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Vị trí")]
        public String Place { get; set; }

        [Display(Name = "Ngày public")]
        public DateTime Public_Date { get; set; }

        public bool Is_Active { get; set; }

        public BlogModel() { }
        public BlogModel(int id , String title, string short_description , string description , string category, bool status, String place, DateTime public_date, bool is_active)
        {
            this.Id = id;
            this.Title = title;
            this.Category = category;
            this.Short_Description = short_description;
            this.Description = description;
            this.Status = status;
            this.Place = place;
            this.Public_Date = public_date;
            this.Is_Active = is_active;
        }
    }
}