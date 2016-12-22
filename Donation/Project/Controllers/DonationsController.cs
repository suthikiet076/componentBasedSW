using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using PagedList;
using PagedList.Mvc;


namespace Project.Controllers
{
    public class DonationsController : Controller
    {
        private DonationContext db = new DonationContext();

        // GET: Donations
        /*public ActionResult Index()
        {
            return View(db.Donations.ToList());
        }*/

        public ActionResult Index(string donationType, string searchString, string nameItem, int? page)
        {
            var MajorLst = new List<string>();
            var MajorQry = from d in db.Donations orderby d.Type select d.Type;
            MajorLst.AddRange(MajorQry.Distinct());
            ViewBag.donationType = new SelectList(MajorLst);

   

            var donation = from m in db.Donations select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                donation = donation.Where(s => s.Title.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(donationType))
            {
                donation = donation.Where(x => x.Type == donationType);
            }
            if (!string.IsNullOrEmpty(nameItem))
            {
                donation = donation.Where(x => x.Title == nameItem);
            }

            return View(donation.ToList().ToPagedList(page ?? 1, 3));
        }

        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Type,Number,Date,Fname,Lname,Phone,Facebook")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Type,Number,Date,Fname,Lname,Phone,Facebook")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Donations.Remove(donation);
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

        public ActionResult Views(string donationType, string searchString, int? page)
        {
            var MajorLst = new List<string>();
            var MajorQry = from d in db.Donations orderby d.Type select d.Type;
            MajorLst.AddRange(MajorQry.Distinct());
            ViewBag.donationType = new SelectList(MajorLst);

            var donation = from m in db.Donations select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                donation = donation.Where(s => s.Title.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(donationType))
            {
                donation = donation.Where(x => x.Type == donationType);
            }
            return View(donation.ToList().ToPagedList(page ?? 1, 5));
        }
    }
}
