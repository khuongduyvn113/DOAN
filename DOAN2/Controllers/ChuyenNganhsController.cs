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
    public class ChuyenNganhsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChuyenNganhs
        public ActionResult Index()
        {
            return View(db.ChuyenNganhs.Include(c=>c.Khoa).ToList());
        }

 

        // GET: ChuyenNganhs/Create
        public ActionResult Create()
        {
            ViewBag.KhoaId = new SelectList(db.Khoas, "Id", "Name");
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NameCN,KhoaId")] ChuyenNganh chuyenNganh)
        {
            if (ModelState.IsValid)
            {
                db.ChuyenNganhs.Add(chuyenNganh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhoaId = new SelectList(db.Khoas, "Id", "Name");
            return View(chuyenNganh);
        }

        // GET: ChuyenNganhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenNganh chuyenNganh = db.ChuyenNganhs.Find(id);
            if (chuyenNganh == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhoaId = new SelectList(db.Khoas, "Id", "Name");
            return View(chuyenNganh);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NameCN,KhoaId")] ChuyenNganh chuyenNganh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuyenNganh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhoaId = new SelectList(db.Khoas, "Id", "Name");
            return View(chuyenNganh);
        }

        // GET: ChuyenNganhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenNganh chuyenNganh = db.ChuyenNganhs.Find(id);
            if (chuyenNganh == null)
            {
                return HttpNotFound();
            }
            return View(chuyenNganh);
        }

        // POST: ChuyenNganhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuyenNganh chuyenNganh = db.ChuyenNganhs.Find(id);
            db.ChuyenNganhs.Remove(chuyenNganh);
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
