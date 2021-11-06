using AutoMapper;
using Cshap_Mvc.Db;
using Cshap_Mvc.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cshap_Mvc.Services
{
    public class BaseService
    {
        public static Blog_ManagementEntities cnn;


        public BaseService(Blog_ManagementEntities context = null)
        {
            if (context == null)
            {
                context = new Blog_ManagementEntities();
            }
            cnn = context;
        }
    }
}