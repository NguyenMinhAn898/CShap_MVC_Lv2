using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cshap_Mvc.Models
{
    public class PlaceModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public PlaceModel() { }

        public PlaceModel(int id, String name)
        {
            this.Id = id;
            this.Name = name;
        }
    }

}