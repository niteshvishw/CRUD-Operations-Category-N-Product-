using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CategoryOperation.Models
{
    public class CategoryContext :  DbContext
    {
        public CategoryContext(): base("CategoryContext")
        {

        }
        public DbSet<Category> Categories { get; set;}

        public DbSet<Product> Products { get; set;}


    }
}