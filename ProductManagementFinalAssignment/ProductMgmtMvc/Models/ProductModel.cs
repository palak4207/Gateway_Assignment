using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductMgmtMvc.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string product_name { get; set; }
        public string category_name { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> quantity { get; set; }
        public string short_des { get; set; }
        public string long_des { get; set; }
        public string small_img { get; set; }
        public string large_img { get; set; }

    }
}