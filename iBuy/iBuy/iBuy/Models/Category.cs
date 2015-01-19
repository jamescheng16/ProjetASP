using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iBuy.Models
{
    public class Category
    {

        public int ID { get; set; }
        public string Name { get; set; }


    }
    public class CategoryDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}