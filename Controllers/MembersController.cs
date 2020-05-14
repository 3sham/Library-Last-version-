using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Library.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type" : "";
            ViewBag.AddressSortParm = String.IsNullOrEmpty(sortOrder) ? "address" : "";
            ViewBag.DueDateSortParm = sortOrder == "DueDate" ? "date_desc" : "DueDate";
            ViewBag.EndDateSortParm = sortOrder == "EndDate" ? "date_asce" : "EndDate";
            

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var member = db.member.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                member = member.Where(s => s.Name.Contains(searchString)
                                       || s.Memb_Type.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name":
                    member = member.OrderBy(s => s.Name).ToList();
                    break;
                case "DueDate":
                    member = member.OrderBy(s => s.Memb_Date).ToList();
                    break;
                case "EndDate":
                    member = member.OrderBy(s => s.Expiry_Date).ToList();
                    break;
                case "type":
                    member = member.OrderByDescending(s => s.Memb_Type).ToList();
                    break;
                case "address":
                    member = member.OrderByDescending(s => s.Address).ToList();
                    break;

                default:
                    member = member.OrderBy(s => s.Memb_ID).ToList();
                    break;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            ViewBag.SearchString = new SelectList(db.member, "Name", "Name");
            return View(member.ToPagedList(pageNumber, pageSize));


        }

        public ActionResult Add()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem{ Text="Active", Value = "Active" },
                new SelectListItem{ Text="Not Active", Value = "Not Active" },
              
            };

            ViewData["foorBarList"] = list;
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add(Member model)
        {
            if (ModelState.IsValid)
            {
                model.Expiry_Date = model.Memb_Date.AddYears(1);
                db.member.Add(model);
                db.SaveChanges();
            }
            return PartialView("_Detail", db.member.ToList());
        }

        public ActionResult Edit(int id)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem{ Text="Active", Value = "Active" },
                new SelectListItem{ Text="Not Active", Value = "Not Active" },

            };

            ViewData["foorBarList"] = list;
            return PartialView(db.member.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Member model, int id)
        {
            if (ModelState.IsValid)
            {
                model.Expiry_Date = model.Memb_Date.AddYears(1);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return PartialView("_Detail", db.member.ToList());
        }

        public ActionResult Delete(int id)
        {

            db.member.Remove(db.member.Find(id));
            db.SaveChanges();
            return PartialView("_Detail", db.member.ToList());
        }
    }
}
    
