using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CategoryOperation.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Category ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name Is Required!")]
        [StringLength(60, ErrorMessage = "Cannot Accept More Than 60 Characters!")]
        [Display(Name = "Category NAME")]
        public String NAME { get; set; }

        [Display(Name ="Active")]
        public bool IsActive { get; set; }
    }
}