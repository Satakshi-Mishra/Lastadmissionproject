using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Lastadmissionproject.Models;

namespace Lastadmissionproject.Controllers
{
    
    public class ApplicantDetailsController : Controller
    {
         AdmissionDbContext db = new AdmissionDbContext();

        // GET: ApplicantDetails
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            

            return View(db.ApplicantDetails.ToList());

        }

        [HttpPost]
        public ActionResult Index(string text)
        {
            var applicants = db.ApplicantDetails.Where(a => a.FullName.ToLower().StartsWith(text.ToLower()) || a.AllotmentStatus.ToLower().StartsWith(text.ToLower()) || a.FeeStatus.ToLower().StartsWith(text.ToLower()) || a.Courses.CourseName.ToLower().StartsWith(text.ToLower())).ToList();


            return View(applicants);
        }



        //[Authorize(Roles = "Admin, Applicant")]
        public ActionResult MeritList()
        {
            
           List<ApplicantDetail> applicants= db.ApplicantDetails.OrderByDescending(a => a.HigherSecondaryAggregateMarks).ToList();
            for (int i = 0; i< applicants.Count(); i++)
            {
                applicants[i].Rank = i + 1;
            }
           
            db.SaveChanges();
            //return View(db.ApplicantDetails.Include(a => a.Courses).OrderByDescending(a => a.HigherSecondaryAggregateMarks).ToList());
            return View(applicants);
            
            

        }
        //[Authorize(Roles = "Admin, Applicant")]
        public ActionResult MeritList1()
        {
            
            List<ApplicantDetail> applicants = db.ApplicantDetails.OrderByDescending(a => a.HigherSecondaryAggregateMarks).ToList();
            for (int i = 0; i < applicants.Count(); i++)
            {
                applicants[i].Rank = i + 1;
            }

            db.SaveChanges();
            return View(applicants);



        }
        // GET: ApplicantDetails/Details/5
        //[Authorize(Roles = "Applicant")]
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

        public ActionResult PersonalDetails()
        {
            string email = (string)Session["email"];
            ApplicantDetail applicant = db.ApplicantDetails.SingleOrDefault(a => a.Email == email);
            

           if (applicant == null)
           {
             return HttpNotFound();
            }
           return View(applicant);
        }

        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicantDetail applicantDetail)
        {

            var existingCandidate = db.ApplicantDetails.FirstOrDefault(c => c.Email == applicantDetail.Email);

            if (existingCandidate != null)
            {
                ViewBag.ErrorMessage = "An account with the same Email address already exists.";
                return View("Error");
            }


            applicantDetail.Role = "Applicant";

            applicantDetail.AllotmentStatus = "Pending";

            applicantDetail.FeeStatus = "Not Applicable";

            if (ModelState.IsValid)
            {
                db.ApplicantDetails.Add(applicantDetail);
               var a= db.SaveChanges();

                if (a > 0)
                {
                    TempData["alert"] = "<script>alert('Registration Successfull')</script>";
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    ViewBag.alert = "<script>alert('Registration not Successfull')</script>";
                    return View();
                }
            }
            //return RedirectToAction("Index");


            return View(applicantDetail);
        }

        // GET: ApplicantDetails/Edit/5
        [Authorize(Roles = "Applicant")]

        public ActionResult Edit(int? id)
        {
            ApplicantDetail applicantDetail = db.ApplicantDetails.Find(id);

            var courses = db.Courses.ToList();

            //Set the courses as SelectList in ViewBag 
            ViewBag.Courses = courses;

            return View(applicantDetail);
        }
        //[Authorize(Roles = "Applicant")]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicantDetail applicantDetail = db.ApplicantDetails.Find(id);
        //    if (applicantDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicantDetail);
        //}





        // POST: ApplicantDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Applicant")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicantDetail applicantDetail)

        {

            if (ModelState.IsValid)
            {
                db.Entry(applicantDetail).State = EntityState.Modified;
                applicantDetail.Role = "Applicant";
               applicantDetail.AllotmentStatus = "Pending";
                applicantDetail.FeeStatus = "Not Applicable";

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(applicantDetail);
        }

        // GET: ApplicantDetails/Delete/5
        //[Authorize(Roles = "Admin")]
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
        //[Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            ApplicantDetail applicantDetail = db.ApplicantDetails.Find(id);
            Courses courses;
            courses = db.Courses.FirstOrDefault(c => c.CourseId == applicantDetail.CourseId);
            db.ApplicantDetails.Remove(applicantDetail);
            if (applicantDetail.AllotmentStatus == "Alloted")
            {
                courses.SeatAvailable += 1;
            }
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
