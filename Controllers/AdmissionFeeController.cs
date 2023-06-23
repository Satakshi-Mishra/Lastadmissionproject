using Lastadmissionproject.Migrations;
using Lastadmissionproject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Lastadmissionproject.Controllers
{
    public class AdmissionFeeController : Controller
    {
        AdmissionDbContext db = new AdmissionDbContext();
        // GET: AdmissionFee
        public ActionResult PayNow()
        {
            string email = (string)Session["email"];
            ApplicantDetail applicant = db.ApplicantDetails.SingleOrDefault(a => a.Email == email);
            if (applicant != null && applicant.AllotmentStatus == "Alloted")
            {
                AdmissionFee pay = new AdmissionFee();
                pay.PaymentDate = DateTime.Now;
                pay.PaymentId = (new Random()).Next(10000, 99999);
                pay.FeesStatus = "Due";
                pay.PaymentMode = "Card Payment";


                if (applicant != null)
                {
                    pay.CandidateId = applicant.CandidateId;
                    pay.FullName = applicant.FullName;

                }
                return View(pay);
            }
            else
            {
                ViewBag.Message = "Sorry! You are not eligible to make the payment.";
                return View("PaymentNotEligible"); 
            }

            
            
        }

        [HttpPost]
        public ActionResult PayNow(AdmissionFee model)
        {
            model.FeesStatus = "Paid";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44383/api/");

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            Task<HttpResponseMessage> responseTask = client.PostAsync("AdmissionFee", content);
            responseTask.Wait();
            var response = responseTask.Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Payment Process Completed! You have completed your admission process!";
                return View("Success");
            }
            model.FeesStatus = "Due";
            return View(model);
        }


        public ActionResult ViewPayments()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44383/api/");



            Task<HttpResponseMessage> responseTask = client.GetAsync("AdmissionFee");
            responseTask.Wait();
            HttpResponseMessage response = responseTask.Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.StatusCode = response.StatusCode;
                Task<string> dataContent = response.Content.ReadAsStringAsync();
                dataContent.Wait();
                string jsonData = dataContent.Result;
                List<AdmissionFee> payments = JsonConvert.DeserializeObject<List<AdmissionFee>>(jsonData);
                return View(payments);
            }
            else
            {
                return View("Error");
            }
        }



        public ActionResult ViewPaymentById()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44383/api/");
            string email = (string)Session["email"];
            ApplicantDetail applicant = db.ApplicantDetails.SingleOrDefault(a => a.Email == email);

            Task<HttpResponseMessage> responseTask = client.GetAsync("AdmissionFee");
            responseTask.Wait();
            HttpResponseMessage response = responseTask.Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.StatusCode = response.StatusCode;
                Task<string> dataContent = response.Content.ReadAsStringAsync();
                dataContent.Wait();
                string jsonData = dataContent.Result;
                
                List<AdmissionFee> payment = JsonConvert.DeserializeObject<List<AdmissionFee>>(jsonData);
                 List<AdmissionFee> fees = payment.Where(p => p.CandidateId == applicant.CandidateId).ToList();
                if (fees == null)
                {
                    ViewBag.Message = "No transactions available";
                    return View("Error");
                }
                return View(fees);
            }
            else
            {
                return View("Error");
            }
        }
    }
}