using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index()
        {
            var s = db.Book.Include(x => x.publisher).Include(y => y.location);
            
            return View(s.ToList());
        }
        public ActionResult SearchBook (string bookName)
        {
            return PartialView("_SearchBook", db.Book.Where(x => x.Title.StartsWith(bookName)));
        }

        // GET: Books/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Book.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }
        public ActionResult Location(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations location = db.location.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Location",location);
        }
        public ActionResult EditLocation(int? id)
        {
            var listforFloor = new List<SelectListItem>
            {
                new SelectListItem{ Text="Select", Value = "", Selected = true },
                new SelectListItem{ Text="Floor 1", Value = "Floor 1" },
                new SelectListItem{ Text="Floor 2", Value = "Floor 2" },
                new SelectListItem{ Text="Floor 3", Value = "Floor 3" },
            };

            ViewData["listforFloor"] = listforFloor;
            var listforArea = new List<SelectListItem>
            {
                new SelectListItem{ Text="Select", Value = "", Selected = true },
                new SelectListItem{ Text="Area 1", Value = "Area 1" },
                new SelectListItem{ Text="Area 2", Value = "Area 2" },
                new SelectListItem{ Text="Area 3", Value = "Area 3" },
            };

            ViewData["listforArea"] = listforArea;
            var listforRoom = new List<SelectListItem>
            {
                new SelectListItem{ Text="Select", Value = "", Selected = true },
                new SelectListItem{ Text="Room 1", Value = "Room 1" },
                new SelectListItem{ Text="Room 2", Value = "Room 2" },
                new SelectListItem{ Text="Room 3", Value = "Room 3" },
            };

            ViewData["listforRoom"] = listforRoom;
            var listforSection = new List<SelectListItem>
            {
                new SelectListItem{ Text="Select", Value = "", Selected = true },
                new SelectListItem{ Text="Section 1", Value = "Section 1" },
                new SelectListItem{ Text="Section 2", Value = "Section 2" },
                new SelectListItem{ Text="Section 3", Value = "Section 3" },
            };

            ViewData["listforSection"] = listforSection;
            var listforShelf = new List<SelectListItem>
            {
                new SelectListItem{ Text="Select", Value = "", Selected = true },
                new SelectListItem{ Text="Shelf 1", Value = "Shelf 1" },
                new SelectListItem{ Text="Shelf 2", Value = "Shelf 2" },
                new SelectListItem{ Text="Shelf 3", Value = "Shelf 3" },
            };

            ViewData["listforShelf"] = listforShelf;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations location = db.location.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLocation(Locations location)
        {

            db.Entry(location).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }



        // GET: Books/Create
        public ActionResult Create()
        {
            var listforFloor = new List<SelectListItem>
            {
                new SelectListItem{ Text="Select", Value = "", Selected = true },
                new SelectListItem{ Text="Floor 1", Value = "Floor 1" },
                new SelectListItem{ Text="Floor 2", Value = "Floor 2" },
                new SelectListItem{ Text="Floor 3", Value = "Floor 3" },
            };

            ViewData["listforFloor"] = listforFloor;
            var listforArea = new List<SelectListItem>
            {
                new SelectListItem{ Text="Select", Value = "", Selected = true },
                new SelectListItem{ Text="Area 1", Value = "Area 1" },
                new SelectListItem{ Text="Area 2", Value = "Area 2" },
                new SelectListItem{ Text="Area 3", Value = "Area 3" },
            };

            ViewData["listforArea"] = listforArea;
            var listforRoom = new List<SelectListItem>
            {
                new SelectListItem{ Text="Select", Value = "", Selected = true },
                new SelectListItem{ Text="Room 1", Value = "Room 1" },
                new SelectListItem{ Text="Room 2", Value = "Room 2" },
                new SelectListItem{ Text="Room 3", Value = "Room 3" },
            };

            ViewData["listforRoom"] = listforRoom;
            var listforSection = new List<SelectListItem>
            {
                new SelectListItem{ Text="Select", Value = "", Selected = true },
                new SelectListItem{ Text="Section 1", Value = "Section 1" },
                new SelectListItem{ Text="Section 2", Value = "Section 2" },
                new SelectListItem{ Text="Section 3", Value = "Section 3" },
            };

            ViewData["listforSection"] = listforSection;
            var listforShelf = new List<SelectListItem>
            {
                new SelectListItem{ Text="Select", Value = "", Selected = true },
                new SelectListItem{ Text="Shelf 1", Value = "Shelf 1" },
                new SelectListItem{ Text="Shelf 2", Value = "Shelf 2" },
                new SelectListItem{ Text="Shelf 3", Value = "Shelf 3" },
            };

            ViewData["listforShelf"] = listforShelf;

            ViewBag.Pub_id = new SelectList(db.publisher, "Pub_Id", "Pub_Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookLocation booklocation, HttpPostedFileBase file)
        {
            
                var sTitle = db.Book.Where(x => x.Title == booklocation.Book.Title);
                if (sTitle.Count() > 0 )
                {
                    var s = db.Book.Where(x => x.Title == booklocation.Book.Title).FirstOrDefault(); ;
                    s.Amount = booklocation.Book.Amount + s.Amount;
                    db.Entry(s).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");


                }
                else
                {

                    if (file != null)
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
                    booklocation.Book.ImagePath = file.FileName;
                    }
                    else
                    {

                    booklocation.Book.ImagePath =null;
                    }
                    if (booklocation.Book.Amount > 0)
                    {
                    booklocation.Book.Available = true;
                    }
                    else if (booklocation.Book.Amount < 0)
                    {
                        ViewBag.err = "Amount can't be negative";
                        return View("Error");
                    }
                    else
                    {
                        booklocation.Book.Available = false;
                    }
                    booklocation.Book.Book_ID = Guid.NewGuid();
                    booklocation.Book.Loc_id = booklocation.Location.Loc_ID;
                    db.location.Add(booklocation.Location);
                    db.Book.Add(booklocation.Book);
                    db.SaveChanges();
                ViewBag.Pub_id = new SelectList(db.publisher, "Pub_Id", "Pub_Name", booklocation.Book.Pub_id);
                return RedirectToAction("Index");
                   
                }
               
            
                
        }

        // GET: Books/Edit/5
        public ActionResult Edit(Guid? id)
        {
            
            if (id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Books books = db.Book.Find(id);
            //TempData["ImagePath"] = books.ImagePath;
            if (books == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pub_id = new SelectList(db.publisher, "Pub_Id", "Pub_Name", books.Pub_id);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Books book, HttpPostedFileBase file)
        {

            
                if (file != null)
                {
                    
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
                    book.ImagePath = file.FileName;
                }
                else
                {
                    book.ImagePath = null;
                }
                if (book.Amount > 0)
                {
                    book.Available = true;
                }
                else if (book.Amount < 0)
                {
                    ViewBag.err = "Amount can't be negative";
                    return View("Error");
                }
                else
                {
                    book.Available = false;
                }

            db.Entry(book).State = EntityState.Modified;
               
                db.SaveChanges();
                ViewBag.Pub_id = new SelectList(db.publisher, "Pub_Id", "Pub_Name", book.Pub_id);
            return RedirectToAction("Index");
            
        }

       
        public ActionResult Delete(Guid id , int idloc)
        {
            Books books = db.Book.Find(id);
            Locations location = db.location.Find(idloc);
            db.Book.Remove(books);
            db.location.Remove(location);
            db.SaveChanges();
            return PartialView("_SearchBook",db.Book.ToList());
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
