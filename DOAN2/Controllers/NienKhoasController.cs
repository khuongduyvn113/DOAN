using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOAN2.Models;

namespace DOAN2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NienKhoasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NienKhoas
        public ActionResult Index()
        {
            return View(db.NienKhoas.ToList());
        }



        // GET: NienKhoas/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] NienKhoa nienKhoa)
        {
            if (ModelState.IsValid)
            {
                db.NienKhoas.Add(nienKhoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nienKhoa);
        }

        // GET: NienKhoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NienKhoa nienKhoa = db.NienKhoas.Find(id);
            if (nienKhoa == null)
            {
                return HttpNotFound();
            }
            return View(nienKhoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] NienKhoa nienKhoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nienKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nienKhoa);
        }

        // GET: NienKhoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NienKhoa nienKhoa = db.NienKhoas.Find(id);
            if (nienKhoa == null)
            {
                return HttpNotFound();
            }
            return View(nienKhoa);
        }

        // POST: NienKhoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NienKhoa nienKhoa = db.NienKhoas.Find(id);
            db.NienKhoas.Remove(nienKhoa);
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
