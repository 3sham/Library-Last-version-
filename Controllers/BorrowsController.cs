using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    [Authorize]
    public class BorrowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Borrows
        public ActionResult Index()
        {
            var borrow = db.borrow.Include(b => b.Book).Include(b => b.Member);
            return View(borrow.ToList());
        }
        [HttpPost]
        public ActionResult Search(string searchparam, string searchTerm)
        {
            if (searchparam == "MemberName")
            {
                var s = db.borrow.Include(b => b.Book).Include(b => b.Member).Where(b => b.Member.Name.StartsWith(searchTerm));

                return PartialView("_SearchBorrows",s.ToList());
            }
            else if (searchparam == "BookName")
            {
                var s = db.borrow.Include(b => b.Book).Include(b => b.Member).Where(b => b.Book.Title.StartsWith(searchTerm));
                return PartialView("_SearchBorrows", s.ToList());
            }
            else
            {
               
                return View();
            }

        }
        public ActionResult AddMultiBorrows()
        {

            ViewBag.Book_id = new SelectList(db.Book, "Book_ID", "Title");
            ViewBag.Memb_ID = new SelectList(db.member, "Memb_ID", "Name");
            return View();
        }
        [HttpPost]
        public JsonResult AddMultiBorrows(List<Borrows> borrow)
        {
            
                //Check for NULL.
                if (borrow == null)
                {
                    borrow = new List<Borrows>();
                }

                //Loop and insert records.
                foreach (var model in borrow)
                {
                    model.Return_date = model.Due_date.AddDays(15);
                    db.borrow.Add(model);
                }
                db.SaveChanges();
               return Json(new { result = "Redirect", url = Url.Action("Index", "Borrows") });
            

        }
        // GET: Borrows/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrows borrows = db.borrow.Find(id);
            if (borrows == null)
            {
                return HttpNotFound();
            }
            return View(borrows);
        }

        // GET: Borrows/Create
        public ActionResult Create()
        {
            ViewBag.Book_id = new SelectList(db.Book, "Book_ID", "Title");
            ViewBag.Memb_ID = new SelectList(db.member, "Memb_ID", "Name");
            return View();
        }

        // POST: Borrows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Borro_ID,Due_date,Return_date,Issue,Memb_ID,Book_id")] Borrows borrows)
        {
            if (ModelState.IsValid)
            {
                borrows.Return_date = borrows.Due_date.AddDays(15);
                borrows.Borro_ID = Guid.NewGuid();
                db.borrow.Add(borrows);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_id = new SelectList(db.Book, "Book_ID", "Title", borrows.Book_id);
            ViewBag.Memb_ID = new SelectList(db.member, "Memb_ID", "Name", borrows.Memb_ID);
            return View(borrows);
        }

        // GET: Borrows/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrows borrows = db.borrow.Find(id);
            if (borrows == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_id = new SelectList(db.Book, "Book_ID", "Title", borrows.Book_id);
            ViewBag.Memb_ID = new SelectList(db.member, "Memb_ID", "Name", borrows.Memb_ID);
            return View(borrows);
        }

        // POST: Borrows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Borro_ID,Due_date,Return_date,Issue,Memb_ID,Book_id")] Borrows borrows)
        {
            if (ModelState.IsValid)
            {
                borrows.Return_date = borrows.Due_date.AddDays(15);
                db.Entry(borrows).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_id = new SelectList(db.Book, "Book_ID", "Title", borrows.Book_id);
            ViewBag.Memb_ID = new SelectList(db.member, "Memb_ID", "Name", borrows.Memb_ID);
            return View(borrows);
        }

        // GET: Borrows/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrows borrows = db.borrow.Find(id);
            if (borrows == null)
            {
                return HttpNotFound();
            }
            return View(borrows);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
           
            Borrows borrows = db.borrow.Find(id);
            db.borrow.Remove(borrows);
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
