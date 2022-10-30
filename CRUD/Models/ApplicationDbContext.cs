using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext():base("defaultname")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}