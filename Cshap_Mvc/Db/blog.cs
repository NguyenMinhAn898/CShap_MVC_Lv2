//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cshap_Mvc.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class blog
    {
        public int id { get; set; }
        public string title { get; set; }
        public string short_description { get; set; }
        public string description { get; set; }
        public string img_url { get; set; }
        public bool status { get; set; }
        public string place { get; set; }
        public bool is_active { get; set; }
        public int category_id { get; set; }
        public Nullable<System.DateTime> public_date { get; set; }
    
        public virtual category category { get; set; }
    }
}
