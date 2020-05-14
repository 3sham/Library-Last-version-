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
    public class publishersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: publishers
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(db.publisher.ToList());
        }

        // GET: publishers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publisher publisher = db.publisher.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // GET: publishers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: publishers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Pub_Id,Pub_Name,Address")] publisher publisher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.publisher.Add(publisher);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(publisher);
        //}
        [HttpPost]
        public ActionResult Create(string pub_name,string pub_address)
        {
            
            try
            {
                publisher publisher = new publisher();
                publisher.Pub_Name = pub_name;
                publisher.Address = pub_address;
                db.publisher.Add(publisher);
                db.SaveChanges();
                ModelState.Clear();
                
                return PartialView("_NewPub",db.publisher.ToList());
                
            }

            catch (Exception e)
            {
                ViewBag.err = e.Message;
                ViewData["page"] = "Books";
                return View("Error");
            }

            
        }

        // GET: publishers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publisher publisher = db.publisher.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // POST: publishers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pub_Id,Pub_Name,Address")] publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        // GET: publishers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    publisher publisher = db.publisher.Find(id);
        //    if (publisher == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(publisher);
        //}

        //// POST: publishers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    publisher publisher = db.publisher.Find(id);
        //    db.publisher.Remove(publisher);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
       
        public ActionResult DeletePub(int? id)
        {
           try
            {
                var obj = db.publisher.Find(id);
                if (obj != null)
                {
                    db.publisher.Remove(obj);
                    db.SaveChanges();
                    return PartialView("_NewPub", db.publisher.ToList());
                }
                else
                {
                    ViewBag.err = "There is no Publisher with This name";
                    return View("Error");
                }
            }
            catch(Exception e)
            {
                ViewBag.err = e.Message;
                ViewData["page"] = "Books";
                return View("Error");
            }
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
