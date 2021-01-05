using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProductMgmtMvc.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        [Required]
        public string product_name { get; set; }
            [DisplayName("Category Name")]
            [Required]
        public string category_name { get; set; }

        [DisplayName("Price")]
        [Required]
        public Nullable<decimal> price { get; set; }
        [DisplayName("Quantity")]
        [Required]
        public Nullable<int> quantity { get; set; }
        [DisplayName("Short Description")]
        [Required]
        public string short_des { get; set; }
        
        [DisplayName("Long Description")]
        [Required]
        public string long_des { get; set; }
        [Required]
        public string small_img { get; set; }
        public string large_img { get; set; }

        [DisplayName("Small Image")]
        [Required]
        public HttpPostedFileBase smallimg { get; set; }

        [DisplayName("Large Image")]
        public  HttpPostedFileBase largeimg { get; set; }
    }
}