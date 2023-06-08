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
    public class ApplicantDetailsController : Controller
    {
        private AdmissionDbContext db = new AdmissionDbContext();

        // GET: ApplicantDetails
        public ActionResult Index()
        {
           return View(db.ApplicantDetails.ToList());
        }
        
        public ActionResult MeritList()
        {
            

            return View(db.ApplicantDetails.OrderByDescending(a => a.HigherSecondaryAggregateMarks).ToList());

            

        }
        // GET: ApplicantDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantDetail applicantDetail = db.ApplicantDetails.Find(id);
            if (applicantDetail == null)
            {
                return HttpNotFound();
            }
            return View(applicantDetail);
        }

        // GET: ApplicantDetails/Create
        public ActionResult Create()
        { 


        var courses = db.Courses.ToList();

        //Set the courses as SelectList in ViewBag 
        ViewBag.Courses = courses;
            
            return View();
        }

        // POST: ApplicantDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicantDetail applicantDetail)
        {
            applicantDetail.Role = "Applicant";

            applicantDetail.AllotmentStatus = "Pending";
            
                db.ApplicantDetails.Add(applicantDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            

            //return View(applicantDetail);
        }

        // GET: ApplicantDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantDetail applicantDetail = db.ApplicantDetails.Find(id);
            if (applicantDetail == null)
            {
                return HttpNotFound();
            }
            return View(applicantDetail);
        }

        // POST: ApplicantDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateId,FullName,FatherName,MotherName,Email,Password,Mobile,Age,HigherSecondaryAggregateMarks,CourseId")] ApplicantDetail applicantDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicantDetail);
        }

        // GET: ApplicantDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantDetail applicantDetail = db.ApplicantDetails.Find(id);
            if (applicantDetail == null)
            {
                return HttpNotFound();
            }
            return View(applicantDetail);
        }

        // POST: ApplicantDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicantDetail applicantDetail = db.ApplicantDetails.Find(id);
            db.ApplicantDetails.Remove(applicantDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*public ActionResult CourseSelection()
        {
            //Retrieve the list of courses from the database
            var courses= db.Courses.ToList();

            //Set the courses as SelectList in ViewBag 
            ViewBag.Courses = courses;
            return View();
        }*/

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
