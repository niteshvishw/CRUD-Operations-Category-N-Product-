using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace CategoryOperation.Models
{
    public class Product
    {
        [Key]
        [Display(Name ="Product ID")]
        public int ProductId { get; set; }

        [Display(Name= "Product Name")]
        public string ProductName { get; set; }


        [Display(Name = "Category ID")]
        public virtual int ID { get; set; }

        [ForeignKey("ID")]
        public virtual Category Categories { get; set; }
       
    }
}