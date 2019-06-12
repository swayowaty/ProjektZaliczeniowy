using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektZaliczeniowy.DAL;
using ProjektZaliczeniowy.Models;

namespace ProjektZaliczeniowy.Controllers
{
    public class UzytkownikController : Controller
    {
        private UzytkownikDAL db = new UzytkownikDAL();

        // GET: Uzytkownik
        public ActionResult Index()
        {
            return View(db.Uzytkownicy.ToList());
        }


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Uzytkownik uzytkownik)
        {

            if (ModelState.IsValid)
            {
                using (UzytkownikDAL db = new UzytkownikDAL())
                {
                    db.Uzytkownicy.Add(uzytkownik);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = uzytkownik.Nickname + "Zarejestrowano";
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Uzytkownik user)
        {
            using (UzytkownikDAL db = new UzytkownikDAL())
            {
                var usr = db.Uzytkownicy.FirstOrDefault(u => u.Nickname == user.Nickname && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserId"] = usr.UserID.ToString();
                    Session["Username"] = usr.Nickname.ToString();
                    return RedirectToAction("LoggedIn");

                }
                else
                {
                    ModelState.AddModelError("", "Nick albo haslo sa zle");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        // GET: Uzytkownik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkownicy.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uzytkownik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Imie,Nazwisko,Email,Nickname,Password,ConfirmedPassword")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                db.Uzytkownicy.Add(uzytkownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uzytkownik);
        }

        // GET: Uzytkownik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkownicy.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // POST: Uzytkownik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Imie,Nazwisko,Email,Nickname,Password,ConfirmedPassword")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzytkownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LoggedIn", "Uzytkownik");
            }
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkownicy.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // POST: Uzytkownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uzytkownik uzytkownik = db.Uzytkownicy.Find(id);
            db.Uzytkownicy.Remove(uzytkownik);
            db.SaveChanges();
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
