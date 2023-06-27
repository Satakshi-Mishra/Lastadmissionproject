using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Lastadmissionproject.Models;

namespace Lastadmissionproject.Controllers
{
    public class LoginController : Controller
    {
        AdmissionDbContext db = new AdmissionDbContext();

        // GET: Login
        public ActionResult SignUp()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(ApplicantDetail c)
        {
            c.Role = "Applicant";
            if (ModelState.IsValid)
            {
                db.ApplicantDetails.Add(c);
                var a = db.SaveChanges();



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



            return View();
        }



        public ActionResult SignIn()
        {
            return View();
        }



        [HttpPost]
        public ActionResult SignIn(ApplicantDetail c)
        {
            ModelState.Remove("FullName");
            ModelState.Remove("FatherName");
            ModelState.Remove("MotherName");
            ModelState.Remove("Mobile");
            ModelState.Remove("Age");
            ModelState.Remove("HigherSecondaryAggregateMarks");
            ModelState.Remove("CourseId");
            ModelState.Remove("Role");
            if (ModelState.IsValid)
            {
                var candidate = db.ApplicantDetails.Where(m => m.Email == c.Email && m.Password == c.Password).FirstOrDefault();



                if (candidate != null)
                {
                    FormsAuthentication.SetAuthCookie(c.Email, false);
                    Session["uname"] = candidate.FullName;
                    Session["email"] = candidate.Email;
                    //Session["candidateid"] = candidate.CandidateId;




                    //TempData["alert"] = "<script>alert('Login Successfull')</script>";
                    //TempData["alert"] = "'Login Successfull";
                    ViewBag.AlertMessage = "Login Successfull";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password. Please try again");
                    //ViewBag.alert = "<script>alert('Login not Successfull')</script>";
                    TempData["alert"] = "'Login Not Successfull";
                    return View();
                }

            }


            return View(c);
        }
        public ActionResult SignOut(ApplicantDetail c)
        {
            FormsAuthentication.SignOut();
            Session["uname"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}

    

