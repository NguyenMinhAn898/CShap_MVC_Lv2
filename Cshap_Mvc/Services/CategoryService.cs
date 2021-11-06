using Cshap_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cshap_Mvc.Services
{
    public class CategoryService : BaseService
    {
        /// <summary>
        /// Get all category
        /// </summary>
        /// <returns></returns>
        public List<CategoryModel> findAll()
        {
            List<CategoryModel> list = cnn.categories.Select(cate => new CategoryModel
            {
                Id = cate.id,
                Name = cate.name
            }).ToList();
            return list;
        }
    }
}