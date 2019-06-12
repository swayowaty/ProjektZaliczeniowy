using ProjektZaliczeniowy.DAL;
using ProjektZaliczeniowy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ProjektZaliczeniowy.BL
{
    public class BlogBL
    {
        private BlogPostDAL db = new BlogPostDAL();

        public List<BlogPost> GetUserList()
        {
            List<BlogPost> Bloglist = db.Uzytkownicy.ToList();
            return Bloglist;
        }
        public void dodajStanowisko(BlogPost blogpost)
        {
            db.Uzytkownicy.Add(blogpost);
            db.SaveChanges();

        }

        public void Update(BlogPost blogpost)
        { 
            db.Uzytkownicy.AddOrUpdate(blogpost);
            db.SaveChanges();
        }



        public void UsunS(int id)
        {
            db.Uzytkownicy.Remove(db.Uzytkownicy.Find(id));
            db.SaveChanges();
        }
        public BlogPost FindS(int id)
        {
            var tmp = db.Uzytkownicy.Find(id);
            BlogPost st = new BlogPost();

            st = tmp;
            return st;

        }

    }
}