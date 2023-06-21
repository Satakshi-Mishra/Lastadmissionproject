using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using Lastadmissionproject.Models;

namespace Lastadmissionproject.Controllers
{
    public class AllotmentsController : Controller
    {
        private AdmissionDbContext db = new AdmissionDbContext();

        public ActionResult Allot()
        {
            Allotment allot;
            Courses courses;
            ApplicantDetail detail;

            var r = db.ApplicantDetails.Where(a => a.AllotmentStatus=="Pending").Include(v => v.Courses).OrderByDescending(a => a.HigherSecondaryAggregateMarks).ToList();


            foreach (var item in r)
            {
                courses=db.Courses.FirstOrDefault(c => c.CourseId== item.CourseId);

                if (courses.SeatAvailable > 0)
                {

                    detail = db.ApplicantDetails.FirstOrDefault(a => a.CandidateId == item.CandidateId);
                    allot = new Allotment();

                    if (item.HigherSecondaryAggregateMarks >= item.Courses.CutOff)
                    {
                        detail.AllotmentStatus = "Alloted";
                        allot.CandidateId = item.CandidateId;
                        Console.WriteLine(allot);
                        allot.CourseId = item.CourseId;
                        courses.SeatAvailable -= 1;
                        db.Allotments.Add(allot);
                        
                    }
                    else
                    {
                        detail.AllotmentStatus = "Not Alloted";
                    }

                   
                    
                    db.SaveChanges();


                }

            }

            return View();
        }
        
    }
}
