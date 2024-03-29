﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lastadmissionproject.Migrations;
using Lastadmissionproject.Models;

namespace Lastadmissionproject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NoticesController : Controller
    {
        private AdmissionDbContext db = new AdmissionDbContext();

        // GET: Notices
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Notices.ToList());
        }

        // GET: Notices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notices notices = db.Notices.Find(id);
            if (notices == null)
            {
                return HttpNotFound();
            }
            return View(notices);
        }

        // GET: Notices/Create


        public ActionResult Create()
        {
            Notices notices = new Notices();
            notices.NoticeCreated = DateTime.Now;
            return View(notices);
        }

        // POST: Notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoticeId,NoticeName,NoticeDescription,NoticeCreated")] Notices notices)
        {
            if (ModelState.IsValid)
            {
                
                

                db.Notices.Add(notices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notices);
        }

        // GET: Notices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notices notices = db.Notices.Find(id);
            if (notices == null)
            {
                return HttpNotFound();
            }
            return View(notices);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoticeId,NoticeName,NoticeDescription,NoticeCreated")] Notices notices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notices);
        }

        // GET: Notices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notices notices = db.Notices.Find(id);
            if (notices == null)
            {
                return HttpNotFound();
            }
            return View(notices);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notices notices = db.Notices.Find(id);
            db.Notices.Remove(notices);
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
    }
}
