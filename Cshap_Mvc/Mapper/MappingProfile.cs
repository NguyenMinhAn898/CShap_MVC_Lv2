using AutoMapper;
using Cshap_Mvc.Db;
using Cshap_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cshap_Mvc.Mapper
{
    public class MappingProfile : Profile
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            // config chuyển đổi từ Employee => EmployeeDto
            cfg.CreateMap< BlogModel, CategoryModel>();
            // config chuyển đổi từ EmployeeDto => Employee
        }
    }
}