using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProjektZaliczeniowy.BL;
using ProjektZaliczeniowy.DAL;
using ProjektZaliczeniowy.Models;

namespace ProjektZaliczeniowy.Controllers
{
    public class BlogPostController : Controller
    {
        private BlogPostDAL db = new BlogPostDAL();

        // GET: BlogPost
        public ActionResult Index(int page = 1, int pagesize =4  )
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Uzytkownik");
            }
            List<BlogPost> blogpost = db.Uzytkownicy.ToList();

            PagedList<BlogPost> Blogpost = new PagedList<BlogPost>(blogpost, page, pagesize);

            return View(Blogpost);
        }

        // GET: BlogPost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            
            return View(new BlogBL().FindS((int)id));
        }

        // GET: BlogPost/Create
        public ActionResult Create()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login","Uzytkownik");
            }
           
            else
            {


                return View();
            }
        }

        // POST: BlogPost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,UserID,Post_title,Image,Podpis")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {

                new BlogBL().dodajStanowisko(blogPost);
             //   db.Uzytkownicy.Add(blogPost);
              //  db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: BlogPost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Uzytkownik");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
         
            return View(new BlogBL().FindS((int)id));
        }

        // POST: BlogPost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,UserID,Post_title,Image,Podpis")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: BlogPost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Uzytkownik");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            new BlogBL().FindS((int)id);

        
            return View(new BlogBL().FindS((int)id));
        }

        // POST: BlogPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new BlogBL().UsunS(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
