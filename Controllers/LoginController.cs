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
                var customer = db.ApplicantDetails.Where(m => m.Email == c.Email && m.Password == c.Password).FirstOrDefault();



                if (customer != null)
                {
                    FormsAuthentication.SetAuthCookie(c.Email, false);
                    Session["uname"] = customer.FullName;
                    Session["email"] = customer.Email;



                    TempData["alert"] = "<script>alert('Login Successfull')</script>";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.alert = "<script>alert('Login not Successfull')</script>";
                    return View();
                }



            }



            return View();
        }
        public ActionResult SignOut(ApplicantDetail c)
        {
            FormsAuthentication.SignOut();
            Session["uname"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}

    

