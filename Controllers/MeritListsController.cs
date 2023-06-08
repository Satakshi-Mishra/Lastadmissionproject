using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lastadmissionproject.Models;

namespace Lastadmissionproject.Controllers
{
    public class MeritListsController : Controller
    {
        private AdmissionDbContext db = new AdmissionDbContext();

        // GET: MeritLists
        public ActionResult Index()
        {
            //int rank = 1;
            //foreach (var item in db.ApplicantDetails.OrderByDescending(a => a.HigherSecondaryAggregateMarks))
            //{
            //    ApplicantDetail.Rank = rank;
            //    rank++;
            //}
            var meritLists = db.MeritLists.Include(m => m.ApplicantDetail);
            return View(meritLists.ToList());
        }

        // GET: MeritLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeritList meritList = db.MeritLists.Find(id);
            if (meritList == null)
            {
                return HttpNotFound();
            }
            return View(meritList);
        }

        // GET: MeritLists/Create
        public ActionResult Create()
        {
            ViewBag.CandidateId = new SelectList(db.ApplicantDetails, "CandidateId", "FullName");
            return View();
        }

        // POST: MeritLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeritId,CandidateId,HigherSecondaryAggregateMarks,Rank")] MeritList meritList)
        {
            if (ModelState.IsValid)
            {
                db.MeritLists.Add(meritList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandidateId = new SelectList(db.ApplicantDetails, "CandidateId", "FullName", meritList.CandidateId);
            return View(meritList);
        }

        // GET: MeritLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeritList meritList = db.MeritLists.Find(id);
            if (meritList == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateId = new SelectList(db.ApplicantDetails, "CandidateId", "FullName", meritList.CandidateId);
            return View(meritList);
        }

        // POST: MeritLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeritId,CandidateId,HigherSecondaryAggregateMarks,Rank")] MeritList meritList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meritList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateId = new SelectList(db.ApplicantDetails, "CandidateId", "FullName", meritList.CandidateId);
            return View(meritList);
        }

        // GET: MeritLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeritList meritList = db.MeritLists.Find(id);
            if (meritList == null)
            {
                return HttpNotFound();
            }
            return View(meritList);
        }

        // POST: MeritLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeritList meritList = db.MeritLists.Find(id);
            db.MeritLists.Remove(meritList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: MeritList/GenerateRankList
        //public ActionResult GenerateRankList()
        //{
        //    // Retrieve all applicants from the database
        //    var applicants = db.ApplicantDetails.ToList();

        //    // Generate the rank list based on aggregate marks
        //    var rankList = applicants.OrderBy(a => a.HigherSecondaryAggregateMarks)
        //    .Select((a, index) => new MeritList
        //    {
        //        CandidateId = a.CandidateId,
        //        HigherSecondaryAggregateMarks = a.HigherSecondaryAggregateMarks,
        //        Rank = index + 1
        //    })
        //    .ToList();

        //    // Save the generated rank list to the database
        //    db.MeritLists.AddRange(rankList);
        //    db.SaveChanges();

        //    return View();
        //}

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
