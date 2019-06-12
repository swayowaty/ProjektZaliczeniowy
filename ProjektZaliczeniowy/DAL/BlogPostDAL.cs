using ProjektZaliczeniowy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjektZaliczeniowy.DAL
{
    public class BlogPostDAL : DbContext
    {
        public BlogPostDAL() : base("connectionString")
        {

        }
        public DbSet<BlogPost> Uzytkownicy { get; set; }
    }


}